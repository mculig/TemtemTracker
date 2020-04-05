using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemtemTracker.Data
{
    class TemtemWindowData
    {
        public List<Point> detectionSpots;
        public List<Rectangle> OCRViewports;
        public Size gameWindowSize;
        public bool detectedBattle;
    }
}
