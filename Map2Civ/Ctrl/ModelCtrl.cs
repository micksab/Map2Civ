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

        public static MapDataSource.Enumeration GetModelDataSourceType()
        {
            if (_dataModel != null)
            {
                return _dataModel.MapDataSource;
            }
            else
            {
                return MapDataSource.Enumeration.ReliefMapImage;
            }
        }

        public static SourceReliefMapSettings GetReliefMapSettings()
        {
            return _dataModel.ReliefMapSettings;
        }

        public static CivilizationVersion.Enumeration GetCivilizationVersion()
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

            TerrainType.Singleton.GenerateTerrainBitmaps();
            RegisteredListenersCtrl.CentralFormUpdateAssignedPercentComplete();
            RegisteredListenersCtrl.ProcessedMapNotifyProcessedMapChanged(_dataModel.PlotCollection.GetPlotIds());
            RegisteredListenersCtrl.UpdateOriginalMap();
            RegisteredListenersCtrl.ModelListenersModelChanged();
            RegisteredListenersCtrl.DetectedColorsGridFill();
        }

        public static MapDimension GetMapSize()
        {
            return _dataModel.SelectedMapSize;
        }

        public static GridType.Enumeration GetGridType()
        {
            return _dataModel.GridType;
        }

        /// <summary>
        /// Function that returns the width of a plot (in Pixels) for an initialized model
        /// </summary>
        /// <returns>The width of the plot (Pixels)</returns>
        public static float GetPlotWidthPixels()
        {
            return GridType.Singleton.GetPlotWidthPixels(_dataModel.GridType);
        }

        /// <summary>
        /// Function that returns the height of a plot (in Pixels) for an initialized model
        /// </summary>
        /// <returns>The height of the plot (Pixels)</returns>
        public static float GetPlotHeightPixels()
        {
            return GridType.Singleton.GetPlotHeightPixels(_dataModel.GridType);
        }

        public static Bitmap GetDataSourceEditedImage()
        {
            return _dataModel.ReliefMapSettings.AdjustedMapBitmap;
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
            return _dataModel.PlotCollection.GetAssignedPercentComplete();
        }
    }
}