﻿/************************************************************************************/
//
//      This file is part of Map2Civilization.
//      Map2Civilization is free software: you can redistribute it and/or modify
//      it under the terms of the GNU General Public License as published by
//      the Free Software Foundation, either version 3 of the License, or
//      (at your option) any later version.
//
//      Map2Civilization is distributed in the hope that it will be useful,
//      but WITHOUT ANY WARRANTY; without even the implied warranty of
//      MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//      GNU General Public License for more details.
//
//      You should have received a copy of the GNU General Public License
//      along with Map2Civilization.  If not, see http://www.gnu.org/licenses/.
//
/************************************************************************************/


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

        public PlotReliefMap(string id, TerrainTypeEnumWrapper.TerrainType terrainDescriptor,
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