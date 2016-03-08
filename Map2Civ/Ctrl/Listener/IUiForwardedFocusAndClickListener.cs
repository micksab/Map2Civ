using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Map2CivilizationCtrl.Listener
{
    public interface IUiForwardedFocusAndClickListener
    {
        void ReceiveFocusAndClickEvent(MouseEventArgs e);
    }
}
