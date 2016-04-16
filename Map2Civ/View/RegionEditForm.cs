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


using Map2CivilizationCtrl;
using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationCtrl.Listener;
using Map2CivilizationView.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Map2CivilizationView
{
    public partial class RegionEditForm : Form, IUiListenerPlotLocation, IUiListenerZoom
    {
        private MapControlOriginal _originalMapControl;
        private MapControlProcessed _processedMapControl;
        private PlotId _currentPlotId;

        public RegionEditForm(PlotId plotId)
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            _currentPlotId = plotId;

            //Create and add the controls
            _originalMapControl = new MapControlOriginal(false);
            splitContainer.Panel1.Controls.Add(_originalMapControl);

            _processedMapControl = new MapControlProcessed(false, ProcessedMapControlModeEnumWrapper.ProcessedMapControlMode.PlotEditor);
            splitContainer.Panel2.Controls.Add(_processedMapControl);

            ////Set the size of the map controls
            Size sizeToAssign = GridCoordinateHelperCtrl.CalculateImageSize(ModelCtrl.GetMapSize(), ModelCtrl.GetGridType());
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

        private void _originalMapControl_GotFocus(object sender, EventArgs e)
        {
            _processedMapControl.Focus();
        }

        private void RegionEditForm_HandleDestroyed(object sender, EventArgs e)
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

        private void RegionEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegisteredListenersCtrl.PlotLocationListeners.DeregisterObserver(this);
            RegisteredListenersCtrl.ZoomListeners.DeregisterObserver(this);
            _originalMapControl.Dispose();
            _processedMapControl.Dispose();
        }

        private void SplitPanelsSizeChanged(object sender, EventArgs e)
        {
            CenterToSelectedPlot();
        }

        private void CenterToSelectedPlot()
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