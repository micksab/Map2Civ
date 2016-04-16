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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        private SourceGeoDataSettings _geoDataSettings;
        private Bitmap _processedBitmap;
        private GridTypeEnumWrapper.GridType _gridType;
        private MapDataSourceEnumWrapper.MapDataSource _mapDataSource;
        private CivilizationVersionEnumWrapper.CivilizationVersion _civilizationVersion;
        private PlotList _plotCollection = new PlotList();
        private DetectedColorList _detectedColorCollection = new DetectedColorList();

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
        public DataModel(MapDimension mapDimension, GridTypeEnumWrapper.GridType gridType, MapDataSourceEnumWrapper.MapDataSource mapDataSource,
            CivilizationVersionEnumWrapper.CivilizationVersion civilizationVersion, SourceReliefMapSettings reliefSettings)
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

        internal DetectedColorList DetectedColorCollection
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

        public GridTypeEnumWrapper.GridType GridType
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

        public CivilizationVersionEnumWrapper.CivilizationVersion CivilizationVersion
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

        public MapDataSourceEnumWrapper.MapDataSource MapDataSource
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
                return _geoDataSettings;
            }

            set
            {
                _geoDataSettings = value;
            }
        }

        public PlotList PlotCollection
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