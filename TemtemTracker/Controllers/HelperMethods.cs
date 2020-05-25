using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemtemTracker.Data;

namespace TemtemTracker.Controllers
{
    public class HelperMethods
    {
        public static string ModifierKeysToString(Keys modifierKeys)
        {
            KeysConverter kc = new KeysConverter();
            string modifierKeysString = kc.ConvertToString(modifierKeys);
            modifierKeysString = modifierKeysString.Replace("+None", ""); //If there is a combination none will show up as +None
            modifierKeysString = modifierKeysString.Replace("None", ""); //If there is no combination it will just be None
            if (modifierKeysString.Length > 0)
            {
                modifierKeysString += "+";
            }
            return modifierKeysString;
        }

        public static Style GetStyleByName(List<Style> styles, string name)
        {
            Style requestedStyle = null;
            styles.ForEach(style => { 
                if(style.styleName == name)
                {
                    requestedStyle = style;
                }
            });
            return requestedStyle;
        }

        public static Style GetDefaultStyle()
        {
            return new Style { 
            
            };

        }
        public static String DoubleToPercentage(double number)
        {
            return number.ToString("P");
        }

        public static String MilisToHMS(long milis)
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(milis);
            return ((int)ts.TotalHours).ToString("00") + ts.ToString(@"\:mm\:ss");
        }

        public static Tuple<DateTime, DateTime> GetCurrentWeek()
        {
            DateTime today = DateTime.Today;
            return GetWeekOfDay(today);
        }

        public static Tuple<DateTime, DateTime> GetPriorWeek(Tuple<DateTime, DateTime> week)
        {
            //We can subtract a day from the 1st day because it starts at 00:00:00
            return GetWeekOfDay(week.Item1.AddDays(-1)); 
        }

        public static Tuple<DateTime, DateTime> GetNextWeek(Tuple<DateTime,DateTime> week)
        {
            //For the last day it ends at 23:59:59 and we have to add a second 
            //to roll over to 00:00:00 on the next day or our formula gives wrong resuls
            return GetWeekOfDay(week.Item2.AddSeconds(1)); 
        }

        private static Tuple<DateTime, DateTime> GetWeekOfDay(DateTime day)
        {
            DateTime weekStart = day.AddDays(
                day.DayOfWeek == 0 ? -6 : -(int)day.DayOfWeek + 1);
            DateTime weekEnd = weekStart.AddDays(7).AddSeconds(-1);

            Console.WriteLine("Start date: " + weekStart + " End date: " + weekEnd);

            return new Tuple<DateTime, DateTime>(weekStart, weekEnd);
        }


    }
}
