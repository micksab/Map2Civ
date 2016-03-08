using Map2CivilizationCtrl.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Map2CivilizationCtrl.Listener
{
    interface IUiListenerZoom : IUiListener
    {
        void ZoomChanged(float value);
    }
}
