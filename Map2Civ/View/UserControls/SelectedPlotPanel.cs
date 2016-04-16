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
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Map2CivilizationView.UserControls
{
    public class SelectedPlotPanel : Panel, IUiListenerZoom
    {
        private PlotId _currentPlotId;
        private IUiForwardedFocusAndClickListener _clickAndFocusForwardingTarget;

        public SelectedPlotPanel(IUiForwardedFocusAndClickListener clickAndFocusForwardingTarget)
        {
            _clickAndFocusForwardingTarget = clickAndFocusForwardingTarget;

            Size = new Size(0, 0);
            Location = new Point(-100, -100);
            BorderStyle = BorderStyle.Fixed3D;
            BackColor = Color.FromArgb(0, 0, 0, 0);

            RegisteredListenersCtrl.ZoomListeners.RegisterObserver(this);
            HandleDestroyed += SelectedPlotPanel_Closing;
            MouseClick += SelectedPlotPanel_MouseClick;
        }

        private void SelectedPlotPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (_clickAndFocusForwardingTarget != null)
            {
                MouseEventArgs argsToForward = new MouseEventArgs(e.Button, e.Clicks, e.X + Location.X, e.Y + Location.Y, e.Delta);
                _clickAndFocusForwardingTarget.ReceiveFocusAndClickEvent(argsToForward);
            }
        }

        public void RepositionSelectedPlotPanel(PlotId id)
        {
            _currentPlotId = id;
            if (Size.Width == 0)
            {
                ResizePanel();
            }
            Point pointToDraw = Point.Round(GridCoordinateHelperCtrl.ConvertPlotIdToPixelLocation(id, true));
            Location = pointToDraw;

            Update();
            Refresh();
        }

        public void ResizePanel()
        {
            float zoomFactor = GridCoordinateHelperCtrl.GetZoomFactor();
            GridTypeEnumWrapper.GridType currentGridType = ModelCtrl.GetGridType();
            float widthPixels = (GridTypeEnumWrapper.Singleton.GetPlotWidthPixels(currentGridType) * (zoomFactor / 100f)) + SystemInformation.BorderSize.Width * 4;
            float heightPixels = (GridTypeEnumWrapper.Singleton.GetPlotHeightPixels(currentGridType) * (zoomFactor / 100f)) + SystemInformation.BorderSize.Height * 4;

            this.Size = new Size((int)Math.Ceiling(widthPixels), (int)Math.Ceiling(heightPixels));
            this.Update();
            this.Refresh();
        }

        #region Event handlers

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        protected void SelectedPlotPanel_Closing(object sender, EventArgs e)
        {
            RegisteredListenersCtrl.ZoomListeners.DeregisterObserver(this);
        }

        #endregion Event handlers

        #region IUIListener_ZoomChanged implementations

        public void ZoomChanged(float value)
        {
            ResizePanel();
            RepositionSelectedPlotPanel(_currentPlotId);
        }

        #endregion IUIListener_ZoomChanged implementations
    }
}