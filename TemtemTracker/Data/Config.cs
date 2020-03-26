using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemtemTracker.Data
{
    public class Config
    {
        public double lumaChance;

        //Interval (in ms) to run detection loop at
        public int detectionLoopInterval;

        //Colours for the various detection spots
        public String spot1RGB;
        public String spot2RGB;
        public String spot3RGB;
        public String spot4RGB;
        public String spot5RGB;
        public String spot6RGB;

        //Maximum distance between the color I'm expecting and color from the screen
        public int maxAllowedColorDistance;
        //Maximum distance from FF an individual color subpixel may be when determining what is white for OCR image cleanup
        public int maxOCRSubpixelFFDistance;
        //Minimum width to resize image to before OCR Pre-processing
        public int minimumOCRResizeWidth;
        //Maximum number of pixels that can reasonably be expected in a resized letter
        //Used to recognize large blobs that result from pre-OCR cleanup picking up clouds
        public int maximumLetterPixelCount;
        //Tesseract character whitelist
        public string OCRCharWhitelist;

        public List<ScreenConfig> aspectRatios;
    }
}
