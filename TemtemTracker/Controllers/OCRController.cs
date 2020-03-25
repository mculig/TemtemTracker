using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TemtemTracker.Data;
using Tesseract;

namespace TemtemTracker.Controllers
{
    public class OCRController
    {

        private readonly string LANGUAGE = "eng";
        private readonly string TESS_DATAPATH = @"tessdata";
        private readonly uint ARGB_BLACK = 0xFF000000;
        private readonly uint ARGB_WHITE = 0xFFFFFFFF;
        private readonly uint ARGB_RED = 0xFFFF0000;

        private readonly TesseractEngine tesseract;
        
        private readonly Species speciesList;

        // Maximum distance an R, G or B subpixel max be from FF, used to determine what
        // is white for pre-OCR image cleanup
        private readonly int maxOCRSubpixelFFDistance;

        //Minimum width to resize image to before OCR Pre-processing
        private readonly int minimumOCRResizeWidth;

        //Tesseract character whitelist
        private readonly string OCRCharWhitelist;

        public OCRController(Config config, Species speciesList)
        {
            this.speciesList = speciesList;
            this.maxOCRSubpixelFFDistance = config.maxOCRSubpixelFFDistance;
            this.minimumOCRResizeWidth = config.minimumOCRResizeWidth;
            this.OCRCharWhitelist = config.OCRCharWhitelist;
            tesseract = new TesseractEngine(TESS_DATAPATH, LANGUAGE);
            //Limit tesseract to alphabet only
            tesseract.SetVariable("tessedit_char_whitelist", OCRCharWhitelist);           
        }

        public List<String> DoOCR(List<Bitmap> OCRViewports)
        {
            //Create a list to hold our results
            List<string> results = new List<string>();

            //Create a list of tasks
            List<Task<Bitmap>> taskList = new List<Task<Bitmap>>();
            //Create a task for each image processing segment
            foreach(Bitmap viewport in OCRViewports)
            {
                taskList.Add(Task.Run(()=> {               
                    //This is fine since ImageProcessingTask disposes of the provided image
                    return ImageProcessingTask(viewport);
                }));
            }

            //Wait for all processing to finish
            Task.WaitAll(taskList.ToArray());

            //Process the images
            foreach(Task<Bitmap> processingTask in taskList)
            {
                using(Bitmap processingResult = processingTask.Result)
                {
                    using (Page result = tesseract.Process(processingResult))
                    {
                        string ocrTextResult = result.GetText();
                        //Ignore any noise OR empty strings
                        if (ocrTextResult.Length <= 3)
                        {
                            continue;
                        }
                        //Run the similarity metric and get the closest actual name
                        ocrTextResult = GetClosestActualTemtemName(ocrTextResult, speciesList.species);
                        //Add the result to our results if it isn't the empty entry
                        //The empty entry is here to pick up short noise that might
                        //get interpreted as a character and will be closest in distance
                        //to an empty string
                        if (ocrTextResult != "")
                        {
                            results.Add(ocrTextResult);
                        }
                        
                    }
                }
            }
            //Return our array of OCR readings
            return results;
        }

