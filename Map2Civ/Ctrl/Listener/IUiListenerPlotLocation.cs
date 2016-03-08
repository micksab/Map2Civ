using System;
using System.Collections.Generic;

using System.Text;

using System.Windows.Forms;
using Map2CivilizationCtrl.Listener;
using Map2CivilizationCtrl.DataStructure;

namespace Map2CivilizationCtrl.Listener
{
    public interface IUiListenerPlotLocation : IUiListener
    {
        void UpdatePlotLocation(PlotId id);
        

    }
}
