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
        TemtemTableController tableController;
        HotkeyController hotkeyController;

        public SettingsController(Species species, UserSettings userSettings, TemtemTrackerUI trackerUI)
        {
            this.userSettings = userSettings;
            this.trackerUI = trackerUI;
            this.settingsWindow = new SettingsWindow(this);

            settingsWindow.PopulateSaiparkSettings(species.species, userSettings.saiparkMode, 
                userSettings.saiparkTemtem1, userSettings.saiparkTemtem2, 
                userSettings.saiparkTemtem1ChanceMultiplyer, userSettings.saiparkTemtem2ChanceMultiplyer);

            settingsWindow.PopulateWindowSettings(userSettings.mainWindowOpacity);

            settingsWindow.SetTimeToLumaRadioButton(userSettings.timeToLumaProbability);

            //Populate settings window hotkey labels
            PopulateSettingsWindowHotkeyLabels();

            //Set tracker UI dimensions
            trackerUI.Width = userSettings.mainWindowWidth;
            trackerUI.Height = userSettings.mainWindowHeight;
            trackerUI.Opacity = userSettings.mainWindowOpacity;

            //Set this as the settings controller in the UI
            trackerUI.SetSettingsController(this);
        }

        public void SetTableController(TemtemTableController tableController)
        {
            this.tableController = tableController;
        }

        public void SetHotkeyController(HotkeyController hotkeyController)
        {
            this.hotkeyController = hotkeyController;
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

        public void DisableHotkeys()
        {
            hotkeyController.DisableHotkeys();
        }

        public void EnableHotkeys()
        {
            hotkeyController.EnableHotkeys();
        }

        public void RemapResetTableHotkey(Keys modifiers, Keys newKey)
        {
            userSettings.resetTableHotkeyModifier = (int) modifiers;
            userSettings.resetTableHotkey = (int) newKey;
            hotkeyController.ReloadResetTableHotkey();
            PopulateSettingsWindowHotkeyLabels();
        }

        public void RemapPauseTimerHotkey(Keys modifiers, Keys newKey)
        {
            userSettings.pauseTimerHotkeyModifier = (int)modifiers;
            userSettings.pauseTimerHotkey = (int) newKey;
            hotkeyController.ReloadPauseTimerHotkey();
            PopulateSettingsWindowHotkeyLabels();
        }

        public void SetTimeToLumaProbability(double probability)
        {
            userSettings.timeToLumaProbability = probability;
            if (tableController != null)
            {
                //When initializing the app this can get fired before 
                //the table exists which isn't great
                //To prevent this we just check if it's null or not
                tableController.UpdateLumaTimes();
            }
            
        }

        public void SaveSettings()
        {
            String settingsJson = JsonConvert.SerializeObject(userSettings);
            File.WriteAllText(Paths.USER_SETTINGS_PATH, settingsJson);
        }

        private void PopulateSettingsWindowHotkeyLabels()
        {
            KeysConverter kc = new KeysConverter();
            string resetTableHotkeyModifiersString = HelperMethods.ModifierKeysToString((Keys) userSettings.resetTableHotkeyModifier);
            string pauseTimerHotkeyModifiersString = HelperMethods.ModifierKeysToString((Keys) userSettings.pauseTimerHotkeyModifier);
            settingsWindow.PopulateHotkeySettings(resetTableHotkeyModifiersString + kc.ConvertToString(userSettings.resetTableHotkey),
                pauseTimerHotkeyModifiersString + kc.ConvertToString(userSettings.pauseTimerHotkey));
        }

        
    }
}
