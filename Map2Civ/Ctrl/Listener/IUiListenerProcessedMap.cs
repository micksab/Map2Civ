using System;
using System.Collections.Generic;

using System.Text;

using System.Drawing;

using Map2CivilizationCtrl.DataStructure;
using System.Collections.ObjectModel;

namespace Map2CivilizationCtrl.Listener
{
    public interface IUiListenerProcessedMap : IUiListener
    {

        
        void GetProcessedMap(Bitmap image);
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        void ShowSelectedColorsPlots(List<PlotId> plotCoordinatePairs);


    }
}
