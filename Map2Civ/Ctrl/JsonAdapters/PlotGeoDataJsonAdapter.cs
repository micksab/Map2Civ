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
using System;

namespace Map2CivilizationCtrl.JsonAdapters
{
    internal class PlotGeoDataJsonAdapter
    {
        private string _id;
        private TerrainTypeEnumWrapper.TerrainType _terrainDescriptor = TerrainTypeEnumWrapper.TerrainType.NotDefined;
        private bool _isLocked = false;

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

        #endregion public properties

        public PlotGeoDataJsonAdapter(PlotGeoData plot)
        {
            _id = plot.Id.Name;
            _terrainDescriptor = plot.TerrainDescriptor;
            _isLocked = plot.IsLocked;

            throw new NotImplementedException();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [JsonConstructor]
        public PlotGeoDataJsonAdapter(string id, TerrainTypeEnumWrapper.TerrainType td, bool lc)
        {
            _id = id;
            _terrainDescriptor = td;
            _isLocked = lc;
        }

        public PlotGeoData GetPlotGeoData()
        {
            return new PlotGeoData(_id, _terrainDescriptor, _isLocked);
        }
    }
}