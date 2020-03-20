using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemtemTracker.Data;
using Newtonsoft.Json;
using System.Drawing;

namespace TemtemTracker.Controllers
{
    public class ConfigLoader
    {
        

        private Species species;
        private Config config;
        private UserSettings userSettings;

        private bool loadFailed = false;

        public ConfigLoader()
        {
            if (File.Exists(Paths.speciesPath))
            {
                string speciesJson = File.ReadAllText(Paths.speciesPath);
                species = JsonConvert.DeserializeObject<Species>(speciesJson);
            }
            else
            {
                new ErrorMessage("Failed to load config file: " + Paths.speciesPath,
                    SetFailedStatus);
            }
            if (File.Exists(Paths.configPath))
            {
                string configJson = File.ReadAllText(Paths.configPath);
                config = JsonConvert.DeserializeObject<Config>(configJson);
            }
            else
            {
                new ErrorMessage("Failed to load config file: " + Paths.configPath,
                    SetFailedStatus);
            }
            if (File.Exists(Paths.userSettingsPath))
            {
                string userSettingsJson = File.ReadAllText(Paths.userSettingsPath);
                userSettings = JsonConvert.DeserializeObject<UserSettings>(userSettingsJson);
            }
            else
            {
                new ErrorMessage("Failed to load config file: " + Paths.userSettingsPath,
                    SetFailedStatus);
            }
        }

        public void SetFailedStatus()
        {
            loadFailed = true;
        }

        public bool LoadFailed()
        {
            return loadFailed;
        }

        public Species GetSpeciesList()
        {
            return this.species;
        }

        public Config GetConfig()
        {
            return this.config;
        }

        public UserSettings GetUserSettings()
        {
            return this.userSettings;
        }

        public static ScreenConfig GetConfigForAspectRatio(Config config, Size gameWindowSize)
        {
            double aspectRatio = gameWindowSize.Width / (double)gameWindowSize.Height;
            ScreenConfig result = config.aspectRatios[0];
            foreach(ScreenConfig conf in config.aspectRatios)
            {
                string[] dimensionsString = conf.aspectRatio.Split(':');
                int aspectRatioWidth=0;
                int aspectRatioHeight=0;
                if(!int.TryParse(dimensionsString[0], out aspectRatioWidth))
                {
                    new ErrorMessage("Failure while parsing aspect ratio width from config!", null);
                }
                if (!int.TryParse(dimensionsString[1], out aspectRatioHeight))
                {
                    new ErrorMessage("Failure while parsing aspect ratio height from config!", null);
                }
                double confRatio = aspectRatioWidth / (double) aspectRatioHeight;
                if (aspectRatio == confRatio)
                {
                    result = conf;
                    break;
                }
            }

            return result;
        }

    }
}
