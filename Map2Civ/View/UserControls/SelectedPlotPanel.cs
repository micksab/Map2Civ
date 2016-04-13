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
            GridType.Enumeration currentGridType = ModelCtrl.GetGridType();
            float widthPixels = (GridType.Singleton.GetPlotWidthPixels(currentGridType) * (zoomFactor / 100f)) + SystemInformation.BorderSize.Width * 4;
            float heightPixels = (GridType.Singleton.GetPlotHeightPixels(currentGridType) * (zoomFactor / 100f)) + SystemInformation.BorderSize.Height * 4;

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