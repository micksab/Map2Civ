using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Listener;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Map2CivilizationCtrl
{
    internal static class RegisteredListenersCtrl
    {
        private static readonly UIListenersRegister<IUiListenerOriginalMap> _originalMapListeners =
            new UIListenersRegister<IUiListenerOriginalMap>();

        private static readonly UIListenersRegister<IUiListenerProcessedMap> _processedMapListeners =
            new UIListenersRegister<IUiListenerProcessedMap>();

        private static readonly UIListenersRegister<IUiListenerCentralForm> _centralFormListeners =
            new UIListenersRegister<IUiListenerCentralForm>();

        private static readonly UIListenersRegister<IUiListenerDetectedColorsGrid> _colorGridListeners =
            new UIListenersRegister<IUiListenerDetectedColorsGrid>();

        private static readonly UIListenersRegister<IUiListenerPlotLocation> _plotLocationListeners =
            new UIListenersRegister<IUiListenerPlotLocation>();

        private static readonly UIListenersRegister<IUiListenerDetectedColorsCounter> _detectedColorsCounters =
            new UIListenersRegister<IUiListenerDetectedColorsCounter>();

        private static readonly UIListenersRegister<IUiListenerProgress> _progressListeners =
            new UIListenersRegister<IUiListenerProgress>();

        private static readonly UIListenersRegister<IUiListenerModel> _modelListeners =
            new UIListenersRegister<IUiListenerModel>();

        private static readonly UIListenersRegister<IUiListenerZoom> _zoomListeners =
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
            foreach (IUiListenerModel temp in _modelListeners.ListenersList)
            {
                temp.ModelChanged();
            }

            //Reset zoom factor to 100%
            RegisteredListenersCtrl.ZoomChangedUpdate(100f);
        }

        public static void ModelListenersCurrentFileChanged(string fullFilename)
        {
            foreach (IUiListenerModel temp in _modelListeners.ListenersList)
            {
                temp.UpdateCurrentModelFile(fullFilename);
            }
        }

        #endregion Model Interface Ctrl Methods

        #region Original Map Observer Interface Ctrl methods

        public static void UpdateOriginalMap()
        {
            //Get the original datasource image and apply the grid on it...
            Bitmap bmpWithGrid = ModelCtrl.GetDataSourceAdjustedImageWithGrid();

            foreach (IUiListenerOriginalMap temp in _originalMapListeners.ListenersList)
            {
                temp.ReloadMap(bmpWithGrid);
            }
        }

        #endregion Original Map Observer Interface Ctrl methods

        #region ***** Central Form Listener Interface  Ctrl methods

        public static void CentralFormUpdateAssignedPercentComplete()
        {
            foreach (IUiListenerCentralForm temp in _centralFormListeners.ListenersList)
            {
                temp.UpdateAssignedPercentComplete();
            }
        }

        public static void CentralFormPublishNewInfoMessage(string infoMessage)
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

        #endregion ***** Central Form Listener Interface  Ctrl methods

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

        #endregion ***** Progress listeners

        #region ***** Processed map observer Interface  Ctrl methods

        public static void ProcessedMapNotifyProcessedMapChanged(List<PlotId> plots)
        {
            Bitmap toDraw = BitmapOperationsCtrl.RebuidProcessedBitmap(plots);

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

        #endregion ***** Processed map observer Interface  Ctrl methods

        #region ***** Detected colors Grid interface  Ctrl methods

        public static void DetectedColorsGridSetSelectedColor(string colorID)
        {
            foreach (IUiListenerDetectedColorsGrid temp in _colorGridListeners.ListenersList)
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

        #endregion ***** Detected colors Grid interface  Ctrl methods

        #region Plot location observers  Ctrl methods

        public static void PlotLocationUpdate(PlotId id)
        {
            foreach (IUiListenerPlotLocation temp in _plotLocationListeners.ListenersList)
            {
                temp.UpdatePlotLocation(id);
            }
        }

        #endregion Plot location observers  Ctrl methods

        #region IUIListener_DetectedColorsCounter

        public static void DetectedColorsCounterUpdate(int count)
        {
            foreach (IUiListenerDetectedColorsCounter temp in _detectedColorsCounters.ListenersList)
            {
                temp.UpdateColorListCount(count);
            }
        }

        #endregion IUIListener_DetectedColorsCounter

        #region IUIListener_ZoomChanged observers

        public static void ZoomChangedUpdate(float value)
        {
            GridCoordinateHelperCtrl.SetZoomFactor(value);

            foreach (IUiListenerZoom temp in _zoomListeners.ListenersList)
            {
                temp.ZoomChanged(value);
            }
        }

        #endregion IUIListener_ZoomChanged observers

    }
}