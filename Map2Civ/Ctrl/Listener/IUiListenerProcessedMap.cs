using System.Collections.Generic;

using System.Drawing;

using Map2CivilizationCtrl.DataStructure;

namespace Map2CivilizationCtrl.Listener
{
    public interface IUiListenerProcessedMap : IUiListener
    {

        
        void GetProcessedMap(Bitmap image);
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        void ShowSelectedColorsPlots(List<PlotId> plotCoordinatePairs);


    }
}
