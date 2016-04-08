using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using Map2Civilization.Properties;
using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationModel;
using Map2CivilizationView;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using Newtonsoft.Json;
using System.IO;
using Map2CivilizationCtrl.JsonAdapters;
using System.Diagnostics;

namespace Map2CivilizationCtrl.ModelFileStorage
{
    class SaveModelProcessor : IDisposable
    {
         BackgroundWorker _saveBackgroundWorker = new BackgroundWorker();

         SaveModelProcessor()
        {
            _saveBackgroundWorker.WorkerReportsProgress = true;

            _saveBackgroundWorker.DoWork += SaveBackgroundWorker_DoWork;
            _saveBackgroundWorker.ProgressChanged += SaveBackgroundWorker_ProgressChanged;
            _saveBackgroundWorker.RunWorkerCompleted += SaveBackgroundWorker_RunWorkerCompleted;
        }

         static SaveModelProcessor Singleton()
        {
            return new SaveModelProcessor();
        }

        public static void StartProcess(string fullFilePath)
        {
            RegisteredListenersCtrl.ProgressStarted();
            SaveModelProcessor processor = Singleton();
            processor._saveBackgroundWorker.RunWorkerAsync(fullFilePath);
        }


        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling")]
         void SaveBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string fullFilePath = (string)e.Argument;
            ModelCtrl.GetDataModel().ModelFile = fullFilePath;

            Stopwatch jsonSerializeStopWatch = new Stopwatch();
            jsonSerializeStopWatch.Start();
            DataModelJsonAdapter modelAdapter  = new DataModelJsonAdapter(ModelCtrl.GetDataModel());
            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter(fullFilePath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, modelAdapter);
            }

            jsonSerializeStopWatch.Stop();
            Console.WriteLine("Created json file in {0} millis", jsonSerializeStopWatch.ElapsedMilliseconds);
            

            //Stopwatch jsonDeserializeStopWatch = new Stopwatch();
            //jsonDeserializeStopWatch.Start();
            //DataModelJsonAdapter model2;
            //JsonSerializer deserializer = new JsonSerializer();
            //using (StreamReader rd = new StreamReader(@"C:\MyDocuments\GeoMap2Civ5Map\Map2Civ\Map2Civ\bin\Debug\json.txt"))
            //using (JsonReader jrd = new JsonTextReader(rd))
            //{
            //     model2 = deserializer.Deserialize<DataModelJsonAdapter>(jrd);
            //    //model2.ReliefMapSettings.OriginalMapBitmap.Save(@"C:\MyDocuments\GeoMap2Civ5Map\Map2Civ\Map2Civ\bin\Debug\json.bmp");
            //}
            //jsonDeserializeStopWatch.Stop();
            //Console.WriteLine("Read json file in {0} millis", jsonSerializeStopWatch.ElapsedMilliseconds);


   
            _saveBackgroundWorker.ReportProgress(100);


        }


         void SaveBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int toReport = e.ProgressPercentage;
            RegisteredListenersCtrl.SetProgressPercent(toReport);
        }


         void SaveBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error == null)
                {
                    string currentFile = ModelCtrl.GetDataModel().ModelFile;
                    string displayableFilename = VariousUtilityMethods.ExtractDisplayableModelFilePath(currentFile);

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

