using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TemtemTracker.Controllers
{
    class UnhandledExceptionHandler
    {

        private static readonly string exceptionOutputFile = @"crashLog.txt";

        public static void HandleUnhandledException(object source, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            using(System.IO.StreamWriter output = new StreamWriter(exceptionOutputFile))
            {
                output.WriteLine("[EXCEPTION][" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "]: " +e.Message);
            }
        }

        public static void HandleUnhandledThreadException(object sender, ThreadExceptionEventArgs e)
        {
            using (System.IO.StreamWriter output = new StreamWriter(exceptionOutputFile))
            {
                output.WriteLine("[EXCEPTION][" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "]: " + e.Exception.Message);
            }
        }
    }
}
