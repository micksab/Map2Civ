using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Map2CivilizationView.UserControls
{
    public static class CultureAwareMessageBox 
    {
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, 
            MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            MessageBoxOptions options = MessageBoxOptions.ServiceNotification;

            if (System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.IsRightToLeft)
            {
                options |= MessageBoxOptions.RtlReading |
                MessageBoxOptions.RightAlign;
            }

            DialogResult result = MessageBox.Show(text, caption, buttons, icon, defaultButton, options);

            return result;
        }
    }
}
