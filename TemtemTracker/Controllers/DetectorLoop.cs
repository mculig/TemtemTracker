using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemtemTracker.Data;

namespace TemtemTracker.Controllers
{
    public class DetectorLoop
    {
        //Spots for detecting in-combat status
        //Detects the orange and blue switch Temtem and Wait buttons

        //The colors could just as well be int since the bit values are important and not the actual values of the integers
        //But Java bitches when parsing something that would overflow into negative integers from a hex string
        //So everything is unnecessarily long. This has no impact on the performance. It's just annoying.

        //Detection spot 1
        private double spot1WidthPercentage;
        private double spot1HeightPercentage;
        private readonly uint spot1RGB;
        private int spot1Y;
        private int spot1X;

        //Detection spot 2
        private double spot2WidthPercentage;
        private double spot2HeightPercentage;
        private readonly uint spot2RGB;
        private int spot2Y;
        private int spot2X;

        //Detection spot 3
        private double spot3WidthPercentage;
        private double spot3HeightPercentage;
        private readonly uint spot3RGB;
        private int spot3Y;
        private int spot3X;

        //Detection spot 4
        private double spot4WidthPercentage;
        private double spot4HeightPercentage;
        private readonly uint spot4RGB;
        private int spot4Y;
        private int spot4X;

        //Spots for detecting out-of combat status
        //Detects 2 spots along the blue border of the minimap

        //Detection spot 5
        private double spot5WidthPercentage;
        private double spot5HeightPercentage;
        private readonly uint spot5RGB;
        private int spot5Y;
        private int spot5X;

        //Detection spot 6
        private double spot6WidthPercentage;
        private double spot6HeightPercentage;
        private readonly uint spot6RGB;
        private int spot6Y;
        private int spot6X;

        //Used to check if the window size changed
        Size gameWindowSize = new Size(0, 0);

        //Maximum distance between the color I'm expecting and color from the screen
        private readonly int maxAllowedColorDistance;

        private readonly Config config;

        private bool detectedBattle=false;

        private readonly TemtemTableController tableController;
        private readonly OCRController ocrController;

        //For errors
        private readonly bool loadFailed = false;

        public DetectorLoop(Config config, TemtemTableController tableController, OCRController ocrController)
        {
            this.config = config;
            this.tableController = tableController;
            this.ocrController = ocrController;

            //Try and parse the rgb spots
            if (!uint.TryParse(config.spot1RGB, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out this.spot1RGB))
            {
                new ErrorMessage("Unable to parse spot1RGB from config!", null);
                loadFailed = true;
                return;
            }
            if (!uint.TryParse(config.spot2RGB, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out this.spot2RGB))
            {
                new ErrorMessage("Unable to parse spot2RGB from config!", null);
                loadFailed = true;
                return;
            }
            if (!uint.TryParse(config.spot3RGB, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out this.spot3RGB))
            {
                new ErrorMessage("Unable to parse spot3RGB from config!", null);
                loadFailed = true;
                return;
            }
            if (!uint.TryParse(config.spot4RGB, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out this.spot4RGB))
            {
                new ErrorMessage("Unable to parse spot4RGB from config!", null);
                loadFailed = true;
                return;
            }
            if (!uint.TryParse(config.spot5RGB, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out this.spot5RGB))
            {
                new ErrorMessage("Unable to parse spot5RGB from config!", null);
                loadFailed = true;
                return;
            }
            if (!uint.TryParse(config.spot6RGB, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out this.spot6RGB))
            {
                new ErrorMessage("Unable to parse spot6RGB from config!", null);
                loadFailed = true;
                return;
            }

            this.maxAllowedColorDistance = config.maxAllowedColorDistance;
            
        }

        public bool LoadFailed()
        {
            return loadFailed;
        }

