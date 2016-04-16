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
using Map2CivilizationModel;
using System.Drawing;

namespace Map2CivilizationCtrl
{
    internal static class ModelCtrl
    {
        private static DataModel _dataModel;

        public static Bitmap GetProcessedBitmap()
        {
            if (_dataModel == null)
                return null;

            return _dataModel.ProcessedBitmap;
        }

        internal static DataModel GetDataModel()
        {
            return _dataModel;
        }

        public static MapDataSourceEnumWrapper.MapDataSource GetModelDataSourceType()
        {
            if (_dataModel != null)
            {
                return _dataModel.MapDataSource;
            }
            else
            {
                return MapDataSourceEnumWrapper.MapDataSource.ReliefMapImage;
            }
        }

       

        public static CivilizationVersionEnumWrapper.CivilizationVersion GetCivilizationVersion()
        {
            return _dataModel.CivilizationVersion;
        }

        public static string GetCurrentModelFile()
        {
            string toReturn = string.Empty;
            if (_dataModel != null)
            {
                toReturn = _dataModel.ModelFile;
            }

            return toReturn;
        }

        internal static void SetDataModel(DataModel newModel)
        {
            if (_dataModel != null)
            {
                _dataModel.Dispose();
            }

            _dataModel = newModel;

            TerrainTypeEnumWrapper.Singleton.GenerateTerrainBitmaps();
            RegisteredListenersCtrl.CentralFormUpdateAssignedPercentComplete();
            RegisteredListenersCtrl.ProcessedMapNotifyProcessedMapChanged(_dataModel.PlotCollection.PlotIds);
            RegisteredListenersCtrl.UpdateOriginalMap();
            RegisteredListenersCtrl.ModelListenersModelChanged();
            RegisteredListenersCtrl.DetectedColorsGridFill();
        }

        public static MapDimension GetMapSize()
        {
            return _dataModel.SelectedMapSize;
        }

        public static GridTypeEnumWrapper.GridType GetGridType()
        {
            return _dataModel.GridType;
        }

        /// <summary>
        /// Function that returns the width of a plot (in Pixels) for an initialized model
        /// </summary>
        /// <returns>The width of the plot (Pixels)</returns>
        public static float GetPlotWidthPixels()
        {
            return GridTypeEnumWrapper.Singleton.GetPlotWidthPixels(_dataModel.GridType);
        }

        /// <summary>
        /// Function that returns the height of a plot (in Pixels) for an initialized model
        /// </summary>
        /// <returns>The height of the plot (Pixels)</returns>
        public static float GetPlotHeightPixels()
        {
            return GridTypeEnumWrapper.Singleton.GetPlotHeightPixels(_dataModel.GridType);
        }

        

        public static Bitmap GetDataSourceAdjustedImageWithGrid()
        {
            Bitmap toReturn = BitmapOperationsCtrl.SafeCloneStreamBasedBitmap(_dataModel.ReliefMapSettings.AdjustedMapBitmap);

            if (toReturn != null)
            {
                toReturn = BitmapOperationsCtrl.DrawGridLines(toReturn);
            }

            return toReturn;
        }

        public static double GetAssignedPercentComplete()
        {
            return _dataModel.PlotCollection.AssignedPercent;
        }
    }
}