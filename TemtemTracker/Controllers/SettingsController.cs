using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemtemTracker.Data;

namespace TemtemTracker.Controllers
{
    public class SettingsController
    {
        UserSettings userSettings;
        SettingsWindow settingsWindow;
        TemtemTrackerUI trackerUI;

        public SettingsController(Species species, UserSettings userSettings, TemtemTrackerUI trackerUI)
        {
            this.userSettings = userSettings;
            this.trackerUI = trackerUI;
            this.settingsWindow = new SettingsWindow(this);

            settingsWindow.PopulateSaiparkSettings(species.species, userSettings.saiparkMode, 
                userSettings.saiparkTemtem1, userSettings.saiparkTemtem2, 
                userSettings.saiparkTemtem1ChanceMultiplyer, userSettings.saiparkTemtem2ChanceMultiplyer);

            settingsWindow.PopulateWindowSettings(userSettings.mainWindowOpacity);

            KeysConverter kc = new KeysConverter();
            settingsWindow.PopulateHotkeySettings(kc.ConvertToString(userSettings.resetTableHotkey), kc.ConvertToString(userSettings.pauseTimerHotkey));

            trackerUI.Width = userSettings.mainWindowWidth;
            trackerUI.Height = userSettings.mainWindowHeight;
            trackerUI.Opacity = userSettings.mainWindowOpacity;

            //Set this as the settings controller in the UI
            trackerUI.SetSettingsController(this);
        }

        public UserSettings GetSettings()
        {
            return this.userSettings;
        }

        public void ShowSettingsWindow()
        {
            settingsWindow.Show();
        }

        public void SetSaiparkMode(bool value)
        {
            userSettings.saiparkMode = value;
        }

        public void SetTemtem1Multiplier(double multiplier)
        {
            userSettings.saiparkTemtem1ChanceMultiplyer = multiplier;
        }

        public void SetTemtem2Multiplier(double multiplier)
        {
            userSettings.saiparkTemtem2ChanceMultiplyer = multiplier;
        }

        public void SetTemtem1Name(string name)
        {
            userSettings.saiparkTemtem1 = name;
        }

        public void SetTemtem2Name(string name)
        {
            userSettings.saiparkTemtem2 = name;
        }

        public void SetMainWindowOpacity(int opacityValue)
        {
            userSettings.mainWindowOpacity = opacityValue / (double) 100;
            trackerUI.Opacity = opacityValue / (double) 100;
        }

        public void SetMainWindowSize(Size mainWindowSize)
        {
            userSettings.mainWindowWidth = mainWindowSize.Width;
            userSettings.mainWindowHeight = mainWindowSize.Height;
        }

        public void SaveSettings()
        {
            String settingsJson = JsonConvert.SerializeObject(userSettings);
            File.WriteAllText(Paths.USER_SETTINGS_PATH, settingsJson);
        }

    }
}
