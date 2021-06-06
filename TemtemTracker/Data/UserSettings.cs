using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemtemTracker.Data
{
    public class UserSettings
    {
        public double mainWindowOpacity;
        public string windowStyle;
        public int mainWindowWidth;
        public int mainWindowHeight;
        public int autosaveInterval;
        public bool disableDetectionWhileTimerPaused;
        public bool resumeAutopausedTimerOnDetection;
        public double timeToLumaProbability;
        public bool saiparkMode;
        public string saiparkTemtem1;
        public string saiparkTemtem2;
        public double saiparkTemtem1ChanceMultiplyer;
        public double saiparkTemtem2ChanceMultiplyer;
        public int resetTableHotkeyModifier;
        public int resetTableHotkey;
        public int pauseTimerHotkeyModifier;
        public int pauseTimerHotkey;
        public bool pauseWhenInactive;
        public int inactivityTreshold;
        public bool webserverEnabled;
        public int webserverPort;
    }
}
