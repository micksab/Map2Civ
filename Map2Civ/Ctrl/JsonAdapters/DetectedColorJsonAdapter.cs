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


using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationModel;
using Newtonsoft.Json;

namespace Map2CivilizationCtrl.JsonAdapters
{
    internal class DetectedColorJsonAdapter
    {
        private string _colorHex;
        private TerrainTypeEnumWrapper.TerrainType _terrainDescriptor;

        #region public properties

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [JsonProperty("cx")]
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [JsonProperty("td")]
        public TerrainTypeEnumWrapper.TerrainType TerrainDescriptor
        {
            get
            {
                return _terrainDescriptor;
            }

            set
            {
                _terrainDescriptor = value;
            }
        }

        #endregion public properties

        public DetectedColorJsonAdapter(DetectedColor color)
        {
            _colorHex = color.ColorHex;
            _terrainDescriptor = color.TerrainDescriptor;
        }

        /// <summary>
        /// Constructor used to facilitate Json deserialization
        /// </summary>
        /// <param name="cx"></param>
        /// <param name="td"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [JsonConstructor]
        public DetectedColorJsonAdapter(string cx, TerrainTypeEnumWrapper.TerrainType td)
        {
            _colorHex = cx;
            _terrainDescriptor = td;
        }

        public DetectedColor GetDetectedColor()
        {
            return new DetectedColor(_colorHex, _terrainDescriptor);
        }
    }
}