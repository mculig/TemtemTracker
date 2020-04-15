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
        HotkeyController hotkeyController;
        TimerController timerController;

        public SettingsController(Species species)
        {
            this.settingsWindow = new SettingsWindow(this);
            this.userSettings = ApplicationStateController.Instance.GetUserSettings();

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
            settingsWindow.PopulateStyleComboBox(ApplicationStateController.Instance.GetStyleList(), userSettings.windowStyle);
            //Populate settings window disabled detection while timer paused checkbox
            settingsWindow.SetDisableDetectionCheckboxChecked(userSettings.disableDetectionWhileTimerPaused);
            //Populate settings window autosave interval
            settingsWindow.SetAutosaveInterval(userSettings.autosaveInterval);
            //Enable events again
            settingsWindow.EnableEventHandlers();

        }

        internal void SetTimerController(TimerController timerController)
        {
            this.timerController = timerController;
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
            ApplicationStateController.Instance.ChangeMainWindowOpacity(opacityValue / (double)100);
        }

        public void SetWindowStyle(int styleIndex) //Used
        {
            ApplicationStateController.Instance.ChangeStyle(styleIndex);
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
            ApplicationStateController.Instance.UpdateUserSettings();
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
