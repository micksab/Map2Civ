using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Map2CivilizationCtrl.JsonAdapters
{
    class PlotGeoDataJsonAdapter
    {
        string _id;
        TerrainType.Enumeration _terrainDescriptor = TerrainType.Enumeration.NotDefined;
        bool _isLocked = false;


        #region public properties

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

        [JsonProperty("td")]
        public TerrainType.Enumeration TerrainDescriptor
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


        #endregion

        public PlotGeoDataJsonAdapter(PlotGeoData plot)
        {
            _id = plot.Id.Name;
            _terrainDescriptor = plot.TerrainDescriptor;
            _isLocked = plot.IsLocked;

            throw new NotImplementedException();
        }

        [JsonConstructor]
        public PlotGeoDataJsonAdapter(string id, TerrainType.Enumeration td, bool lc)
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
