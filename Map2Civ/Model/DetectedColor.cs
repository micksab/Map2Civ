/************************************************************************************/
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

using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Enumerations;
using System.Collections.Generic;

namespace Map2CivilizationModel
{
    public class DetectedColor
    {
        private string _colorHex;
        private TerrainTypeEnumWrapper.TerrainType _terrainDescriptor;
        private readonly List<Plot> _relevantPlots;

        public string ColorHex
        {
            get
            {
                return _colorHex;
            }

            set
            {
                _colorHex = value;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public List<Plot> RelevantPlots
        {
            get
            {
                return _relevantPlots;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public List<PlotId> RelevantPlotIds
        {
            get
            {
                List<PlotId> toReturn = new List<PlotId>();

                foreach (Plot plot in _relevantPlots)
                {
                    toReturn.Add(plot.Id);
                }

                return toReturn;
            }
        }

        public TerrainTypeEnumWrapper.TerrainType TerrainDescriptor
        {
            get
            {
                return _terrainDescriptor;
            }
        }

        public DetectedColor(string colorHexValue)
        {
            _colorHex = colorHexValue;
            _terrainDescriptor = TerrainTypeEnumWrapper.TerrainType.NotDefined;
            _relevantPlots = new List<Plot>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="hexColor">The string representation of the color (eg. #99CCFF) </param>
        /// <param name="terrainDescriptor">The terrain value assigned to the color</param>
        public DetectedColor(string hexColor, TerrainTypeEnumWrapper.TerrainType terrainDescriptor)
        {
            _colorHex = hexColor;
            _terrainDescriptor = terrainDescriptor;
            _relevantPlots = new List<Plot>();
        }

        public void UpdateDetectedColor(TerrainTypeEnumWrapper.TerrainType terrainDescriptor)
        {
            _terrainDescriptor = terrainDescriptor;
            UpdateRelevantPlots();
        }

        public void AddRelevantPlot(Plot plot)
        {
            if (!_relevantPlots.Contains(plot))
            {
                _relevantPlots.Add(plot);
            }
        }

        private void UpdateRelevantPlots()
        {
            foreach (Plot plot in _relevantPlots)
            {
                if (!plot.IsLocked)
                {
                    plot.UpdatePlot(_terrainDescriptor, false);
                }
            }
        }
    }
}