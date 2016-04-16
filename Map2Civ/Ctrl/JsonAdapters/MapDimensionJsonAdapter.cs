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
using Newtonsoft.Json;

namespace Map2CivilizationCtrl.JsonAdapters
{
    internal class MapDimensionJsonAdapter
    {
        private string _description;
        private int _widthPlots;
        private int _heightPlots;
        private bool _isDefault;

        #region public properties

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [JsonProperty("description")]
        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [JsonProperty("width")]
        public int WidthPlots
        {
            get
            {
                return _widthPlots;
            }

            set
            {
                _widthPlots = value;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [JsonProperty("height")]
        public int HeightPlots
        {
            get
            {
                return _heightPlots;
            }

            set
            {
                _heightPlots = value;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [JsonProperty("isDefault")]
        public bool IsDefault
        {
            get
            {
                return _isDefault;
            }

            set
            {
                _isDefault = value;
            }
        }

        #endregion public properties

        public MapDimensionJsonAdapter(MapDimension dimension)
        {
            _description = dimension.Description;
            _widthPlots = dimension.WidthPlots;
            _heightPlots = dimension.HeightPlots;
            _isDefault = dimension.IsDefault;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [JsonConstructor]
        public MapDimensionJsonAdapter(string description, int width, int height, bool isDefault)
        {
            _description = description;
            _widthPlots = width;
            _heightPlots = height;
            _isDefault = isDefault;
        }

        public MapDimension GetMapDimension()
        {
            return new MapDimension(_description, _widthPlots, _heightPlots, _isDefault);
        }
    }
}