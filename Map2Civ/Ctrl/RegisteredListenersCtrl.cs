using System;
using System.Collections.Generic;
using System.Drawing;
using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Listener;

namespace Map2CivilizationCtrl
{
    static class RegisteredListenersCtrl
    {

        readonly static UIListenersRegister<IUiListenerOriginalMap> _originalMapListeners =
            new UIListenersRegister<IUiListenerOriginalMap>();
        readonly static UIListenersRegister<IUiListenerProcessedMap> _processedMapListeners =
            new UIListenersRegister<IUiListenerProcessedMap>();
        readonly static UIListenersRegister<IUiListenerCentralForm> _centralFormListeners =
            new UIListenersRegister<IUiListenerCentralForm>();
        readonly static UIListenersRegister<IUiListenerDetectedColorsGrid> _colorGridListeners =
            new UIListenersRegister<IUiListenerDetectedColorsGrid>();
        readonly static UIListenersRegister<IUiListenerPlotLocation> _plotLocationListeners =
            new UIListenersRegister<IUiListenerPlotLocation>();
        readonly static UIListenersRegister<IUiListenerDetectedColorsCounter> _detectedColorsCounters =
            new UIListenersRegister<IUiListenerDetectedColorsCounter>();
        readonly static UIListenersRegister<IUiListenerProgress> _progressListeners =
            new UIListenersRegister<IUiListenerProgress>();
        readonly static UIListenersRegister<IUiListenerModel> _modelListeners =
            new UIListenersRegister<IUiListenerModel>();
        readonly static UIListenersRegister<IUiListenerZoom> _zoomListeners =
            new UIListenersRegister<IUiListenerZoom>();



        internal static UIListenersRegister<IUiListenerOriginalMap> OriginalMapListeners
        {
            get
            {
                return _originalMapListeners;
            }
        }

        internal static UIListenersRegister<IUiListenerProcessedMap> ProcessedMapListeners
        {
            get
            {
                return _processedMapListeners;
            }
        }

        internal static UIListenersRegister<IUiListenerCentralForm> CentralFormListeners
        {
            get
            {
                return _centralFormListeners;
            }
        }

        internal static UIListenersRegister<IUiListenerDetectedColorsGrid> ColorGridListeners
        {
            get
            {
                return _colorGridListeners;
            }
        }

        internal static UIListenersRegister<IUiListenerPlotLocation> PlotLocationListeners
        {
            get
            {
                return _plotLocationListeners;
            }
        }

        internal static UIListenersRegister<IUiListenerDetectedColorsCounter> DetectedColorsCounters
        {
            get
            {
                return _detectedColorsCounters;
            }
        }

        internal static UIListenersRegister<IUiListenerProgress> ProgressListeners
        {
            get
            {
                return _progressListeners;
            }
        }

        public static UIListenersRegister<IUiListenerModel> ModelListeners
        {
            get
            {
                return _modelListeners;
            }
        }

        internal static UIListenersRegister<IUiListenerZoom> ZoomListeners
        {
            get
            {
                return _zoomListeners;
            }
        }

        #region Model Interface Ctrl Methods

        public static void ModelListenersModelChanged()
        {
            foreach(IUiListenerModel temp in _modelListeners.ListenersList)
            {
                temp.ModelChanged();
            }

            //Reset zoom factor to 100%
            RegisteredListenersCtrl.ZoomChangedUpdate(1f);
        }


        public static void ModelListenersCurrentFileChanged(string fullFilename)
        {
            foreach(IUiListenerModel temp in _modelListeners.ListenersList)
            {
                temp.UpdateCurrentModelFile(fullFilename);
            }
        }

        #endregion


        #region  Original Map Observer Interface Ctrl methods

        public static void UpdateOriginalMap()
        {
            //Get the original datasource image and apply the grid on it...
            Bitmap bmpWithGrid = ModelCtrl.GetDataSourceImageWithGrid();

            foreach (IUiListenerOriginalMap temp in _originalMapListeners.ListenersList)
            {
                temp.ReloadMap(bmpWithGrid);
            }
        }

