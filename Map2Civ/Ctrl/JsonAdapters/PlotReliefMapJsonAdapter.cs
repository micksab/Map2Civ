using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Map2CivilizationCtrl.JsonAdapters
{
    class PlotReliefMapJsonAdapter
    {
        string _id;
        TerrainType.Enumeration _terrainDescriptor = TerrainType.Enumeration.NotDefined;
        bool _isLocked = false;
        readonly string _hexDominantColor;


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

        [JsonProperty("dc")]
        public string HexDominantColor
        {
            get
            {
                return _hexDominantColor;
            }
        }

        #endregion

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
        [JsonConstructor]
        public PlotReliefMapJsonAdapter(string id, TerrainType.Enumeration td, bool lc, string dc)
        {
            _id = id;
            _terrainDescriptor = td;
            _isLocked = lc;
            _hexDominantColor= dc;
        }


        

        public PlotReliefMap GetPlotReliefMap()
        {
            return new PlotReliefMap(_id, _terrainDescriptor, _isLocked, _hexDominantColor);
        }

    }


   
}
