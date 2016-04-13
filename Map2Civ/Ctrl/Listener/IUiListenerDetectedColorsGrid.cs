namespace Map2CivilizationCtrl.Listener
{
    public interface IUiListenerDetectedColorsGrid : IUiListener
    {
        void SetSelectedColor(string colorId);

        void UpdateColorsGrid();

        void FillColorGrid();
    }
}