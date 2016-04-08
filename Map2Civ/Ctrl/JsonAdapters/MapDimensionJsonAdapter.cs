using Map2CivilizationCtrl.DataStructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Map2CivilizationCtrl.JsonAdapters
{
    class MapDimensionJsonAdapter
    {
        string _description;
        int _widthPlots;
        int _heightPlots;
        bool _isDefault;

        #region public properties

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


        #endregion

        public MapDimensionJsonAdapter(MapDimension dimension)
        {
            _description = dimension.Description;
            _widthPlots = dimension.WidthPlots;
            _heightPlots = dimension.HeightPlots;
            _isDefault = dimension.IsDefault;
        }


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
