using System;
using System.Drawing;
using System.Windows.Forms;
using Map2CivilizationCtrl;
using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Listener;

namespace Map2CivilizationView.UserControls
{

    public abstract class MapControlBase: UserControl, IUiListenerPlotLocation, IUiListenerZoom, IUiForwardedFocusAndClickListener
    {
         Panel _basePanel = new Panel();
         PictureBox _pictureBox = new PictureBox();
         SelectedPlotPanel _markerCtrl;
         bool _AllowScroll = true;


         PlotId _currentPlotId;
         Point _mouseMoveStartPoint;

        #region get/setters

        public Panel BasePanel
        {
            get
            {
                return _basePanel;
            }
        }

        public PictureBox PictureBox
        {
            get
            {
                return _pictureBox;
            }
        }

        

        public Point MouseMoveStartPoint
        {
            get
            {
                return _mouseMoveStartPoint;
            }

            set
            {
                _mouseMoveStartPoint = value;
            }
        }


        public SelectedPlotPanel MarkerCtrl
        {
            get
            {
                return _markerCtrl;
            }

            set
            {
                _markerCtrl = value;
            }
        }

        public PlotId CurrentPlotId
        {
            get
            {
                return _currentPlotId;
            }

            set
            {
                _currentPlotId = value;
            }
        }

        #endregion


        protected MapControlBase()
        {
            Controls.Add(_basePanel);
            _basePanel.Dock = DockStyle.Fill;
            _basePanel.BorderStyle = BorderStyle.Fixed3D;
            _basePanel.Margin = new Padding(0, 0, 0, 0);
            _basePanel.AutoScroll = false;
            _basePanel.Controls.Add(_pictureBox);
            _basePanel.MouseWheel += BasePanelMouseWheel;

            _pictureBox.Dock = DockStyle.None;
            _pictureBox.Size = new Size(0, 0);
            _pictureBox.Location = new Point(0, 0);
            _pictureBox.WaitOnLoad = false;
            _pictureBox.BackgroundImageLayout = ImageLayout.Zoom;
            _pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;




            HandleDestroyed += MapControlBase_Closing;
            KeyDown += MapControlBase_KeyDown;
            _pictureBox.Click += PictureBox_Click;
            _pictureBox.MouseDown += pictureBox_MouseDown;
            _pictureBox.MouseMove += pictureBox_MouseMove;
            _pictureBox.MouseUp += pictureBox_MouseUp;
            _pictureBox.MouseWheel += PictureBoxMouseWheel;

            _markerCtrl = new SelectedPlotPanel(this);
            RegisteredListenersCtrl.ZoomListeners.RegisterObserver(this);

        }



        #region public methods

        protected  void AllowScroll(Boolean value)
        {
            _AllowScroll = value;
            _basePanel.AutoScroll = value;
            _basePanel.HorizontalScroll.Visible = value;
            _basePanel.VerticalScroll.Visible = value;
            
            
        }

        #endregion




        #region IUI_ForwardedFocusAndClickListener Interface method(s)
        public void ReceiveFocusAndClickEvent(MouseEventArgs e)
        {
            PictureBox_Click(this, e);
        }
        #endregion


        #region IUIListener_PlotLocation interface methods

        public void UpdatePlotLocation(PlotId id)
        {
            _markerCtrl.RepositionSelectedPlotPanel(id);
            _currentPlotId = id;
        }

        #endregion



        #region Control Event Handlers