        private Bitmap ImageProcessingTask(Bitmap image)
        {
            int resizedHeight = (int)Math.Ceiling((minimumOCRResizeWidth / (double)image.Width) * image.Height);
            Bitmap resizedCrop = new Bitmap(minimumOCRResizeWidth, resizedHeight);
            using (Graphics graphics = Graphics.FromImage(resizedCrop))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (ImageAttributes wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, new Rectangle(0, 0, resizedCrop.Width, resizedCrop.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            //Process the resize
            ProcessImage(resizedCrop);
            //Dispose the provided image
            image.Dispose();
            //Return the resized image
            return resizedCrop;
        }

        private void ProcessImage(Bitmap image)
        {
            int imageHeight = image.Height;
            int imageWidth = image.Width;

            uint[,] whiteMask = new uint[imageWidth, imageHeight];

            for(int i = 0; i < imageWidth; i++)
            {
                for(int j = 0; j < imageHeight; j++)
                {
                    int pixel = image.GetPixel(i, j).ToArgb();
                    if (TestWhite(pixel))
                    {
                        whiteMask[i, j] = ARGB_BLACK;
                    }
                    else
                    {
                        whiteMask[i, j] = ARGB_WHITE;
                    }
                }
            }

            //Scan along the middle of the image
            int scanningLine = imageHeight / 2;

            //We're going to identify letters using a DB-scan like method.
            //Initial points will be black pixels along the middle of the image
            //Pixels will join them in a cluster if they're black too.
            //Anything not part of this cluster is noise and gets removed

            int pixelID = 0;
            Dictionary<int, int> pixelMap = new Dictionary<int, int>();

            //Populate the pixelMap with pixelIDs and pixel locations along the scanning line
            for (int i = 0; i < imageWidth; i++)
            {
                if (whiteMask[i,scanningLine] == ARGB_BLACK)
                {
                    pixelMap[pixelID++]= i;
                }
            }

            //For each pixel in the IDs we'll set the whiteMask to RED and keep doing that for neighbouring pixels
            foreach(int PixelID in pixelMap.Keys)
            {
                int pixelI = pixelMap[PixelID];

                if (whiteMask[pixelI,scanningLine] == ARGB_RED)
                {
                    //We've already marked this pixel as a part of a middle cluster
                    continue;
                }
                //Run the check on this pixel
                PixelCheck(pixelI, scanningLine, whiteMask, imageHeight, imageWidth);
            }

            //Set red pixels to black and rest to white
            for (int i = 0; i < imageWidth; i++)
            {
                for (int j = 0; j < imageHeight; j++)
                {
                    if (whiteMask[i,j] == ARGB_RED)
                    {
                        whiteMask[i,j] = ARGB_BLACK;
                    }
                    else
                    {
                        whiteMask[i,j] = ARGB_WHITE;
                    }
                }
            }
            //Set the image pixels to the pixel values in the white mask
            for (int i = 0; i < imageWidth; i++)
            {
                for (int j = 0; j < imageHeight; j++)
                {
                    image.SetPixel(i, j, Color.FromArgb(unchecked((int)whiteMask[i,j])));
                }
            }

        }

        private bool TestWhite(int pixel)
        {

            // Test the pixel isn't transparent
            if ((pixel & ARGB_BLACK) != ARGB_BLACK)
            {
                return false;
            }

            // Test the maximum difference from 255 of a color
            if ((0xFF - (pixel >> 16 & 0xFF)) > maxOCRSubpixelFFDistance)
            {
                return false;
            }
            else if ((0xFF - (pixel >> 8 & 0xFF)) > maxOCRSubpixelFFDistance)
            {
                return false;
            }
            else if ((0xFF - (pixel & 0xFF)) > maxOCRSubpixelFFDistance)
            {
                return false;
            }

            return true;
        }

        private void PixelCheck(int i, int j, uint[,] whiteMask, int imageHeight, int imageWidth)
        {
            Queue<Tuple<int,int>> pixelStack = new Queue<Tuple<int, int>>();
            //Add the initial pixel coordinates
            pixelStack.Enqueue(Tuple.Create(i,j));
            //Proceess the queue
            while (pixelStack.Count != 0)
            {
                //Get pixel coordinates from the stack
                Tuple<int, int> coordinate = pixelStack.Dequeue();
                //Set that pixel red
                whiteMask[coordinate.Item1, coordinate.Item2] = ARGB_RED;
                //Check neighboring pixels
                foreach (int iOffset in new int[] { -1, 1 })
                {
                    foreach (int jOffset in new int[] { -1, 1 })
                    {
                        if(coordinate.Item1+iOffset >= imageWidth || coordinate.Item2+jOffset >= imageHeight)
                        {
                            continue;
                        }
                        if(coordinate.Item1+iOffset < 0 || coordinate.Item2+jOffset < 0)
                        {
                            continue;
                        }
                        if(whiteMask[coordinate.Item1+iOffset, coordinate.Item2 + jOffset] == ARGB_BLACK)
                        {
                            Tuple<int,int> newTuple = Tuple.Create(coordinate.Item1 + iOffset, coordinate.Item2 + jOffset);
                            if (!pixelStack.Contains(newTuple))
                            {
                                pixelStack.Enqueue(newTuple);
                            }
                        }
                    }
                }
            }
        }

        private string GetClosestActualTemtemName(string input, List<string> list)
        {
            //These values here are purely nonsensical high values and serve no other purpose
            int minScore = 20000;
            int minDistance = 20000;

            Fastenshtein.Levenshtein lev = new Fastenshtein.Levenshtein(input);

            foreach (string element in list)
            {
                int score = lev.DistanceFrom(element);
                if (score < minScore)
                {
                    minScore = score;
                    minDistance = list.IndexOf(element);
                }
            }

            return list[minDistance];
        }

    }
}
