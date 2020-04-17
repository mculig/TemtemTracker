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
        private readonly List<Style> loadedStyles = null;
        private Style currentWindowStyle = null;
        private bool timeTrackerTimerEnabled = true;

        public SettingsController(Species species, List<Style> styles, UserSettings userSettings)
        {
            settingsWindow = new SettingsWindow(this);
            this.userSettings = userSettings;
            loadedStyles = styles;

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
            settingsWindow.PopulateStyleComboBox(loadedStyles, userSettings.windowStyle);
            //Populate settings window disabled detection while timer paused checkbox
            settingsWindow.SetDisableDetectionCheckboxChecked(userSettings.disableDetectionWhileTimerPaused);
            //Populate settings window autosave interval
            settingsWindow.SetAutosaveInterval(userSettings.autosaveInterval);
            //Enable events again
            settingsWindow.EnableEventHandlers();
            //Initialize styles
            InitializeStyle();

        }

        public UserSettings GetUserSettings()
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
            double opacity = opacityValue / (double)100;
            userSettings.mainWindowOpacity = opacity;
            MainWindowOpacityChanged?.Invoke(this, opacity);
        }

        public event EventHandler<double> MainWindowOpacityChanged;

        public Style GetWindowStyle()
        {
            return currentWindowStyle;
        }

        public void SetWindowStyle(int styleIndex) //Used
        {
            currentWindowStyle = loadedStyles[styleIndex];
            userSettings.windowStyle = currentWindowStyle.styleName;
            StyleChanged?.Invoke(this, currentWindowStyle);
        }

        public void SetWindowStyle(Style style)
        {
            currentWindowStyle = style;
            userSettings.windowStyle = currentWindowStyle.styleName;
            StyleChanged?.Invoke(this, currentWindowStyle);
        }

        public void InitializeStyle()
        {
            Style requestedStyle = HelperMethods.GetStyleByName(loadedStyles, userSettings.windowStyle);
            if (requestedStyle != null)
            {
                SetWindowStyle(requestedStyle);
            }
            else
            {
                userSettings.windowStyle = SharedDefaults.DEFAULT_STYLE_NAME;
                SetWindowStyle(HelperMethods.GetStyleByName(loadedStyles, SharedDefaults.DEFAULT_STYLE_NAME));
            }
        }

        public event EventHandler<Style> StyleChanged;

        public void SetAutosaveInterval(int intervalMinutes)
        {
            userSettings.autosaveInterval = intervalMinutes;
            AutosaveIntervalChanged?.Invoke(this, intervalMinutes);
        }

        public event EventHandler<int> AutosaveIntervalChanged;

        public void SetDetectionDisabled(bool detectionDisabled)
        {
            userSettings.disableDetectionWhileTimerPaused = detectionDisabled;
            DetectionDisabledChanged?.Invoke(this, detectionDisabled);
        }

        public event EventHandler<bool> DetectionDisabledChanged;

        public void SetMainWindowSize(Size mainWindowSize)
        {
            userSettings.mainWindowWidth = mainWindowSize.Width;
            userSettings.mainWindowHeight = mainWindowSize.Height;
        }

        public bool GetTimeTrackerTimerEnabled()
        {
            return timeTrackerTimerEnabled;
        }

        public void StopTimer()
        {
            timeTrackerTimerEnabled = false;
            TimerPausedToggled?.Invoke(this, timeTrackerTimerEnabled);
        }

        public void ToggleTimerPaused()
        {
            timeTrackerTimerEnabled = !timeTrackerTimerEnabled;
            TimerPausedToggled?.Invoke(this, timeTrackerTimerEnabled);
        }

        public event EventHandler<bool> TimerPausedToggled;

        public void DisableHotkeys()
        {
            ToggleHotkeysEnabled?.Invoke(this, false);
        }      

        public void EnableHotkeys()
        {
            ToggleHotkeysEnabled?.Invoke(this, true);
        }

        public event EventHandler<bool> ToggleHotkeysEnabled;

        public void RemapResetTableHotkey(Keys modifiers, Keys newKey)
        {
            userSettings.resetTableHotkeyModifier = (int) modifiers;
            userSettings.resetTableHotkey = (int) newKey;
            ResetTableHotkeyChanged?.Invoke(this, EventArgs.Empty);
            PopulateSettingsWindowHotkeyLabels();
        }

        public event EventHandler ResetTableHotkeyChanged;

        public void RemapPauseTimerHotkey(Keys modifiers, Keys newKey)
        {
            userSettings.pauseTimerHotkeyModifier = (int)modifiers;
            userSettings.pauseTimerHotkey = (int) newKey;
            PauseTimerHotkeyChanged?.Invoke(this, EventArgs.Empty);
            PopulateSettingsWindowHotkeyLabels();
        }

        public event EventHandler PauseTimerHotkeyChanged;

        public void SetTimeToLumaProbability(double probability)
        {
            userSettings.timeToLumaProbability = probability;
            TimeToLumaProbabilityChanged?.Invoke(this, probability);
        }

        public event EventHandler<double> TimeToLumaProbabilityChanged;

        public void SetPauseWhenInactive(bool checkboxValue)
        {
            userSettings.pauseWhenInactive = checkboxValue;
            InactivityTimerEnabledChanged?.Invoke(this, checkboxValue);
        }

        public event EventHandler<bool> InactivityTimerEnabledChanged;

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
