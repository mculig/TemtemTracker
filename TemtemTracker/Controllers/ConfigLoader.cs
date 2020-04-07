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
        private readonly List<Style> styles;

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
                new ErrorMessage("Cannot find config file: " + Paths.SPECIES_PATH,
                    SetFailedStatus);
            }
            if (File.Exists(Paths.CONFIG_PATH))
            {
                string configJson = File.ReadAllText(Paths.CONFIG_PATH);
                config = JsonConvert.DeserializeObject<Config>(configJson);
            }
            else
            {
                new ErrorMessage("Cannot find config file: " + Paths.CONFIG_PATH,
                    SetFailedStatus);
            }
            if (File.Exists(Paths.USER_SETTINGS_PATH))
            {
                string userSettingsJson = File.ReadAllText(Paths.USER_SETTINGS_PATH);
                userSettings = JsonConvert.DeserializeObject<UserSettings>(userSettingsJson);
            }
            else
            {
                new ErrorMessage("Cannot find config file: " + Paths.USER_SETTINGS_PATH,
                    SetFailedStatus);
            }
            if (Directory.Exists(Paths.STYLES_PATH)) 
            {
                //Create the style list and add the default style
                this.styles = new List<Style>()
                {
                    SharedDefaults.DEFAULT_STYLE
                };
                List<string> errorNames = new List<string>(); //The names of styles that had an error
                List<string> incompatibleStyles = new List<string>(); //The names of styles that are an old version
                List<string> malformedStyles = new List<string>(); //Styles with malformed manifest json
                string[] subdirectories = Directory.GetDirectories(Paths.STYLES_PATH);
                foreach(string subdirectory in subdirectories)
                {
                    if(File.Exists(subdirectory + @"/Manifest.json"))
                    {
                        string styleJSON = File.ReadAllText(subdirectory + @"/Manifest.json");
                        try
                        {
                            Style style = JsonConvert.DeserializeObject<Style>(styleJSON);
                            if (style.styleVersion == SharedDefaults.CURRENT_STYLE_VERSION)
                            {
                                try
                                {
                                    ColorTranslator.FromHtml(style.menuStripBackground);
                                    ColorTranslator.FromHtml(style.menuStripForeground);
                                    ColorTranslator.FromHtml(style.menuItemSelected);
                                    ColorTranslator.FromHtml(style.trackerBackground);
                                    ColorTranslator.FromHtml(style.trackerForeground);
                                    ColorTranslator.FromHtml(style.timerForeground);
                                    ColorTranslator.FromHtml(style.timerPausedForeground);
                                    ColorTranslator.FromHtml(style.tableRowBackground1);
                                    ColorTranslator.FromHtml(style.tableRowBackground2);
                                    ColorTranslator.FromHtml(style.tableRowForeground1);
                                    ColorTranslator.FromHtml(style.tableRowForeground2);
                                    ColorTranslator.FromHtml(style.tableRowButtonHoverColor);
                                    ColorTranslator.FromHtml(style.tableRowButtonBackground);
                                    ColorTranslator.FromHtml(style.tableRowButtonForeground);
                                    styles.Add(style); //If everything goes fine, we add this to the list of styles
                                }
                                catch
                                {
                                    //If we had an exception, we catch it here and add it to the list of errors
                                    errorNames.Add(subdirectory);
                                }
                            }
                            else
                            {
                                incompatibleStyles.Add(subdirectory);
                            }
                        }
                        catch
                        {
                            malformedStyles.Add(subdirectory);
                        }                  
                    }
                    else
                    {
                        malformedStyles.Add(subdirectory);
                    }
                }
                if(errorNames.Count>0 || incompatibleStyles.Count>0 || malformedStyles.Count > 0)
                {
                    string styleParsingErrorMessage = "";
                    if (malformedStyles.Count > 0)
                    {
                        styleParsingErrorMessage += "The following style(s) in the styles directory are missing a Manifest.json file, or the file is malformed: \n";
                        malformedStyles.ForEach(style =>
                        {
                            styleParsingErrorMessage += style + "\n";
                        });
                    }
                    if (errorNames.Count > 0)
                    {
                        styleParsingErrorMessage += "The following style(s) in the styles directory contain improper values for one or more properties in Manifest.json: \n";
                        errorNames.ForEach(style =>
                        {
                            styleParsingErrorMessage += style + "\n";
                        });
                    }
                    if (incompatibleStyles.Count > 0)
                    {
                        styleParsingErrorMessage += "The following style(s) in the styles directory are an old version not compatible with the current version: \n";
                        incompatibleStyles.ForEach(style => 
                        {
                            styleParsingErrorMessage += style + "\n";
                        });
                    }
                    
                    new ErrorMessage(styleParsingErrorMessage, null);
                }
            }
            else
            {
                new ErrorMessage("Cannot find styles folder " + Paths.STYLES_PATH, null);
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

        public List<Style> GetStyles()
        {
            return this.styles;
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
