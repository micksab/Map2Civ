using Map2CivilizationCtrl.Analyzer;
using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Enumerations;
using System;
using System.Drawing;

namespace Map2CivilizationModel
{
    public sealed class DataModel : IDisposable
    {
        private MapDimension _selectedMapSize;
        private SourceReliefMapSettings _reliefMapSettings;
        private SourceGeoDataSettings _geoDataSettings;
        private Bitmap _processedBitmap;
        private GridType.Enumeration _gridType;
        private MapDataSource.Enumeration _mapDataSource;
        private CivilizationVersion.Enumeration _civilizationVersion;
        private Plots _plotCollection = new Plots();
        private DetectedColors _detectedColorCollection = new DetectedColors();

        private string _modelFile = string.Empty;

        public DataModel()
        {
        }

        /// <summary>
        /// Model constructor intented to be used when it is based on a relief map image
        /// </summary>
        /// <param name="mapDimension">The dimension of the model to be created</param>
        /// <param name="gridType">The type of grid applied to the model</param>
        /// <param name="mapDataSource">The type of source for the map to be created</param>
        /// <param name="civilizationVersion">The intended (to be exported) version of Civilization map</param>
        /// <param name="reliefSettings">The settings based upon which the analysis of the source image is
        /// to be performed.</param>
        public DataModel(MapDimension mapDimension, GridType.Enumeration gridType, MapDataSource.Enumeration mapDataSource,
            CivilizationVersion.Enumeration civilizationVersion, SourceReliefMapSettings reliefSettings)
        {
            _selectedMapSize = mapDimension;
            _reliefMapSettings = reliefSettings;
            _gridType = gridType;
            _mapDataSource = mapDataSource;
            _civilizationVersion = civilizationVersion;
        }

        public MapDimension SelectedMapSize
        {
            set
            {
                _selectedMapSize = value;
            }
            get
            {
                return _selectedMapSize;
            }
        }

        internal DetectedColors DetectedColorCollection
        {
            get
            {
                return _detectedColorCollection;
            }
        }

        public string ModelFile
        {
            get
            {
                return _modelFile;
            }

            set
            {
                _modelFile = value;
            }
        }

        public GridType.Enumeration GridType
        {
            get
            {
                return _gridType;
            }

            set
            {
                _gridType = value;
            }
        }

        public CivilizationVersion.Enumeration CivilizationVersion
        {
            get
            {
                return _civilizationVersion;
            }

            set
            {
                _civilizationVersion = value;
            }
        }

        public MapDataSource.Enumeration MapDataSource
        {
            get
            {
                return _mapDataSource;
            }

            set
            {
                _mapDataSource = value;
            }
        }

        public Bitmap ProcessedBitmap
        {
            get
            {
                return _processedBitmap;
            }
            set
            {
                _processedBitmap = value;
            }
        }

        internal SourceReliefMapSettings ReliefMapSettings
        {
            get
            {
                return _reliefMapSettings;
            }

            set
            {
                _reliefMapSettings = value;
            }
        }

        internal SourceGeoDataSettings GeoDataSettings
        {
            get
            {
                return null;
                //throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Plots PlotCollection
        {
            get
            {
                return _plotCollection;
            }
        }

        public void Dispose()
        {
            _reliefMapSettings.Dispose();
            _processedBitmap.Dispose();
        }
    }
}