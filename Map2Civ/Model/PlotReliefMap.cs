using Map2CivilizationCtrl;
using Map2CivilizationCtrl.Enumerations;
using System;
using System.Drawing;

namespace Map2CivilizationModel
{
    public class PlotReliefMap : Plot
    {
        private readonly string _hexDominantColor;
        private readonly Color _dominantColor;

        public PlotReliefMap(int plotX, int plotY, string hexDominantColor) : base(plotX, plotY)
        {
            _hexDominantColor = hexDominantColor;
            _dominantColor = BitmapOperationsCtrl.ColorFromHex(_hexDominantColor);
        }

        public PlotReliefMap(string id, TerrainType.Enumeration terrainDescriptor,
             Boolean isLocked, string dominantColor) : base(id, terrainDescriptor, isLocked)
        {
            _hexDominantColor = dominantColor;
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