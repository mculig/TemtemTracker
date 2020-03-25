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

        public static Bitmap GetTemtemWindowScreenshot()
        {
            //Pointer to the Temtem Window
            IntPtr temtemWindow;

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
            User32.GetWindowThreadProcessId(focused, out uint focusedWindowProcessID); //Inline variable declaration
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

            User32.POINT lpPoint = new User32.POINT();

            User32.GetClientRect(temtemWindow, out User32.RECT bounds);
            User32.ClientToScreen(temtemWindow, ref lpPoint);

            Bitmap bmp = new Bitmap((bounds.right - bounds.left), (bounds.bottom - bounds.top));
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(lpPoint.X, lpPoint.Y, 0, 0, bmp.Size);
                g.Flush();
            }          

            //Release the device context
            User32.ReleaseDC(temtemWindow, hdcWindow);


            return bmp;
        }

    }
}
