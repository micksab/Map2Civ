using System;
using System.Drawing;
using System.Windows.Forms;
using Map2CivilizationCtrl;
using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationCtrl.Listener;
using Map2CivilizationView.UserControls;
using System.Collections.Generic;

namespace Map2CivilizationView
{
    public partial class RegionEditForm : Form, IUiListenerPlotLocation, IUiListenerZoom
    {
        MapControlOriginal _originalMapControl;
        MapControlProcessed _processedMapControl;
        PlotId _currentPlotId;



        public RegionEditForm(PlotId plotId)
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            _currentPlotId = plotId;
           


            //Create and add the controls
            _originalMapControl = new MapControlOriginal(false);
            splitContainer.Panel1.Controls.Add(_originalMapControl);

            _processedMapControl = new MapControlProcessed(false, ProcessedMapControlMode.Enumeration.PlotEditor);
            splitContainer.Panel2.Controls.Add(_processedMapControl);

            ////Set the size of the map controls 
            Size sizeToAssign = GridCoordinateHelperCtrl.CalculateImageSize(ModelCtrl.GetMapSize(), ModelCtrl.GetGridType()) ;
            _originalMapControl.Size = sizeToAssign;
            _processedMapControl.Size = sizeToAssign;

            RegisteredListenersCtrl.ProcessedMapNotifyProcessedMapChanged(new List<PlotId>());
            RegisteredListenersCtrl.UpdateOriginalMap();
            


            //Synchronize with the currently selected zoom factor.
            float zoomFactor = GridCoordinateHelperCtrl.GetZoomFactor();
            RegisteredListenersCtrl.ZoomChangedUpdate(zoomFactor);

            //Set as the selected plot the one selected by the user..
            RegisteredListenersCtrl.PlotLocationUpdate(plotId);

           

            //Add the ZoomSplitButton to the form's status strip
            ZoomSplitButton zoomButton = new ZoomSplitButton();
            statusStrip.Items.Add(zoomButton);
            zoomButton.Enabled = true;


            RegisteredListenersCtrl.PlotLocationListeners.RegisterObserver(this);
            RegisteredListenersCtrl.ZoomListeners.RegisterObserver(this);


            //Move the controls so that the center plot appears in 
            // the middle of the panels
            CenterToSelectedPlot();



            _originalMapControl.GotFocus += _originalMapControl_GotFocus;
            HandleDestroyed += RegionEditForm_HandleDestroyed;

        }

         void _originalMapControl_GotFocus(object sender, EventArgs e)
        {
            _processedMapControl.Focus();
        }

         void RegionEditForm_HandleDestroyed(object sender, EventArgs e)
        {
            RegisteredListenersCtrl.PlotLocationListeners.DeregisterObserver(this);
            RegisteredListenersCtrl.ZoomListeners.DeregisterObserver(this);
        }

        public void UpdatePlotLocation(PlotId id)
        {
            plotValueLabel.Text = id.Name;
            _currentPlotId = id;
            CenterToSelectedPlot();
        }



         void RegionEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegisteredListenersCtrl.PlotLocationListeners.DeregisterObserver(this);
            RegisteredListenersCtrl.ZoomListeners.DeregisterObserver(this);
            _originalMapControl.Dispose();
            _processedMapControl.Dispose();
        }

       
         void SplitPanelsSizeChanged(object sender, EventArgs e)
        {
            CenterToSelectedPlot();
        }



         void CenterToSelectedPlot()
        {
            //calc the coordinates (relative to the map) of the center plot
            PointF centerPlotPixels = GridCoordinateHelperCtrl.ConvertPlotIdToPixelLocation(_currentPlotId, true);
            

            //Get the coordinates of the center of the panels...
            Size panelSize = splitContainer.Panel1.ClientSize;

            float mapControlX = centerPlotPixels.X - (panelSize.Width / 2);
            float mapControlY = centerPlotPixels.Y - (panelSize.Height / 2);

            PointF newLocation = new PointF(mapControlX * (-1), mapControlY * (-1));

            if (_originalMapControl != null && _processedMapControl != null)
            {
                _originalMapControl.Location = Point.Round(newLocation);
                _processedMapControl.Location = Point.Round(newLocation);
                Update();
                Refresh();
            }
        }



        public void ZoomChanged(float value)
        {
            CenterToSelectedPlot();
        }

    }
}
