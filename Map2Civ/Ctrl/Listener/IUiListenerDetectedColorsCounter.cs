using System;
using System.Collections.Generic;

using System.Text;


namespace Map2CivilizationCtrl.Listener
{
    public interface IUiListenerDetectedColorsCounter : IUiListener
    {
        void UpdateColorListCount(int count);
    }
}