        #endregion




        #region ***** Central Form Listener Interface  Ctrl methods
        
       

        public static void CentralFormUpdateAssignedPercentComplete()
        {
            foreach (IUiListenerCentralForm temp in _centralFormListeners.ListenersList)
            {
                temp.UpdateAssignedPercentComplete();
            }
        }
        

        public static void CentralFormPublishNewInfoMessage(String infoMessage)
        {
            foreach (IUiListenerCentralForm temp in _centralFormListeners.ListenersList)
            {
                temp.PublishNewInfoMessage(infoMessage);
            }
        }


        public static void CentralFormSetModelButtonAndMenusEnabledState(Boolean saveActive, Boolean saveAsActive)
        {
            foreach (IUiListenerCentralForm temp in _centralFormListeners.ListenersList)
            {
                temp.SetModelButtonAndMenusEnabledState(saveActive, saveAsActive);
            }
        }

        #endregion



        #region ***** Progress listeners

        public static void SetProgressPercent(int value)
        {
            foreach (IUiListenerProgress temp in _progressListeners.ListenersList)
            {
                temp.SetProgressPercent(value);
            }
        }


        public static void ProgressStarted()
        {
            foreach (IUiListenerProgress temp in _progressListeners.ListenersList)
            {
                temp.ProgressStarted();
            }
        }

        public static void ProgressFinished()
        {
            foreach (IUiListenerProgress temp in _progressListeners.ListenersList)
            {
                temp.ProgressFinished();
            }
        }

        #endregion


        #region ***** Processed map observer Interface  Ctrl methods

        public static void ProcessedMapNotifyProcessedMapChanged()
        {
            Bitmap toDraw = BitmapOperationsCtrl.RebuidProcessedBitmap();

            foreach (IUiListenerProcessedMap temp in _processedMapListeners.ListenersList)
            {
                temp.GetProcessedMap(toDraw);
            }

            CentralFormUpdateAssignedPercentComplete();

        }


        public static void ProcessedMapShowSelectedColorsPlots(List<PlotId> plotCoordinatePairs)
        {
            
            foreach (IUiListenerProcessedMap temp in _processedMapListeners.ListenersList)
            {
                temp.ShowSelectedColorsPlots(plotCoordinatePairs);
            }
           
        }

        #endregion


        #region ***** Detected colors Grid interface  Ctrl methods

        

        public static void DetectedColorsGridSetSelectedColor(String colorID)
        {
            foreach(IUiListenerDetectedColorsGrid temp in _colorGridListeners.ListenersList)
            {
                temp.SetSelectedColor(colorID);
            }
               
            
        }

        

        public static void DetectedColorsGridFill()
        {
            foreach (IUiListenerDetectedColorsGrid temp in _colorGridListeners.ListenersList)
            {
                temp.FillColorGrid();
            }
        }

        #endregion

        #region  Plot location observers  Ctrl methods

        

        public static void PlotLocationUpdate(PlotId id)
        {
           foreach(IUiListenerPlotLocation temp in _plotLocationListeners.ListenersList)
            {
                temp.UpdatePlotLocation(id);
            }
        }
        


        #endregion



        #region IUIListener_DetectedColorsCounter

        public static void DetectedColorsCounterUpdate(int count)
        {
            foreach (IUiListenerDetectedColorsCounter temp in _detectedColorsCounters.ListenersList)
            {
                temp.UpdateColorListCount(count);

            }
        }

        #endregion


        #region IUIListener_ZoomChanged observers

        public static void ZoomChangedUpdate(float value)
        {
            GridCoordinateHelperCtrl.SetZoomFactor(value);

            foreach (IUiListenerZoom temp in _zoomListeners.ListenersList)
            {
                temp.ZoomChanged(value);
            }
        }

        #endregion 


    }
}