        protected void PictureBoxMouseWheel(object sender , MouseEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));
            if (_pictureBox.BackgroundImage != null)
            {
                float newZoomValue = GridCoordinateHelperCtrl.GetZoomFactor();
                if (e.Delta > 0)
                {
                    newZoomValue = GridCoordinateHelperCtrl.GetNextZoomInFactor();
                }
                else if (e.Delta <0)
                {
                    newZoomValue = GridCoordinateHelperCtrl.GetNextZoomOutFactor();
                }

                RegisteredListenersCtrl.ZoomChangedUpdate(newZoomValue);

                //Make sure that the wheel event does not bubble-up to
                // the parent container (_basePanel in this case)
                ((HandledMouseEventArgs)e).Handled = true;
              
            }
        }


        
        protected void BasePanelMouseWheel(object sender, MouseEventArgs e)
        {
            //Do nothing
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        protected void MapControlBase_Closing(object sender, EventArgs e)
        {
            //mapBitmap = null;
            RegisteredListenersCtrl.PlotLocationListeners.DeregisterObserver(this);
            RegisteredListenersCtrl.ZoomListeners.DeregisterObserver(this);


        }



         void PictureBox_Click(object sender, EventArgs e)
        {
            if (RegisteredListenersCtrl.PlotLocationListeners.Contains(this))
            {
                MouseEventArgs me = (MouseEventArgs)e;
                _currentPlotId = GridCoordinateHelperCtrl.ConvertPixelLocationToPlotId(me.X, me.Y);
                Focus();
                RegisteredListenersCtrl.PlotLocationUpdate(_currentPlotId);
            }
        }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "1")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        protected void MapControlBase_KeyDown(object sender, KeyEventArgs e)
        {
            int newPlotX = CurrentPlotId.X;
            int newPlotY = CurrentPlotId.Y;


            switch (e.KeyCode)
            {
                case Keys.Up:
                    newPlotY++;
                    break;
                case Keys.Down:
                    newPlotY--;
                    break;
                case Keys.Left:
                    newPlotX--;
                    break;
                case Keys.Right:
                    newPlotX++;
                    break;
            }


            PlotId newPlotId = new PlotId(newPlotX, newPlotY);

            if (    (!newPlotId.Equals(CurrentPlotId)) &&
                GridCoordinateHelperCtrl.VerifyPlotLocationValidity(newPlotId))
            {
                RegisteredListenersCtrl.PlotLocationUpdate(newPlotId);
            }

        }



         void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point changePoint = new Point(e.Location.X - _mouseMoveStartPoint.X,
                                  e.Location.Y - _mouseMoveStartPoint.Y);
                _basePanel.AutoScrollPosition = new Point(-_basePanel.AutoScrollPosition.X - changePoint.X,
                                                      -_basePanel.AutoScrollPosition.Y - changePoint.Y);
            }
        }

         void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _mouseMoveStartPoint = e.Location;
                Cursor = Cursors.Hand;
            }

            if(e.Button == MouseButtons.Right)
            {
                PictureBox_Click(this, e);
            }
        }

         void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
        }




        #endregion



        #region Overriden methods

        /// <summary>
        /// Overriden method IsInputKey. Overriding is required in order to specify that arrow keys are not to
        /// be hanlded by the preprocessing phase (ie, used by the app to transfer focus to another control). In 
        /// this implementation, arrow key presses are processed by the current control in order to modify the 
        /// location of the plot marker.
        /// </summary>
        /// <param name="keyData">The data of the key being pressed</param>
        /// <returns></returns>
        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Right:
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                    return true;
                default:
                    return base.IsInputKey(keyData);
            }

        }


        

        #endregion

        #region IUIListener_ZoomChanged implementations

        public void ZoomChanged(float value)
        {
            float newWidth = _pictureBox.BackgroundImage.Width * (value/100f);
            float newHeight = _pictureBox.BackgroundImage.Height * (value/100f);
            _pictureBox.Size = new Size((int)Math.Ceiling(newWidth), (int)Math.Ceiling(newHeight));

            if(!_AllowScroll)
            {
                Size = new Size((int)Math.Ceiling(newWidth), (int)Math.Ceiling(newHeight));
            }
            _markerCtrl.RepositionSelectedPlotPanel(_currentPlotId);

        }

        #endregion

        /// <summary>
        /// Used only for compatibility with the VS designer.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledCode")]
         void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MapControlBase
            // 
            this.Name = "MapControlBase";
            this.ResumeLayout(false);

        }
    }
}