        public void Detect()
        {
            Bitmap gameWindow = WindowFinder.GetTemtemWindowScreenshot();

            //For loading the detection spots
            ScreenConfig screenConfig;

            if (gameWindow == null)
            {
                //If the game screen is null we've detected nothing
                return;
            }

            if (!gameWindow.Size.Equals(this.gameWindowSize))
            {
                gameWindowSize = gameWindow.Size;

                screenConfig = ConfigLoader.GetConfigForAspectRatio(config, gameWindowSize);

                spot1WidthPercentage = screenConfig.spot1WidthPercentage;
                spot1HeightPercentage = screenConfig.spot1HeightPercentage;

                spot2WidthPercentage = screenConfig.spot2WidthPercentage;
                spot2HeightPercentage = screenConfig.spot2HeightPercentage;

                spot3WidthPercentage = screenConfig.spot3WidthPercentage;
                spot3HeightPercentage = screenConfig.spot3HeightPercentage;

                spot4WidthPercentage = screenConfig.spot4WidthPercentage;
                spot4HeightPercentage = screenConfig.spot4HeightPercentage;

                spot5WidthPercentage = screenConfig.spot5WidthPercentage;
                spot5HeightPercentage = screenConfig.spot5HeightPercentage;

                spot6WidthPercentage = screenConfig.spot6WidthPercentage;
                spot6HeightPercentage = screenConfig.spot6HeightPercentage;

                spot1X = (int)Math.Ceiling(spot1WidthPercentage * gameWindow.Width);
                spot1Y = (int)Math.Ceiling(spot1HeightPercentage * gameWindow.Height);

                spot2X = (int)Math.Ceiling(spot2WidthPercentage * gameWindow.Width);
                spot2Y = (int)Math.Ceiling(spot2HeightPercentage * gameWindow.Height);

                spot3X = (int)Math.Ceiling(spot3WidthPercentage * gameWindow.Width);
                spot3Y = (int)Math.Ceiling(spot3HeightPercentage * gameWindow.Height);

                spot4X = (int)Math.Ceiling(spot4WidthPercentage * gameWindow.Width);
                spot4Y = (int)Math.Ceiling(spot4HeightPercentage * gameWindow.Height);

                spot5X = (int)Math.Ceiling(spot5WidthPercentage * gameWindow.Width);
                spot5Y = (int)Math.Ceiling(spot5HeightPercentage * gameWindow.Height);

                spot6X = (int)Math.Ceiling(spot6WidthPercentage * gameWindow.Width);
                spot6Y = (int)Math.Ceiling(spot6HeightPercentage * gameWindow.Height);
            }

            //In-battle detection
            Color pixel1RGB = gameWindow.GetPixel(spot1X, spot1Y);
            Color pixel2RGB = gameWindow.GetPixel(spot2X, spot2Y);
            Color pixel3RGB = gameWindow.GetPixel(spot3X, spot3Y);
            Color pixel4RGB = gameWindow.GetPixel(spot4X, spot4Y);

            //Out-of-battle detection
            Color pixel5RGB = gameWindow.GetPixel(spot5X, spot5Y);
            Color pixel6RGB = gameWindow.GetPixel(spot6X, spot6Y);

            if (detectedBattle == false &&
               ((ColorDistance(pixel1RGB, spot1RGB) < maxAllowedColorDistance &&
               ColorDistance(pixel2RGB, spot2RGB) < maxAllowedColorDistance) ||
               (ColorDistance(pixel3RGB, spot3RGB) < maxAllowedColorDistance &&
               ColorDistance(pixel4RGB, spot4RGB) < maxAllowedColorDistance)))
            {
                detectedBattle = true;
                //Do OCR operation
                List<string> results = ocrController.DoOCR(gameWindow);
                results.ForEach(result => {
                    //Here we add the detected Temtem to the UI
                    tableController.AddTemtem(result);
                });
            }
            else if (detectedBattle == true &&
                    ColorDistance(pixel5RGB, spot5RGB) < maxAllowedColorDistance &&
                    ColorDistance(pixel6RGB, spot6RGB) < maxAllowedColorDistance)
            {
                //Set battle to false
                detectedBattle = false;
            }

            //Dispose of the game window at the very end of this loop
            gameWindow.Dispose();
        }

        private int ColorDistance(Color rgb1, uint rgbInt)
        {
            byte a1 = rgb1.A;
            byte r1 = rgb1.R;
            byte g1 = rgb1.G;
            byte b1 = rgb1.B;

            Color rgb2 = Color.FromArgb(unchecked((int)rgbInt));

            byte a2 = rgb2.A;
            byte r2 = rgb2.R;
            byte g2 = rgb2.G;
            byte b2 = rgb2.B;

            int distance = Math.Max((int)Math.Pow((r1 - r2), 2), (int)Math.Pow((r1 - r2 - a1 + a2), 2)) +
               Math.Max((int)Math.Pow((g1 - g2), 2), (int)Math.Pow((g1 - g2 - a1 + a2), 2)) +
               Math.Max((int)Math.Pow((b1 - b2), 2), (int)Math.Pow((b1 - b2 - a1 + a2), 2));

            return distance;
        }

    }
}
