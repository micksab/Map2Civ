using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl;
using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationCtrl.ModelFileStorage;
using Map2CivilizationModel;
using Map2CivilizationView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Map2Civilization.Properties;

namespace Map2Civilization.Ctrl.ModelFileStorage
{
    class LoadModelProcessor : IDisposable
    {
        private BackgroundWorker _loadBackgroundWorker = new BackgroundWorker();

        private LoadModelProcessor()
        {
            _loadBackgroundWorker.WorkerReportsProgress = true;

            _loadBackgroundWorker.DoWork += LoadBackgroundWorker_DoWork;
            _loadBackgroundWorker.ProgressChanged += LoadBackgroundWorker_ProgressChanged;
            _loadBackgroundWorker.RunWorkerCompleted += LoadBackgroundWorker_RunWorkerCompleted;
        }

        private static LoadModelProcessor Singleton()
        {
            return new LoadModelProcessor();
        }

        public static void StartProcess(String fullFilePath)
        {
            RegisteredListenersCtrl.ProgressStarted();
            LoadModelProcessor processor = Singleton();
            processor._loadBackgroundWorker.RunWorkerAsync(fullFilePath);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        private void LoadBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            String fullFilePath = (String)e.Argument;
            DataSet theSet = ModelDataSet.GetModelEmptyDataSet();
            theSet.ReadXml(fullFilePath);

            decimal progressMaxValue = theSet.Tables["Global"].Rows.Count + theSet.Tables["Plot"].Rows.Count + theSet.Tables["Color"].Rows.Count;
            decimal counter = 0;


            
            DataModel newDataModel = new DataModel();
            newDataModel.ModelFile = fullFilePath;

            /**** Load 'Global' table values *****/
            // read the image of the original Bitmap 
            String originalImageString = (String)theSet.Tables["Global"].Rows[0]["DataSourceImage"];
            Bitmap originalImage = BitmapOperationsCtrl.getBitmapFromBase64String(originalImageString);
            Bitmap streamFreeImage = new Bitmap(originalImage.Width, originalImage.Height);
            //If we were to assign the originalImage instance at newDataMode.ImageToProcess, 
            // we would get a misleading "Out of Memory" exception on any method that would 
            // use its graphics, so we create a copy that is independent of the underlying stream 
            // used to load the image into the system. From more info check
            //https://social.msdn.microsoft.com/Forums/en-US/4aac43fa-cccb-4bf7-b37e-58ec5351ab80/outofmemoryexception-when-using-graphicsfromimage
            using (Graphics g = Graphics.FromImage(streamFreeImage))
            {
                g.DrawImageUnscaled(originalImage, 0, 0);
            }
            // read the size of the map
            MapDimension size = new MapDimension((string)theSet.Tables["Global"].Rows[0]["SelectedMapSize"]);
            newDataModel.SelectedMapSize = size;
            newDataModel.DataSourceImage = streamFreeImage;
            newDataModel.GridType = (GridType.Enumeration)theSet.Tables["Global"].Rows[0]["GridType"];
            newDataModel.MapDataSource = (MapDataSource.Enumeration) theSet.Tables["Global"].Rows[0]["MapDataSource"];
            newDataModel.CivilizationVersion = (CivilizationVersion.Enumeration)theSet.Tables["Global"].Rows[0]["CivilizationVersion"];



            counter++;
            _loadBackgroundWorker.ReportProgress((int)((counter / progressMaxValue) * 100));




            foreach (DataRow temp in theSet.Tables["Plot"].Rows)
            {
                string Id = (String)temp["Id"];
                TerrainType.Enumeration typeDescriptor = (TerrainType.Enumeration)temp["Terrain"];
                bool isLocked = (bool)temp["Locked"];
                String hexColor = (string)temp["Color"];

                switch (newDataModel.MapDataSource)
                {
                    case MapDataSource.Enumeration.ReliefMapImage:
                        PlotReliefMap plotToAdd = new PlotReliefMap(Id,
                        typeDescriptor, isLocked, hexColor);
                        newDataModel.PlotCollection.AddNewPlot(plotToAdd);
                        DetectedColor detColorToAdd = new DetectedColor(plotToAdd.HexDominantColor);
                        newDataModel.DetectedColorCollection.AddDetectedColor(detColorToAdd);
                        newDataModel.DetectedColorCollection.AddDetectedColorPlot(detColorToAdd, plotToAdd);
                        break;
                    case MapDataSource.Enumeration.GeoDataProvider:
                        throw new NotImplementedException("No implementation for Geo-Data Source Settings.");
                    default:
                        throw new InvalidEnumArgumentException("Non expected enumeration value.");
                }
                counter++;
                _loadBackgroundWorker.ReportProgress((int)((counter / progressMaxValue) * 100));
            }


            foreach (DataRow temp in theSet.Tables["Color"].Rows)
            {
                String ID = (String)temp["Id"];
                TerrainType.Enumeration ctd = (TerrainType.Enumeration)temp["Terrain"];
                newDataModel.DetectedColorCollection.UpdateDetectedColor(ID, ctd);
                counter++;
                _loadBackgroundWorker.ReportProgress((int)((counter / progressMaxValue) * 100));
            }
            e.Result = newDataModel;
            theSet.Dispose();
            originalImage.Dispose();

        }



        private void LoadBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int toReport = e.ProgressPercentage;
            RegisteredListenersCtrl.SetProgressPercent(toReport);
        }


        private void LoadBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {


                if (e.Error == null)
                {
                    
                    DataModel newModel = (DataModel)e.Result;
                    ModelCtrl.SetDataModel(newModel);
                    string currentFile = ModelCtrl.GetDataModel().ModelFile;
                    string displayableFilename = VariousUtilityMethods.ExtractDisplayableModelFilePath(currentFile);

                    RegisteredListenersCtrl.CentralFormPublishNewInfoMessage(Resources.Str_LoadModelProcessor_FileLoaded +
                        displayableFilename);
                    RegisteredListenersCtrl.CentralFormSetModelButtonAndMenusEnabledState(true, true);
                    RegisteredListenersCtrl.ModelListenersCurrentFileChanged(currentFile);
                }
                else
                {
                    throw e.Error;
                }
            }
            catch (Exception ex)
            {
                using (ErrorForm errorForm = new ErrorForm(true, Resources.Str_LoadModelProcessor_AsyncError, ex))
                {
                    errorForm.ShowDialog();
                }
            }
            finally
            {
                RegisteredListenersCtrl.SetProgressPercent(0);
                RegisteredListenersCtrl.ProgressFinished();
                Dispose();
            }



        }


        #region IDisposable interface implementation (for backgroundworker threads). 
        //Implementation of IDisposabe is needed because the worker instances are used on a non-UI class
        // that would normally take case itself of properly of disposing them.
        //http://stackoverflow.com/questions/2542326/proper-way-to-dispose-of-a-backgroundworker
        //https://msdn.microsoft.com/library/ms182172.aspx

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _loadBackgroundWorker.DoWork -= LoadBackgroundWorker_DoWork;
                _loadBackgroundWorker.Dispose();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1816:CallGCSuppressFinalizeCorrectly")]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
