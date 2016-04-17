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
using Map2CivilizationCtrl.JsonAdapters;
using Map2CivilizationView;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace Map2CivilizationCtrl.ModelFileStorage
{
    internal class SaveModelProcessor : IDisposable
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

        public static void StartProcess(string fullFilePath)
        {
            RegisteredListenersCtrl.ProgressStarted();
            SaveModelProcessor processor = Singleton();
            processor._saveBackgroundWorker.RunWorkerAsync(fullFilePath);
        }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Console.WriteLine(System.String,System.Object)")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling")]
        private void SaveBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string fullFilePath = (string)e.Argument;
            ModelCtrl.GetDataModel().ModelFile = fullFilePath;

            Stopwatch jsonSerializeStopWatch = new Stopwatch();
            jsonSerializeStopWatch.Start();
            DataModelJsonAdapter modelAdapter = new DataModelJsonAdapter(ModelCtrl.GetDataModel());
            JsonSerializer serializer = new JsonSerializer();

            //using (StreamWriter sw = new StreamWriter(fullFilePath))
            //using (JsonWriter writer = new JsonTextWriter(sw))
            //{
            //    serializer.Serialize(writer, modelAdapter);
            //}

            using (MemoryStream ms = new MemoryStream())
            using (TextWriter tr = new StreamWriter(ms))
            using (JsonWriter writer = new JsonTextWriter(tr))
            {
                serializer.Serialize(writer, modelAdapter);
                writer.Flush();
                GZipCompression.CompressModelFile(ms, fullFilePath);
            }

            jsonSerializeStopWatch.Stop();
            Console.WriteLine("Created json file in {0} millis", jsonSerializeStopWatch.ElapsedMilliseconds);

           

            _saveBackgroundWorker.ReportProgress(100);
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

        #endregion IDisposable interface implementation (for backgroundworker threads).
    }
}