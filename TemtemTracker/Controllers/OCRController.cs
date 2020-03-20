using System;
using System.Collections.Generic;
using System.Drawing;
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

        private TesseractEngine tesseract;
        private readonly string language = "eng";
        private readonly string tessDatapath = @"tessdata";

        private List<Rectangle> OCRViewports;
        Species speciesList;

        // Frame locations for OCR
        private double frame1PercentageLeft;
        private double frame1PercentageTop;
        private double frame2PercentageLeft;
        private double frame2PercentageTop;
        private double frameWidthPercentage;
        private double frameHeightPercentage;

        //Frame location points
        Point frame1Location;
        Point frame2Location;

        // Frame size
        private Size frameSize;

        // Used to check if the window size changed
        private Size gameWindowSize = new Size(0, 0);

        // Maximum distance an R, G or B subpixel max be from FF, used to determine what
        // is white for pre-OCR image cleanup
        int maxOCRSubpixelFFDistance;

        //Config
        Config config;

        public OCRController(Config config, Species speciesList)
        {
            this.speciesList = speciesList;
            this.maxOCRSubpixelFFDistance = config.maxOCRSubpixelFFDistance;
            this.config = config;
            tesseract = new TesseractEngine(tessDatapath, language);
        }

        public List<String> doOCR(Bitmap gameWindow)
        {
            if (!this.gameWindowSize.Equals(gameWindow.Size))
            {
                this.gameWindowSize = gameWindow.Size;

                ScreenConfig screenConfig = ConfigLoader.GetConfigForAspectRatio(config, gameWindowSize);

                this.frame1PercentageLeft = screenConfig.frame1PercentageLeft;
                this.frame1PercentageTop = screenConfig.frame1PercentageTop;

                this.frame2PercentageLeft = screenConfig.frame2PercentageLeft;
                this.frame2PercentageTop = screenConfig.frame2PercentageTop;

                this.frameWidthPercentage = screenConfig.frameWidthPercentage;
                this.frameHeightPercentage = screenConfig.frameHeightPercentage;

                this.frameSize = new Size((int)Math.Ceiling(gameWindowSize.Width * frameWidthPercentage),
                        (int)Math.Ceiling(gameWindowSize.Height * frameHeightPercentage));

                frame1Location = new Point((int)Math.Ceiling(gameWindowSize.Width * frame1PercentageLeft),
                (int)Math.Ceiling(gameWindowSize.Height * frame1PercentageTop));
                frame2Location = new Point((int)Math.Ceiling(gameWindowSize.Width * frame2PercentageLeft),
                (int)Math.Ceiling(gameWindowSize.Height * frame2PercentageTop));
            }

            this.OCRViewports = new List<Rectangle>();

            OCRViewports.Add(new Rectangle(frame1Location, frameSize));
            OCRViewports.Add(new Rectangle(frame2Location, frameSize));

            List<string> results = new List<string>();

            foreach(Rectangle viewport in OCRViewports)
            {
                Bitmap viewportCrop = gameWindow.Clone(viewport, gameWindow.PixelFormat);
                ProcessImage(viewportCrop);
                Page result = tesseract.Process(viewportCrop);
                string text = result.GetText();
                //Dispose of the result
                result.Dispose();
                text = Regex.Replace(text, "[^a-zA-Z]","");
                if (text.Length <= 3)
                {
                    continue;
                }
                text = StringSimilarityCompare(text, speciesList.species);
                results.Add(text);
                //Dispose of the image
                viewportCrop.Dispose();
                
            }



            return results;

        }

        private void ProcessImage(Bitmap image)
        {
            int imageHeight = image.Height;
            int imageWidth = image.Width;

            //int[,] pixels = new int[imageWidth,imageHeight];
            uint[,] whiteMask = new uint[imageWidth, imageHeight];

            for(int i = 0; i < imageWidth; i++)
            {
                for(int j = 0; j < imageHeight; j++)
                {
                    int pixel = image.GetPixel(i, j).ToArgb();
                    if (testWhite(pixel))
                    {
                        whiteMask[i, j] = 0xFF000000;
                    }
                    else
                    {
                        whiteMask[i, j] = 0xFFFFFFFF;
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
                if (whiteMask[i,scanningLine] == 0xFF000000)
                {
                    pixelMap[pixelID++]= i;
                }
            }

            //For each pixel in the IDs we'll set the whiteMask to RED and keep doing that for neighbouring pixels
            foreach(int PixelID in pixelMap.Keys)
            {
                int pixelI = pixelMap[PixelID];

                if (whiteMask[pixelI,scanningLine] == 0xFFFF0000)
                {
                    //We've already marked this pixel as a part of a middle cluster
                    continue;
                }
                //Run the recursive check on this pixel
                recursivePixelCheck(pixelI, scanningLine, whiteMask, imageHeight, imageWidth);
            }

            //Set red pixels to black and rest to white
            for (int i = 0; i < imageWidth; i++)
            {
                for (int j = 0; j < imageHeight; j++)
                {
                    if (whiteMask[i,j] == 0xFFFF0000)
                    {
                        whiteMask[i,j] = 0xFF000000;
                    }
                    else
                    {
                        whiteMask[i,j] = 0xFFFFFFFF;
                    }
                }
            }

            for (int i = 0; i < imageWidth; i++)
            {
                for (int j = 0; j < imageHeight; j++)
                {
                    image.SetPixel(i, j, Color.FromArgb(unchecked((int)whiteMask[i,j])));
                }
            }

        }

        private bool testWhite(int pixel)
        {

            // Test the pixel isn't transparent
            if ((pixel & 0xFF000000) != 0xFF000000)
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

        private void recursivePixelCheck(int i, int j, uint[,] whiteMask, int imageHeight, int imageWidth)
        {
            //Check if we're out of bounds
            //This should never happen as text is central to the image and should never have an uninterrupted
            //tendril of black pixels connecting it to the edges, but it's good practice to check
            if (i >= imageWidth || j >= imageHeight)
            {
                return;
            }
            if (i < 0 || j < 0)
            {
                return;
            }
            //If a pixel is already red, we've done it
            if (whiteMask[i,j] == 0xFFFF0000)
            {
                return;
            }
            else if (whiteMask[i,j] == 0xFFFFFFFF)
            {
                //If the pixel is white, we're not interested in its neighbours
                return;
            }
            else
            {
                //Mark the pixel red;
                whiteMask[i,j] = 0xFFFF0000;
                foreach(int iOffset in new int[] { -1, 1 })
                {
                    foreach(int jOffset in new int[] { -1, 1 })
                    {
                        //Do the recursive check on nearby pixels
                        recursivePixelCheck(i + iOffset, j + jOffset, whiteMask, imageHeight, imageWidth);
                    }
                }
            }
        }

        private string StringSimilarityCompare(string input, List<string> list)
        {
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
