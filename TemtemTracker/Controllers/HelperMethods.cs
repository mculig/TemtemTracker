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
    }
}
