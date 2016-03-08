using Map2Civilization.Properties;
using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationModel;
using Map2CivilizationView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace Map2CivilizationCtrl.ModelFileStorage
{
    class SaveModelProcessor : IDisposable
    {
        private BackgroundWorker _saveBackgroundWorker = new BackgroundWorker();

        private SaveModelProcessor()
        {
            _saveBackgroundWorker.WorkerReportsProgress = true;

            _saveBackgroundWorker.DoWork += SaveBackgroundWorker_DoWork;
            _saveBackgroundWorker.ProgressChanged += SaveBackgroundWorker_ProgressChanged;
            _saveBackgroundWorker.RunWorkerCompleted += SaveBackgroundWorker_RunWorkerCompleted;
        }

        private static SaveModelProcessor Singleton()
        {
            return new SaveModelProcessor();
        }

        public static void StartProcess(String fullFilePath)
        {
            RegisteredListenersCtrl.ProgressStarted();
            SaveModelProcessor processor = Singleton();
            processor._saveBackgroundWorker.RunWorkerAsync(fullFilePath);
        }


        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling")]
        private void SaveBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            String fullFilePath = (String)e.Argument;
            ModelCtrl.GetDataModel().ModelFile = fullFilePath;

            DataSet theSet = ModelDataSet.GetModelEmptyDataSet();

            List<Plot> plots = PlotCollectionCtrl.getPlots();
            Collection<DetectedColor> colors = DetectedColorCollectionCtrl.getDetectedColors();

            decimal maxProgress = plots.Count + colors.Count + 1;
            decimal counter = 0;


            //Populate "Global" table
            DataRow globalTableRow = theSet.Tables["Global"].NewRow();
            globalTableRow.SetField<string>("AppVersion", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            globalTableRow.SetField<string>("SelectedMapSize", ModelCtrl.GetMapSize().ToString());
            globalTableRow.SetField<String>("DataSourceImage", BitmapOperationsCtrl.getBase64StringFromBitmap(ModelCtrl.GetDataSourceImage()));
            globalTableRow.SetField<GridType.Enumeration>("GridType", ModelCtrl.GetGridType());
            globalTableRow.SetField<MapDataSource.Enumeration>("MapDataSource", ModelCtrl.GetModelDataSourceType());
            globalTableRow.SetField<CivilizationVersion.Enumeration>("CivilizationVersion", ModelCtrl.GetCivilizationVersion());
            theSet.Tables["Global"].Rows.Add(globalTableRow);
            counter++;
            _saveBackgroundWorker.ReportProgress((int)((counter / maxProgress) * 100));



            //Populate "Plot" table
            foreach (Plot tempPlot in plots)
            {
                DataRow newPlotRow = theSet.Tables["Plot"].NewRow();
                newPlotRow.SetField<string>("Id", tempPlot.Id.Name);
                newPlotRow.SetField<TerrainType.Enumeration>("Terrain", tempPlot.TerrainDescriptor);
                newPlotRow.SetField<bool>("Locked", tempPlot.IsLocked);

                switch (ModelCtrl.GetModelDataSourceType())
                {
                    case MapDataSource.Enumeration.ReliefMapImage:
                        PlotReliefMap reliefPlot = (PlotReliefMap)tempPlot;
                        newPlotRow.SetField<string>("Color", reliefPlot.HexDominantColor);
                        break;
                    case MapDataSource.Enumeration.GeoDataProvider:
                        throw new NotImplementedException("No implementation for Geo-Data Source Settings.");
                    default:
                        throw new InvalidEnumArgumentException("Non expected enumeration value.");
                }
                theSet.Tables["Plot"].Rows.Add(newPlotRow);
                counter++;
                _saveBackgroundWorker.ReportProgress((int)((counter / maxProgress) * 100));
            }



            foreach (DetectedColor color in colors)
            {
                DataRow newRow = theSet.Tables["Color"].NewRow();
                newRow.SetField<String>("Id", color.ColorHex);
                newRow.SetField<TerrainType.Enumeration>("Terrain",
                    color.TerrainDescriptor);
                theSet.Tables["Color"].Rows.Add(newRow);
                counter++;
                _saveBackgroundWorker.ReportProgress((int)((counter / maxProgress) * 100));
            }


            theSet.WriteXml(fullFilePath, XmlWriteMode.IgnoreSchema);

            theSet.Dispose();
        }


        private void SaveBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int toReport = e.ProgressPercentage;
            RegisteredListenersCtrl.SetProgressPercent(toReport);
        }


        private void SaveBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error == null)
                {
                    String currentFile = ModelCtrl.GetDataModel().ModelFile;
                    String displayableFilename = VariousUtilityMethods.ExtractDisplayableModelFilePath(currentFile);

                    RegisteredListenersCtrl.CentralFormPublishNewInfoMessage(Resources.Str_SaveModelProcessor_SavedFile + 
                        displayableFilename);
                    RegisteredListenersCtrl.ModelListenersCurrentFileChanged(currentFile);
                }
                else
                {
                    throw e.Error;
                }
            }
            catch (Exception ex)
            {
                using (ErrorForm errorForm = new ErrorForm(false, Resources.Str_SaveModelProcessor_SavedError, ex))
                {
                    errorForm.ShowDialog();
                }
            }
            finally
            {
                RegisteredListenersCtrl.SetProgressPercent(0);
                RegisteredListenersCtrl.ProgressFinished();
                RegisteredListenersCtrl.CentralFormSetModelButtonAndMenusEnabledState(true, true);
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
                _saveBackgroundWorker.DoWork -= SaveBackgroundWorker_DoWork;
                _saveBackgroundWorker.ProgressChanged -= SaveBackgroundWorker_ProgressChanged;
                _saveBackgroundWorker.RunWorkerCompleted -= SaveBackgroundWorker_RunWorkerCompleted;
                _saveBackgroundWorker.Dispose();
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

