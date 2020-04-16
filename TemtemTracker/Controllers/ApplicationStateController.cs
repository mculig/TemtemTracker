using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemtemTracker.Data;

namespace TemtemTracker.Controllers
{
    class ApplicationStateController
    {
        private static ApplicationStateController instance = null;
        private static readonly object padlock = new object();

        //Parts of the application state
        List<Style> loadedStyles=null;
        Style currentWindowStyle=null;
        UserSettings userSettings=null;
        bool timerEnabled = true;

        private ApplicationStateController()
        {

        }

        public static ApplicationStateController Instance
        {
            get
            {
                lock (padlock)
                {
                    if(instance == null)
                    {
                        instance = new ApplicationStateController();
                    }
                    return instance;
                }
            }
        }

        //Getters
        public UserSettings GetUserSettings()
        {
            return this.userSettings;
        }

        public Style GetWindowStyle()
        {
            return this.currentWindowStyle;
        }

        public List<Style> GetStyleList()
        {
            return this.loadedStyles;
        }

        //Method and event for style changes
        public void SetStyles(List<Style> loadedStyles)
        {
            this.loadedStyles = loadedStyles;
            if (userSettings != null)
            {
                Style requestedStyle = HelperMethods.GetStyleByName(loadedStyles, userSettings.windowStyle);
                if (requestedStyle != null)
                {
                    ApplicationStateController.Instance.ChangeStyle(requestedStyle);
                }
                else
                {
                    userSettings.windowStyle = SharedDefaults.DEFAULT_STYLE_NAME;
                    ApplicationStateController.Instance.ChangeStyle(HelperMethods.GetStyleByName(loadedStyles, SharedDefaults.DEFAULT_STYLE_NAME));
                }
            }
        }
        public void ChangeStyle(Style style)
        {
            currentWindowStyle = style;
            userSettings.windowStyle = style.styleName;
            OnStyleChanged(currentWindowStyle);
        }

        public void ChangeStyle(int index)
        {
            currentWindowStyle = loadedStyles[index];
            userSettings.windowStyle = currentWindowStyle.styleName;
            OnStyleChanged(currentWindowStyle);
        }

        protected virtual void OnStyleChanged(Style style)
        {
            StyleChanged?.Invoke(this, style);
        }

        public event EventHandler<Style> StyleChanged;

        //Method and event for user settings changes

        public void SetUserSettings(UserSettings userSettings)
        {
            this.userSettings = userSettings;
            OnUserSettingsChanged(userSettings);
        }

        public void UpdateUserSettings()
        {
            OnUserSettingsChanged(userSettings);
        }

        public void ChangeMainWindowOpacity(double opacity)
        {
            userSettings.mainWindowOpacity = opacity;
            OnMainWindowOpacityChanged(userSettings.mainWindowOpacity);
        }

        protected virtual void OnUserSettingsChanged(UserSettings userSettings)
        {
            UserSettingsChanged?.Invoke(this, userSettings);
        }

        public event EventHandler<UserSettings> UserSettingsChanged;

        protected virtual void OnMainWindowOpacityChanged(double mainWindowOpacity)
        {
            MainWindowOpacityChanged?.Invoke(this, mainWindowOpacity);
        }

        public event EventHandler<double> MainWindowOpacityChanged;

        //Method and event for pausing the timer

        public void ToggleTimerPaused()
        {
            timerEnabled = !timerEnabled;
            OnTimerPauseChange(timerEnabled);
        }

        public void StopTimer()
        {
            timerEnabled = false;
            OnTimerPauseChange(timerEnabled);
        }

        public bool TimerEnabled()
        {
            return timerEnabled;
        }

        protected virtual void OnTimerPauseChange(bool timerPaused)
        {
            TimerPauseChange?.Invoke(this, timerPaused);
        }

        public event EventHandler<bool> TimerPauseChange;
    }
}
