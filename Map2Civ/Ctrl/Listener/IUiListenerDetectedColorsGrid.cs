using System;
using System.Collections.Generic;

using System.Text;


namespace Map2CivilizationCtrl.Listener
{
    public interface IUiListenerDetectedColorsGrid : IUiListener
    {
        void SetSelectedColor(String colorId);
        void UpdateColorsGrid();
        void FillColorGrid();
    }
}
