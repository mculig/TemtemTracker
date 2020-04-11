using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemtemTracker.Data
{
    public class SharedDefaults
    {
        public static readonly string DEFAULT_STYLE_NAME = "Default";
        public static readonly int CURRENT_STYLE_VERSION = 2;
        public static Style DEFAULT_STYLE = new Style
        {
            styleVersion = SharedDefaults.CURRENT_STYLE_VERSION,
            styleName = SharedDefaults.DEFAULT_STYLE_NAME,
            menuStripBackground = "#F0F0F0",
            menuStripForeground = "#000000",
            toolStripBackground = "#F0F0F0",
            menuItemSelected = "#D8EAF9",
            trackerBackground = "#F0F0F0",
            trackerForeground = "#000000",
            timerForeground = "#000000",
            timerPausedForeground = "#FF0000",
            tableRowBackground1 = "#F0F0F0",
            tableRowBackground2 = "#E3E3E3",
            tableRowForeground1 = "#000000",
            tableRowForeground2 = "#000000",
            tableRowButtonHoverColor = "#D8EAF9",
            tableRowButtonBackground = "#F0F0F0",
            tableRowButtonForeground = "#000000",
            tableRowButtonBorderColor = "#000000"
        };
    }
}
