using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationModel;
using Newtonsoft.Json;

namespace Map2CivilizationCtrl.JsonAdapters
{
    internal class DetectedColorJsonAdapter
    {
        private string _colorHex;
        private TerrainType.Enumeration _terrainDescriptor;

        #region public properties

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
        [JsonConstructor]
        public DetectedColorJsonAdapter(string cx, TerrainType.Enumeration td)
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