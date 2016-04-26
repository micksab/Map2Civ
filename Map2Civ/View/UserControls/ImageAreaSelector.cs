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
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Map2CivilizationView.UserControls
{
    public class ImageAreaSelector : PictureBox
    {
        private double _CurrentXPerMille;
        private double _CurrentYPerMille;
        private double _CurrentWidthPerMille;
        private readonly double _MapRatio;
        private readonly ImageEditorForm _Editor;
        private bool _SelectorIsVisible = false;
        private Bitmap _ForegroundBitmap;

        public ImageAreaSelector(double mapRatio, ImageEditorForm editor)
        {
            _MapRatio = mapRatio;
            BackgroundImageLayout = ImageLayout.Zoom;
            BorderStyle = BorderStyle.Fixed3D;
            _Editor = editor;
        }

        public void ShowSelectionTool(double imageRatio)
        {
            _CurrentXPerMille = 0;
            _CurrentYPerMille = 0;

            if (_MapRatio >= imageRatio) //work based on the image width
            {
                //The width is smaller than the height, so it's safe to assign
                // full width
                _CurrentWidthPerMille = 1000d;
            }
            else
            {
                //the width is larger than the height, so it's safe to assign full
                // height
                _CurrentWidthPerMille = 1000d / (imageRatio / _MapRatio);
            }
            _Editor.SetWValue(_CurrentWidthPerMille);
            _SelectorIsVisible = true;
            DrawSelectionRect();
        }

        public void HideSelectionTool()
        {
            _SelectorIsVisible = false;
            DrawSelectionRect();
        }

        public void SetNewXPosition(double value)
        {
            if (value + _CurrentWidthPerMille <= 1000d)
            {
                _CurrentXPerMille = value;
                DrawSelectionRect();
            }
            else
            {
                _Editor.SetXValue(_CurrentXPerMille);
            }

            DrawSelectionRect();
        }

        public void SetNewYPosition(double value, double imageRatio)
        {
            double currentHeightPerMille = imageRatio * (_CurrentWidthPerMille / _MapRatio);

            if (value + currentHeightPerMille <= 1000)
            {
                _CurrentYPerMille = value;
                DrawSelectionRect();
            }
            else
            {
                _Editor.SetYValue(_CurrentYPerMille);
            }
        }

        public void SetNewWidth(double value, double imageRatio)
        {
            double currentHeightPerMille = imageRatio * (value / _MapRatio);

            if ((_CurrentXPerMille + value <= 1000) &&
                (_CurrentYPerMille + currentHeightPerMille <= 1000))
            {
                _CurrentWidthPerMille = value;
                DrawSelectionRect();
            }
            else
            {
                _Editor.SetWValue(_CurrentWidthPerMille);
            }
        }

        public bool SelectorIsVisible
        {
            get
            {
                return _SelectorIsVisible;
            }

            set
            {
                _SelectorIsVisible = value;
            }
        }

        private void DrawSelectionRect()
        {
            if (_ForegroundBitmap == null || _ForegroundBitmap.Size != ClientRectangle.Size)
            {
                _ForegroundBitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
                Image = _ForegroundBitmap;
            }

            using (Graphics g = Graphics.FromImage(_ForegroundBitmap))
            {
                g.Clear(Color.Transparent);

                if (_SelectorIsVisible)
                {
                    using (Brush blackBrush = new SolidBrush(Color.FromArgb(70, 0, 0, 0)))
                    {
                        double pixelsX = ClientRectangle.Width * (_CurrentXPerMille / 1000d);
                        double pixelsY = ClientRectangle.Height * (_CurrentYPerMille / 1000d);
                        double pixelsWidth = ClientRectangle.Width * (_CurrentWidthPerMille / 1000d);
                        double pixelsHeight = ClientRectangle.Width * ((_CurrentWidthPerMille / _MapRatio) / 1000d);

                        g.FillRectangle(blackBrush, (float)pixelsX, (float)pixelsY, (float)pixelsWidth, (float)pixelsHeight);
                    }
                }
            }

            Update();
            Refresh();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            DrawSelectionRect();
        }

        public Bitmap SelectedAreaImage
        {
            get
            {
                double pixelsX = BackgroundImage.Width * (_CurrentXPerMille / 1000d);
                double pixelsY = BackgroundImage.Height * (_CurrentYPerMille / 1000d);
                double pixelsWidth = BackgroundImage.Width * (_CurrentWidthPerMille / 1000d);
                double pixelsHeight = BackgroundImage.Width * ((_CurrentWidthPerMille / _MapRatio) / 1000d);

                Bitmap toReturn = BitmapOperationsCtrl.FetchRegionOfBitmap((Bitmap)BackgroundImage, new Point((int)pixelsX, (int)pixelsY),
                    (int)pixelsWidth, (int)pixelsHeight);

                return toReturn;
            }
            
        }
    }
}