using System;
using System.Drawing;
using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationModel;

namespace Map2CivilizationCtrl
{
    static class ModelCtrl
    {

        
        private static DataModel _dataModel;



        internal static DataModel GetDataModel()
        {
            if(_dataModel == null)
            {
                _dataModel = new DataModel();
            }
           
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


        public static CivilizationVersion.Enumeration GetCivilizationVersion()
        {
            return _dataModel.CivilizationVersion;
        }


        public static String GetCurrentModelFile()
        {
            String toReturn = String.Empty;
            if (_dataModel != null)
            {
                toReturn = _dataModel.ModelFile;
            }

            return toReturn;
        }



        internal static void SetDataModel(DataModel newModel)
        {
            _dataModel = newModel;

            TerrainType.Singleton.GenerateTerrainBitmaps();
            RegisteredListenersCtrl.CentralFormUpdateAssignedPercentComplete();
            RegisteredListenersCtrl.ProcessedMapNotifyProcessedMapChanged();
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


        public static Bitmap GetDataSourceImage()
        {
            Bitmap toReturn = _dataModel.DataSourceImage;
            return toReturn;
        }


        public static Bitmap GetDataSourceImageWithGrid()
        {
            Bitmap toReturn = _dataModel.DataSourceImage;
            
            if (toReturn != null)
            {
                toReturn = BitmapOperationsCtrl.DrawGridLines(toReturn);
            }
           
            return toReturn;
        }


        public static double GetAssignedPercentComplete()
        {
            return _dataModel.PlotCollection.getAssignedPercentComplete();
        }




       



        



























    }
}
