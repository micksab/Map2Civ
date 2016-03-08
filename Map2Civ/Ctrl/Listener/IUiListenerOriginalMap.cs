using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;

namespace Map2CivilizationCtrl.Listener
{
    public interface IUiListenerOriginalMap : IUiListener
    {

         void ReloadMap(Bitmap bmp);

    }
}
