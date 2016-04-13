using Map2CivilizationCtrl.DataStructure;
using System.Collections.Generic;
using System.Drawing;

namespace Map2CivilizationCtrl.Listener
{
    public interface IUiListenerProcessedMap : IUiListener
    {
        void GetProcessedMap(Bitmap image);

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        void ShowSelectedColorsPlots(List<PlotId> plotCoordinatePairs);
    }
}