using Map2CivilizationCtrl.DataStructure;

namespace Map2CivilizationCtrl.Listener
{
    public interface IUiListenerPlotLocation : IUiListener
    {
        void UpdatePlotLocation(PlotId id);
    }
}