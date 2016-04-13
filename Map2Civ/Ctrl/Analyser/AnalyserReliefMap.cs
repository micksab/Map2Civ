using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationModel;
using Map2CivilizationView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace Map2CivilizationCtrl.Analyzer
{
    internal class AnalyserReliefMap : AnalyzerFactory, IDisposable
    {
        private SourceReliefMapSettings _settings;
        private GridType.Enumeration _gridType;
        private MapDimension _dimension;
        private BackgroundWorker _analyseBackgroundWorker = new BackgroundWorker();
        private CivilizationVersion.Enumeration _civilizationVersion;

        private readonly string _settingsKey = "settings";
        private readonly string _gridTypeKey = "gridType";
        private readonly string _dimensionKey = "mapDimension";
        private readonly string _civilizationVersionKey = "civVersion";

        public AnalyserReliefMap(SourceReliefMapSettings settings, GridType.Enumeration gridType,
            MapDimension dimension, CivilizationVersion.Enumeration civilizationVersion)
        {
            _settings = settings;
            _gridType = gridType;
            _dimension = dimension;
            _civilizationVersion = civilizationVersion;
            _analyseBackgroundWorker.WorkerReportsProgress = true;
            _analyseBackgroundWorker.DoWork += AnalysisBackgroundWorker_DoWork;
            _analyseBackgroundWorker.ProgressChanged += AnalysiseBackgroundWorker_ProgressChanged;
            _analyseBackgroundWorker.RunWorkerCompleted += AnalysisBackgroundWorker_RunWorkerCompleted;
        }

        public override void AnalyzeData()
        {
            RegisteredListenersCtrl.ProgressStarted();

            Dictionary<string, object> arguments = new Dictionary<string, Object>();
            arguments.Add(_settingsKey, _settings);
            arguments.Add(_gridTypeKey, _gridType);
            arguments.Add(_dimensionKey, _dimension);
            arguments.Add(_civilizationVersionKey, _civilizationVersion);

            _analyseBackgroundWorker.RunWorkerAsync(arguments);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        private void AnalysisBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Dictionary<string, object> arguments = (Dictionary<string, object>)e.Argument;
            SourceReliefMapSettings settings = (SourceReliefMapSettings)arguments[_settingsKey];
            GridType.Enumeration gridTypeEnum = (GridType.Enumeration)arguments[_gridTypeKey];
            MapDimension mapDimension = (MapDimension)arguments[_dimensionKey];
            CivilizationVersion.Enumeration civilizationVersion = (CivilizationVersion.Enumeration)arguments[_civilizationVersionKey];

            //Calculate the number of plots to process, and initialize a counter
            // used to track progress
            decimal progressMaxValue = mapDimension.WidthPlots * mapDimension.HeightPlots + 2;
            decimal counter = 0;

            DataModel newDataModel = new DataModel(mapDimension, gridTypeEnum, MapDataSource.Enumeration.ReliefMapImage,
                civilizationVersion, settings);
            //Initialize the empty processed map image
            newDataModel.ProcessedBitmap = BitmapOperationsCtrl.InitializeProcessedMapImage(mapDimension, gridTypeEnum);
            //Initialize the adjusted source image
            newDataModel.ReliefMapSettings.AdjustedMapBitmap = BitmapOperationsCtrl.InitializeDataSourceImage(settings, mapDimension, gridTypeEnum);

            counter++;
            _analyseBackgroundWorker.ReportProgress((int)((counter / progressMaxValue) * 100));

            /****** Analysis image *****/
            Bitmap analysisImage = BitmapOperationsCtrl.GenerateAnalysisImage(newDataModel.ReliefMapSettings.AdjustedMapBitmap,
                 settings);
            counter++;
            _analyseBackgroundWorker.ReportProgress((int)((counter / progressMaxValue) * 100));

            //The use of the brush over here seems to be out of place (it should normally be inside
            //function BitmapOperationsCtrl.GetPlotArea), but after extensive testing it was deemed
            // to be necessary in order to:
            // 1/ Extract the bitmaps of the plots as fast as possible
            // 2/ Extract each of these bitmaps on its own (instead of producing a list of bitmaps
            // for all the plots), so that the temporary memory usage "spike" due to this process
            // is kept to a minimum.
            using (Brush br = new TextureBrush(analysisImage))
            {
                for (int yPlot = 0; yPlot < mapDimension.HeightPlots; yPlot++)
                {
                    for (int xPlot = 0; xPlot < mapDimension.WidthPlots; xPlot++)
                    {
                        PlotId id = new PlotId(xPlot, yPlot);
                        Bitmap plotBitmap = BitmapOperationsCtrl.GetPlotArea(analysisImage, id, br, gridTypeEnum, mapDimension);
                        Color dominantColor = BitmapOperationsCtrl.CalcDominantColor(plotBitmap);
                        string hexDominantColor = BitmapOperationsCtrl.HexFromColor(dominantColor);
                        //plotAreasList.Remove(id);
                        plotBitmap.Dispose();

                        PlotReliefMap toAdd = new PlotReliefMap(xPlot, yPlot, hexDominantColor);
                        newDataModel.PlotCollection.AddNewPlot(toAdd);
                        DetectedColor newDetectedColor = new DetectedColor(toAdd.HexDominantColor);
                        newDataModel.DetectedColorCollection.AddDetectedColor(newDetectedColor);
                        newDataModel.DetectedColorCollection.AddDetectedColorPlot(newDetectedColor, toAdd);

                        counter++;
                        _analyseBackgroundWorker.ReportProgress((int)((counter / progressMaxValue) * 100));
                    }
                }
            }

            e.Result = newDataModel;
        }

        private void AnalysiseBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int toReport = e.ProgressPercentage;
            RegisteredListenersCtrl.SetProgressPercent(toReport);
        }

        private void AnalysisBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error == null)
                {
                    DataModel newModel = (DataModel)e.Result;
                    ModelCtrl.SetDataModel(newModel);
                    RegisteredListenersCtrl.CentralFormPublishNewInfoMessage(Map2Civilization.Properties.Resources.Str_AnalyserReliefMap_ModelCreated);
                    RegisteredListenersCtrl.CentralFormSetModelButtonAndMenusEnabledState(true, false);
                }
                else
                {
                    using (ErrorForm errorForm = new ErrorForm(true, Map2Civilization.Properties.Resources.Str_AnalyserReliefMap_ErrorCreatingModel, e.Error))
                    {
                        errorForm.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                using (ErrorForm errorForm = new ErrorForm(true, Map2Civilization.Properties.Resources.Str_AnalyserReliefMap_ErrorCreatingModel, ex))
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
                _analyseBackgroundWorker.DoWork -= AnalysisBackgroundWorker_DoWork;
                _analyseBackgroundWorker.ProgressChanged -= AnalysiseBackgroundWorker_ProgressChanged;
                _analyseBackgroundWorker.RunWorkerCompleted -= AnalysisBackgroundWorker_RunWorkerCompleted;
                _analyseBackgroundWorker.Dispose();
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