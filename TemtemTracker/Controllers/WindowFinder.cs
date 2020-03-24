using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemtemTracker.Data;

namespace TemtemTracker.Controllers
{
    public class WindowFinder
    {
        private static readonly string WINDOW_NAME = "Temtem";

        public WindowFinder()
        {
            
        }

        public static Bitmap getTemtemWindowScreenshot()
        {
            //Pointer to the Temtem Window
            IntPtr temtemWindow = IntPtr.Zero;

            //Get the currently focused window
            IntPtr focused = User32.GetForegroundWindow();

            //If we're not focusing a window
            if(focused == IntPtr.Zero)
            {
                return null;
            }
            //Check if the focused window is Temtem
            StringBuilder windowName = new StringBuilder(100);
            User32.GetWindowText(focused, windowName, 100);
            uint focusedWindowProcessID;
            User32.GetWindowThreadProcessId(focused, out focusedWindowProcessID);
            string focusedWindowProcessName = Process.GetProcessById((int)focusedWindowProcessID).ProcessName;
            if (windowName.ToString().Equals(WINDOW_NAME) && focusedWindowProcessName.Equals(WINDOW_NAME))
            {
                temtemWindow = focused;   
            }
            else
            {
                //We aren't in the right window
                return null;
            }

            IntPtr hdcWindow = User32.GetDC(temtemWindow);

            User32.RECT bounds = new User32.RECT();
            User32.POINT lpPoint = new User32.POINT();

            User32.GetClientRect(temtemWindow, out bounds);
            User32.ClientToScreen(temtemWindow, ref lpPoint);

            Bitmap bmp = new Bitmap(Math.Abs(bounds.right - bounds.left), Math.Abs(bounds.bottom - bounds.top));
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(lpPoint.X, lpPoint.Y, 0, 0, bmp.Size);
                g.Flush();
            }          

            //Release the device context
            User32.ReleaseDC(temtemWindow, hdcWindow);

            //bmp.Save(@"config\tmpScreenshot.png");

            return bmp;
        }

    }
}
