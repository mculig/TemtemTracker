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
        

        private readonly Species species;
        private readonly Config config;
        private readonly UserSettings userSettings;

        private bool loadFailed = false;

        public ConfigLoader()
        {
            if (File.Exists(Paths.SPECIES_PATH))
            {
                string speciesJson = File.ReadAllText(Paths.SPECIES_PATH);
                species = JsonConvert.DeserializeObject<Species>(speciesJson);
            }
            else
            {
                new ErrorMessage("Failed to load config file: " + Paths.SPECIES_PATH,
                    SetFailedStatus);
            }
            if (File.Exists(Paths.CONFIG_PATH))
            {
                string configJson = File.ReadAllText(Paths.CONFIG_PATH);
                config = JsonConvert.DeserializeObject<Config>(configJson);
            }
            else
            {
                new ErrorMessage("Failed to load config file: " + Paths.CONFIG_PATH,
                    SetFailedStatus);
            }
            if (File.Exists(Paths.USER_SETTINGS_PATH))
            {
                string userSettingsJson = File.ReadAllText(Paths.USER_SETTINGS_PATH);
                userSettings = JsonConvert.DeserializeObject<UserSettings>(userSettingsJson);
            }
            else
            {
                new ErrorMessage("Failed to load config file: " + Paths.USER_SETTINGS_PATH,
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
                if (!int.TryParse(dimensionsString[0], out int aspectRatioWidth)) //Inline variable declaration
                {
                    new ErrorMessage("Failure while parsing aspect ratio width from config!", null);
                }
                if (!int.TryParse(dimensionsString[1], out int aspectRatioHeight)) //Inline variable declaration
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
