using System;
using System.Drawing;
using Map2CivilizationCtrl;
using Map2CivilizationCtrl.Enumerations;

namespace Map2CivilizationModel
{
    class PlotReliefMap : Plot
    {
        readonly string _hexDominantColor;
        readonly Color _dominantColor;

       

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
