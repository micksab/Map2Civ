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
    internal class PlotReliefMapJsonAdapter
    {
        private string _id;
        private TerrainTypeEnumWrapper.TerrainType _terrainDescriptor = TerrainTypeEnumWrapper.TerrainType.NotDefined;
        private bool _isLocked = false;
        private readonly string _hexDominantColor;

        #region public properties

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [JsonProperty("id")]
        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [JsonProperty("lc")]
        public bool IsLocked
        {
            get
            {
                return _isLocked;
            }

            set
            {
                _isLocked = value;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [JsonProperty("dc")]
        public string HexDominantColor
        {
            get
            {
                return _hexDominantColor;
            }
        }

        #endregion public properties

        /// <summary>
        /// Constructor used to transform a PlotReliefMap instance to PlotReliefMapJsonAdapter
        /// </summary>
        /// <param name="plot"></param>
        public PlotReliefMapJsonAdapter(PlotReliefMap plot)
        {
            _id = plot.Id.Name;
            _terrainDescriptor = plot.TerrainDescriptor;
            _isLocked = plot.IsLocked;
            _hexDominantColor = plot.HexDominantColor;
        }

        /// <summary>
        /// Constructor used to facilitate Json deserialization
        /// </summary>
        /// <param name="id"></param>
        /// <param name="td"></param>
        /// <param name="lc"></param>
        /// <param name="dc"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [JsonConstructor]
        public PlotReliefMapJsonAdapter(string id, TerrainTypeEnumWrapper.TerrainType td, bool lc, string dc)
        {
            _id = id;
            _terrainDescriptor = td;
            _isLocked = lc;
            _hexDominantColor = dc;
        }

        public PlotReliefMap GetPlotReliefMap()
        {
            return new PlotReliefMap(_id, _terrainDescriptor, _isLocked, _hexDominantColor);
        }
    }
}