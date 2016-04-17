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


using Map2Civilization.Ctrl;
using Map2Civilization.Properties;
using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationCtrl.JsonAdapters;
using Map2CivilizationModel;
using Map2CivilizationView;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace Map2CivilizationCtrl.ModelFileStorage
{
    internal class LoadModelProcessor : IDisposable
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

        public static void StartProcess(string fullFilePath)
        {
            RegisteredListenersCtrl.ProgressStarted();
            LoadModelProcessor processor = Singleton();
            processor._loadBackgroundWorker.RunWorkerAsync(fullFilePath);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Console.WriteLine(System.String,System.Object)")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        private void LoadBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string fullFilePath = (string)e.Argument;

            Stopwatch jsonDeserializeStopWatch = new Stopwatch();
            jsonDeserializeStopWatch.Start();
            DataModelJsonAdapter loadModelAdapter;
            JsonSerializer deserializer = new JsonSerializer();
            string jsonString = GZipCompression.DecompressModelFile(fullFilePath);

            using (StringReader rd = new StringReader(jsonString))
            using (JsonReader jrd = new JsonTextReader(rd))
            {
                loadModelAdapter = deserializer.Deserialize<DataModelJsonAdapter>(jrd);
            }
            jsonDeserializeStopWatch.Stop();
            Console.WriteLine("Read json file in {0} millis", jsonDeserializeStopWatch.ElapsedMilliseconds);


            //using (StreamReader rd = new StreamReader(fullFilePath))
            //using (JsonReader jrd = new JsonTextReader(rd))
            //{
            //    loadModelAdapter = deserializer.Deserialize<DataModelJsonAdapter>(jrd);
            //}
            //jsonDeserializeStopWatch.Stop();
            //Console.WriteLine("Read json file in {0} millis", jsonDeserializeStopWatch.ElapsedMilliseconds);


            decimal progressMaxValue = 2 + loadModelAdapter.DetectedColorArray.Length +
                loadModelAdapter.ReliefPlotArray.Length + loadModelAdapter.GeoDataPlotArray.Length;
            decimal counter = 0m;

            DataModel newDataModel = new DataModel();
            newDataModel.CivilizationVersion = loadModelAdapter.CivilizationVersion;
            newDataModel.GridType = loadModelAdapter.GridType;
            newDataModel.MapDataSource = loadModelAdapter.MapDataSourceType;
            newDataModel.SelectedMapSize = loadModelAdapter.MapSize.GetMapDimension();

            counter++;
            _loadBackgroundWorker.ReportProgress((int)((counter / progressMaxValue) * 100));

            if (newDataModel.MapDataSource == MapDataSourceEnumWrapper.MapDataSource.ReliefMapImage)
            {
                newDataModel.ReliefMapSettings = loadModelAdapter.ReliefMapSettings.GetSourceReliefMapSettings();
                //Add the relief plots
                foreach (PlotReliefMapJsonAdapter plot in loadModelAdapter.ReliefPlotArray)
                {
                    PlotReliefMap reliefPlot = plot.GetPlotReliefMap();
                    DetectedColor detColorToAdd = new DetectedColor(reliefPlot.HexDominantColor);
                    newDataModel.PlotCollection.AddNewPlot(reliefPlot);
                    newDataModel.DetectedColorCollection.AddDetectedColor(detColorToAdd);
                    newDataModel.DetectedColorCollection.AddDetectedColorPlot(detColorToAdd, reliefPlot);

                    counter++;
                    _loadBackgroundWorker.ReportProgress((int)((counter / progressMaxValue) * 100));
                }
            }

            if (newDataModel.MapDataSource == MapDataSourceEnumWrapper.MapDataSource.GeoDataProvider)
            {
                newDataModel.GeoDataSettings = loadModelAdapter.GeoDataSettings.GetGeoDataSettings();
                //Add the geo-data plots
                foreach (PlotGeoDataJsonAdapter plot in loadModelAdapter.GeoDataPlotArray)
                {
                    newDataModel.PlotCollection.AddNewPlot(plot.GetPlotGeoData());
                    counter++;
                    _loadBackgroundWorker.ReportProgress((int)((counter / progressMaxValue) * 100));
                }
            }

            //update the detected colors...
            foreach (DetectedColorJsonAdapter color in loadModelAdapter.DetectedColorArray)
            {
                DetectedColor detectedColor = color.GetDetectedColor();
                newDataModel.DetectedColorCollection.UpdateDetectedColor(detectedColor.ColorHex, detectedColor.TerrainDescriptor);
                counter++;
                _loadBackgroundWorker.ReportProgress((int)((counter / progressMaxValue) * 100));
            }

            //Initialize the empty processed map image
            newDataModel.ProcessedBitmap = BitmapOperationsCtrl.InitializeProcessedMapImage(newDataModel.SelectedMapSize, newDataModel.GridType);
            //Initialize the adjusted source image
            newDataModel.ReliefMapSettings.AdjustedMapBitmap = BitmapOperationsCtrl.InitializeDataSourceImage(
                newDataModel.ReliefMapSettings, newDataModel.SelectedMapSize, newDataModel.GridType);
            newDataModel.ModelFile = fullFilePath;

            counter++;
            _loadBackgroundWorker.ReportProgress((int)((counter / progressMaxValue) * 100));

            e.Result = newDataModel;
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

        #endregion IDisposable interface implementation (for backgroundworker threads).
    }
}