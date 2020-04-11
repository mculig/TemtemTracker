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
        private readonly UserSettings userSettings;
        private readonly SettingsWindow settingsWindow;
        private readonly TemtemTrackerUI trackerUI;
        private readonly List<Style> styles;
        TemtemTableController tableController;
        HotkeyController hotkeyController;
        TimerController timerController;

        public SettingsController(Species species, UserSettings userSettings, List<Style> styles, TemtemTrackerUI trackerUI)
        {
            this.userSettings = userSettings;
            this.styles = styles;
            this.trackerUI = trackerUI;
            this.settingsWindow = new SettingsWindow(this);

            //Disable settings window events to avoid every change triggering its onChange event
            settingsWindow.DisableEventHandlers();
            //Populate the SaiparkSettings window
            settingsWindow.PopulateSaiparkSettings(species.species, userSettings.saiparkMode, 
                userSettings.saiparkTemtem1, userSettings.saiparkTemtem2, 
                userSettings.saiparkTemtem1ChanceMultiplyer, userSettings.saiparkTemtem2ChanceMultiplyer);
            //Populate the window settings
            settingsWindow.PopulateWindowSettings(userSettings.mainWindowOpacity);
            //Populate the time to luma settings
            settingsWindow.SetTimeToLumaRadioButton(userSettings.timeToLumaProbability);
            //Populate inactivity settings
            settingsWindow.PopulateInactivitySettings(userSettings.pauseWhenInactive, userSettings.inactivityTreshold);
            //Populate settings window hotkey labels
            PopulateSettingsWindowHotkeyLabels();
            //Populate settings window Style ComboBox
            settingsWindow.PopulateStyleComboBox(styles, userSettings.windowStyle);
            //Populate settings window disabled detection while timer paused checkbox
            settingsWindow.SetDisableDetectionCheckboxChecked(userSettings.disableDetectionWhileTimerPaused);
            //Populate settings window autosave interval
            settingsWindow.SetAutosaveInterval(userSettings.autosaveInterval);

            //Enable events again
            settingsWindow.EnableEventHandlers();

            //Set tracker UI dimensions
            trackerUI.Width = userSettings.mainWindowWidth;
            trackerUI.Height = userSettings.mainWindowHeight;
            trackerUI.Opacity = userSettings.mainWindowOpacity;

            //Set tracker UI style
            SetWindowStyle(userSettings.windowStyle);

            //Set this as the settings controller in the UI
            trackerUI.SetSettingsController(this);
        }

        internal void SetTimerController(TimerController timerController)
        {
            this.timerController = timerController;
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

        public void SetWindowStyle(string windowStyle) //Used on initialization to set the style using its name
        {
            Style requestedStyle = HelperMethods.GetStyleByName(styles, windowStyle);
            if (requestedStyle != null)
            {
                userSettings.windowStyle = windowStyle;
                trackerUI.SetWindowStyle(requestedStyle);
            }
            else
            {
                userSettings.windowStyle = SharedDefaults.DEFAULT_STYLE_NAME;
                trackerUI.SetWindowStyle(HelperMethods.GetStyleByName(styles, SharedDefaults.DEFAULT_STYLE_NAME));
            }
            
        }

        public void SetWindowStyle(int styleIndex) //Used
        {
            Style requestedStyle = styles[styleIndex];
            userSettings.windowStyle = styles[styleIndex].styleName;
            trackerUI.SetWindowStyle(requestedStyle);
        }

        public void SetAutosaveInterval(int intervalMinutes)
        {
            userSettings.autosaveInterval = intervalMinutes;
            timerController.SetAutosaveTimeInterval(intervalMinutes);
        }

        public void SetDetectionDisabled(bool detectionDisabled)
        {
            userSettings.disableDetectionWhileTimerPaused = detectionDisabled;
            //To do this we simply pause the detection loop
            timerController.SetDisableDetectionOnTimerPause(detectionDisabled);
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

        public void SetPauseWhenInactive(bool checkboxValue)
        {
            userSettings.pauseWhenInactive = checkboxValue;
            timerController.SetInactivityTimerEnabled(checkboxValue);
        }

        public void SetPauseWhenInactiveInterval(int intervalMinutes)
        {
            userSettings.inactivityTreshold = intervalMinutes;
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
