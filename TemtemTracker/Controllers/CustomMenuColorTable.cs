using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemtemTracker.Data;

namespace TemtemTracker.Controllers
{
    public class CustomMenuColorTable : ProfessionalColorTable
    {
        private readonly Color menuBorderColor;
        private readonly Color menuItemBorderColor;
        private readonly Color menuItemSelectedColor;
        private readonly Color toolStripBackgroundColor;
        private readonly Color menuForegroundColor;

        public CustomMenuColorTable(Style style)
        {
            //Set the individual colors
            base.UseSystemColors = false;
            menuBorderColor = ColorTranslator.FromHtml(style.menuStripForeground);
            menuItemBorderColor = ColorTranslator.FromHtml(style.menuStripForeground);
            toolStripBackgroundColor = ColorTranslator.FromHtml(style.toolStripBackground);
            menuItemSelectedColor = ColorTranslator.FromHtml(style.menuItemSelected);
            menuForegroundColor = ColorTranslator.FromHtml(style.trackerForeground);
        }
        //This controls the border of the menu
        public override Color MenuBorder
        {
            get { return menuBorderColor; }
        }
        //This controls the border around menu items
        public override Color MenuItemBorder
        {
            get { return menuItemBorderColor; }
        }
        //This controls a menu item that has been selected (hovered) and the gradient on it
        public override Color MenuItemSelected
        {
            get { return menuItemSelectedColor; }
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get { return menuItemSelectedColor; }
        }
        // This controls the color of a menu item that has been pressed and is showing the menu
        public override Color MenuItemPressedGradientBegin
        {
            get { return menuItemSelectedColor; }
        }
        public override Color MenuItemPressedGradientMiddle
        {
            get { return menuItemSelectedColor; }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get { return menuItemSelectedColor; }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get { return menuItemSelectedColor; }
        }
        //This controls the margin on the left in the dropdown
        public override Color ImageMarginGradientBegin
        {
           get { return toolStripBackgroundColor; }
        }
        public override Color ImageMarginGradientMiddle
        {
           get { return toolStripBackgroundColor; }
        }
        public override Color ImageMarginGradientEnd
        {
            get { return toolStripBackgroundColor; }
        }
        //Thic controls the dropdown itself
        public override Color ToolStripDropDownBackground
        {
            get { return toolStripBackgroundColor; }
        }
        //This controls the separator lines in the dropdown
        public override Color SeparatorDark
        {
            get { return menuForegroundColor; }
        }
        public override Color SeparatorLight
        {
            get { return menuForegroundColor; }
        }
    }
}
