using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemtemTracker.Controllers
{
    public class ErrorMessage
    {
        public delegate void CallbackFunction();

        public ErrorMessage(string errorText, CallbackFunction callback)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result = MessageBox.Show(errorText, "Error", buttons, MessageBoxIcon.Error);
            if(result == System.Windows.Forms.DialogResult.OK)
            {
                callback?.Invoke();
            }
        }
    }
}
