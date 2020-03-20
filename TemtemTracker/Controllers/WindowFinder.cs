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
        private static readonly int WS_MINIMIZE = 0x20000000;
        private static readonly string WINDOW_NAME = "Temtem";

        public WindowFinder()
        {
            
        }

        public static Bitmap getTemtemWindowScreenshot()
        {
            //Get the game window
            IntPtr temtemWindow = User32.FindWindow(null, WINDOW_NAME);

            if (temtemWindow == null)
            {
                //If we can't find Temtem, we return null
                return null;
            }

            User32.WINDOWINFO info = new User32.WINDOWINFO();
            User32.GetWindowInfo(temtemWindow, ref info);

            if((info.dwStyle & WS_MINIMIZE) == WS_MINIMIZE)
            {
                //Window is minimized, return null
                return null;
            }

            IntPtr focused = User32.GetForegroundWindow();

            if(focused!=null && !focused.Equals(temtemWindow))
            {
                //The focused window isn't Temtem
                return null;
            }

            //Check that we didn't catch a wrong process with a similar window name
            uint processID;
            User32.GetWindowThreadProcessId(temtemWindow, out processID);
            Process foundProcess = Process.GetProcessById(unchecked((int)processID));
            if(foundProcess.ProcessName != WINDOW_NAME)
            {
                Console.WriteLine("Found wrong process: " + foundProcess.MainWindowTitle);
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
