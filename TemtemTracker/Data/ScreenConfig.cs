using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemtemTracker.Data
{
    public class ScreenConfig
    {
        public string aspectRatio;

        // Detection spot 1
        public double spot1WidthPercentage;
        public double spot1HeightPercentage;

        // Detection spot 2
        public double spot2WidthPercentage;
        public double spot2HeightPercentage;


        // Detection spot 3
        public double spot3WidthPercentage;
        public double spot3HeightPercentage;


        // Detection spot 4
        public double spot4WidthPercentage;
        public double spot4HeightPercentage;


        // Spots for detecting out-of combat status
        // Detects 2 spots along the blue border of the minimap

        // Detection spot 5
        public double spot5WidthPercentage;
        public double spot5HeightPercentage;

        // Detection spot 6
        public double spot6WidthPercentage;
        public double spot6HeightPercentage;

        // Frame locations for OCR
        public double frame1PercentageLeft;
        public double frame1PercentageTop;
        public double frame2PercentageLeft;
        public double frame2PercentageTop;
        public double frameWidthPercentage;
        public double frameHeightPercentage;
    }
}
