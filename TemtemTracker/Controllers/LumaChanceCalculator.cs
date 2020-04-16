using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemtemTracker.Data;

namespace TemtemTracker.Controllers
{
    public class LumaChanceCalculator
    {
        private readonly UserSettings userSettings;
        private readonly Config config;

        public LumaChanceCalculator(SettingsController settingsController, Config config)
        {
            this.userSettings = settingsController.GetUserSettings();
            this.config = config;
        }

        public double CalculateChance(int encounters, String temtemName)
        {
            double lumaChance = SaiparkMultiplyer(temtemName);
            return (1 - Math.Pow((1 - lumaChance), encounters));
        }

        //Calculates the time required to get a luma with 0.9999 probability in miliseconds
        public long GetTimeToLuma(int encounters, long timeMilis, String temtemName)
        {
            //This can happen when updating stuff
            if (encounters == 0)
            {
                return 0;
            }
            else if (timeMilis == 0)
            {
                return 0;
            }

            double lumaChance = SaiparkMultiplyer(temtemName);

            //If no 0s sent, calculate this stuff
            double encountersRequired = Math.Log10(1 - userSettings.timeToLumaProbability) / Math.Log10(1 - lumaChance);
            double milisPerEncounter = timeMilis / (double) encounters;
            long timeRequired = (long)(((long)encountersRequired - encounters) * milisPerEncounter);
            return timeRequired;
        }

        private double SaiparkMultiplyer(String temtemName)
        {
            double lumaChance = this.config.lumaChance;
            if (userSettings.saiparkMode)
            {
                if (temtemName.Equals(userSettings.saiparkTemtem1))
                {
                    lumaChance *= userSettings.saiparkTemtem1ChanceMultiplyer;
                }
                else if (temtemName.Equals(userSettings.saiparkTemtem2))
                {
                    lumaChance *= userSettings.saiparkTemtem2ChanceMultiplyer;
                }
            }
            return lumaChance;
        }

    }
}
