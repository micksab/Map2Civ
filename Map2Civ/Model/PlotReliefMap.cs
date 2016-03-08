using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Map2CivilizationCtrl;

namespace Map2CivilizationModel
{
    class PlotReliefMap : Plot
    {
        private string _hexDominantColor;
        private Color _dominantColor;

       

        public PlotReliefMap(int plotX, int plotY, String hexDominantColor) : base(plotX, plotY)
        {
            _hexDominantColor = hexDominantColor;
            _dominantColor = BitmapOperationsCtrl.ColorFromHex(_hexDominantColor);
        }


        public PlotReliefMap(String id, TerrainType.Enumeration terrainDescriptor,
             Boolean isCustom, String hexColor) : base(id, terrainDescriptor, isCustom)
        {
            _hexDominantColor = hexColor;
            _dominantColor = BitmapOperationsCtrl.ColorFromHex(_hexDominantColor);
        }



        protected internal string HexDominantColor
        {
            get
            {
                return _hexDominantColor;
            }
            
        }

        public Color DominantColor
        {
            get
            {
                return _dominantColor;
            }
        }
    }
}
