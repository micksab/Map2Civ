using System;


namespace Map2CivilizationCtrl.Listener
{
    public interface IUiListenerDetectedColorsGrid : IUiListener
    {
        void SetSelectedColor(String colorId);
        void UpdateColorsGrid();
        void FillColorGrid();
    }
}
