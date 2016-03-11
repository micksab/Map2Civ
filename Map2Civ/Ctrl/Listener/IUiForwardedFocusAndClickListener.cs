using System.Windows.Forms;

namespace Map2CivilizationCtrl.Listener
{
    public interface IUiForwardedFocusAndClickListener
    {
        void ReceiveFocusAndClickEvent(MouseEventArgs e);
    }
}
