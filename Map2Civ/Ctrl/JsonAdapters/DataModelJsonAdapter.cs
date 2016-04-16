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
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Map2CivilizationCtrl.JsonAdapters
{
    internal class DataModelJsonAdapter
    {
        private MapDimensionJsonAdapter _mapSize;
        private MapDataSourceEnumWrapper.MapDataSource _mapDataSourceType;
        private SourceReliefMapSettingsJsonAdapter _reliefMapSettings;
        private SourceGeoDataSettingsJsonAdapter _geoDataSettings;
        private GridTypeEnumWrapper.GridType _gridType;
        private CivilizationVersionEnumWrapper.CivilizationVersion _civilizationVersion;
        private PlotReliefMapJsonAdapter[] _reliefPlotArray = new PlotReliefMapJsonAdapter[0];
        private PlotGeoDataJsonAdapter[] _geoDataPlotArray = new PlotGeoDataJsonAdapter[0];
        private DetectedColorJsonAdapter[] _detectedColorArray = new DetectedColorJsonAdapter[0];

        #region public properties

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [JsonProperty("mapSize")]
        public MapDimensionJsonAdapter MapSize
        {
            get
            {
                return _mapSize;
            }

            set
            {
                _mapSize = value;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [JsonProperty("mapDataSource")]
        public MapDataSourceEnumWrapper.MapDataSource MapDataSourceType
        {
            get
            {
                return _mapDataSourceType;
            }

            set
            {
                _mapDataSourceType = value;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [JsonProperty("reliefSettings")]
        public SourceReliefMapSettingsJsonAdapter ReliefMapSettings
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [JsonProperty("geoSettings")]
        public SourceGeoDataSettingsJsonAdapter GeoDataSettings
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [JsonProperty("gridType")]
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [JsonProperty("civVersion")]
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [JsonProperty("reliefPlots")]
        public PlotReliefMapJsonAdapter[] ReliefPlotArray
        {
            get
            {
                return _reliefPlotArray;
            }

            set
            {
                _reliefPlotArray = value;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [JsonProperty("geoPlots")]
        public PlotGeoDataJsonAdapter[] GeoDataPlotArray
        {
            get
            {
                return _geoDataPlotArray;
            }

            set
            {
                _geoDataPlotArray = value;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [JsonProperty("colors")]
        public DetectedColorJsonAdapter[] DetectedColorArray
        {
            get
            {
                return _detectedColorArray;
            }

            set
            {
                _detectedColorArray = value;
            }
        }

        #endregion public properties

        public DataModelJsonAdapter(DataModel dataModel)
        {
            _mapSize = new MapDimensionJsonAdapter(dataModel.SelectedMapSize);
            _mapDataSourceType = dataModel.MapDataSource;
            _reliefMapSettings = new SourceReliefMapSettingsJsonAdapter(dataModel.ReliefMapSettings);
            _geoDataSettings = new SourceGeoDataSettingsJsonAdapter(dataModel.GeoDataSettings);
            _gridType = dataModel.GridType;
            _civilizationVersion = dataModel.CivilizationVersion;

            //Populate the appropriate plot array depending on the MapDataSource value
            Plot[] plotsArray = dataModel.PlotCollection.Plots.ToArray();
            if (_mapDataSourceType == MapDataSourceEnumWrapper.MapDataSource.ReliefMapImage)
            {
                _reliefPlotArray = new PlotReliefMapJsonAdapter[plotsArray.Length];
                for (int i = 0; i < plotsArray.Length; i++)
                {
                    _reliefPlotArray[i] = new PlotReliefMapJsonAdapter((PlotReliefMap)plotsArray[i]);
                }
            }
            else if (_mapDataSourceType == MapDataSourceEnumWrapper.MapDataSource.GeoDataProvider)
            {
                _geoDataPlotArray = new PlotGeoDataJsonAdapter[plotsArray.Length];
                for (int i = 0; i < plotsArray.Length; i++)
                {
                    _geoDataPlotArray[i] = new PlotGeoDataJsonAdapter((PlotGeoData)plotsArray[i]);
                }
            }

            //Add any detected colors
            List<DetectedColor> colorCollection = dataModel.DetectedColorCollection.DetectedColors;
            _detectedColorArray = new DetectedColorJsonAdapter[colorCollection.Count];
            for (int i = 0; i < colorCollection.Count; i++)
            {
                _detectedColorArray[i] = new DetectedColorJsonAdapter(colorCollection[i]);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [JsonConstructor]
        public DataModelJsonAdapter(MapDimensionJsonAdapter mapSize, MapDataSourceEnumWrapper.MapDataSource mapDataSource,
            SourceReliefMapSettingsJsonAdapter reliefSettings, SourceGeoDataSettingsJsonAdapter geoSettings,
            GridTypeEnumWrapper.GridType gridType, CivilizationVersionEnumWrapper.CivilizationVersion civVersion,
            PlotReliefMapJsonAdapter[] reliefPlots, PlotGeoDataJsonAdapter[] geoPlots, DetectedColorJsonAdapter[] colors)
        {
            _mapSize = mapSize;
            _mapDataSourceType = mapDataSource;
            _reliefMapSettings = reliefSettings;
            _geoDataSettings = geoSettings;
            _gridType = gridType;
            _civilizationVersion = civVersion;
            _reliefPlotArray = reliefPlots;
            _geoDataPlotArray = geoPlots;
            _detectedColorArray = colors;
        }
    }
}