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


using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Map2Civilization.Properties;
using Map2CivilizationCtrl;

namespace Map2CivilizationView
{
    
    public partial class ImageEditor : Form
    {
         Bitmap _originalBmp;
         double _intendedRatio;
         double _imageRatio;
         double _panelRatio;
         Boolean _consumeValueChangedEvents = true;

        UserControls.ImageAreaSelector _selectionToolControl;

        public ImageEditor(Bitmap image, double intendedRatio)
        {
            InitializeComponent();

            if(image == null)
                throw new ArgumentNullException(nameof(image));

            if(Math.Abs(intendedRatio) < Double.Epsilon)
                throw new ArgumentNullException(nameof(intendedRatio));

            _originalBmp = image;
            _intendedRatio = intendedRatio;

            this.BringToFront();
            this.Focus();

            
        }

        private void ImageEditor_Load(object sender, EventArgs e)
        {
            intentedRatioLabel.Text = Resources.Str_ImageEditor_IntendedRatio +
                _intendedRatio.ToString("N6", Thread.CurrentThread.CurrentCulture);

            if (_originalBmp != null)
            {
                _originalBmp = (Bitmap)_originalBmp.Clone();

                CalculatePanelRatio();
                _selectionToolControl = new UserControls.ImageAreaSelector(_intendedRatio, this);
                imagePanel.Controls.Add(_selectionToolControl);

                SetImage(_originalBmp);
                EvaluateIntendedRatio();

                this.imagePanel.Resize += new System.EventHandler(this.ImagePanel_Resize);

            }
        }



        void PositionImageAreaSelector()
        {
            int selectorWidth = 0;
            int selectorHeight = 0;

           

            if (_panelRatio <= _imageRatio)//White space above and below selector tool.
            {
                

                selectorWidth = imagePanel.Width;
                selectorHeight = ((int)(selectorWidth/_imageRatio));

                _selectionToolControl.Location =
                    new Point(0, (int)((imagePanel.Height - selectorHeight) / 2d));
            }
            else//White space to the left and right of the selector tool
            {
                

                selectorHeight = imagePanel.Height;
                selectorWidth = ((int)(selectorHeight*_imageRatio));

                _selectionToolControl.Location =
                    new Point((int)((imagePanel.Width - selectorWidth) / 2d), 0);
            }

            _selectionToolControl.Size = new Size(selectorWidth, selectorHeight);


        }


         Boolean EvaluateIntendedRatio()
        {
            Boolean toReturn = false;
           
            if(_selectionToolControl != null)
            {
                if (_selectionToolControl.SelectorIsVisible)
                {
                    toReturn = true;

                }//Allow for 1% tolerance
                else if (_imageRatio <= (_intendedRatio * ((double)1.01)) && _imageRatio >= (_intendedRatio * ((double)0.99)))
                {
                    toReturn = true;
                }
            }

           

            okButton.Enabled = toReturn;
            return toReturn;
        }


         void CalculateImageRatio()
        {
             _imageRatio = (double)_selectionToolControl.BackgroundImage.Width / (double)_selectionToolControl.BackgroundImage.Height;
        }

         void CalculatePanelRatio()
        {
             _panelRatio = (double)imagePanel.Width / (double)imagePanel.Height;
        }


        


        public Bitmap BitmapToProcess
        {
            get
            {
                Bitmap toReturn = null;

                if (_selectionToolControl.SelectorIsVisible == false && DialogResult == DialogResult.OK)
                {
                    toReturn = (Bitmap)_selectionToolControl.BackgroundImage.Clone();
                }
                else if (_selectionToolControl.SelectorIsVisible == true && DialogResult == DialogResult.OK)
                {
                    toReturn = (Bitmap)_selectionToolControl.SelectedAreaImage.Clone();
                }

                toReturn.SetResolution(96, 96);
                return toReturn;
            }
            
        }

        

        public void SetXValue(double value)
        {
            _consumeValueChangedEvents = false;
            xTrackBar.Value = (int)value;
            xNumeric.Value = (decimal)value;
            _consumeValueChangedEvents = true;
        }


       

        public void SetYValue(double value)
        {
            _consumeValueChangedEvents = false;
            yTrackBar.Value = (int)value;
            yNumeric.Value = (decimal)value;
            _consumeValueChangedEvents = true;
        }

        

        public void SetWValue(double value)
        {
            _consumeValueChangedEvents = false;
            wTrackBar.Value = (int)value;
            wNumeric.Value = (decimal)value;
            _consumeValueChangedEvents = true;
        }



         void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

         void OkButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }




         void ShowImageSize(Bitmap bmp)
        {
            imageWidthLabel.Text = string.Concat(Resources.Str_ImageEditor_ImageWidth, bmp.Width, 
                Resources.Str_ImageEditor_ImagePixels);
            imageHeightLabel.Text = string.Concat(Resources.Str_ImageEditor_ImageHeight, bmp.Height,
                Resources.Str_ImageEditor_ImagePixels);
        }


        

         void SetImage(Bitmap bmp)
        {
            _selectionToolControl.BackgroundImage = bmp;
            ShowImageSize(bmp);
            CalculateImageRatio();
            PositionImageAreaSelector();
        }

         void ResizeButton_Click(object sender, EventArgs e)
        {
            using (CanvasSizeForm canvasForm = new CanvasSizeForm(_originalBmp.Size, _intendedRatio))
            {
                DialogResult result = canvasForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Size toResize = canvasForm.CanvasSize;
                    Color toApply = canvasForm.CanvasBackgroundColor;
                    Bitmap newImage = BitmapOperationsCtrl.ResizeCanvas(_originalBmp, toApply, toResize.Width, toResize.Height);
                    SetImage(newImage);
                    EvaluateIntendedRatio();
                }
            }

                
        }

         void SelectAreaButton_Click(object sender, EventArgs e)
        {
            if(sender == selectAreaOnButton)
            {
                
                selectAreaOnButton.Enabled = false;
                selectAreaOffButton.Enabled = true;
                slidersPanel.Enabled = true;
                _selectionToolControl.ShowSelectionTool(_imageRatio);

            }
            else
            {
                selectAreaOnButton.Enabled = true;
                selectAreaOffButton.Enabled = false;
                slidersPanel.Enabled = false;
                _selectionToolControl.HideSelectionTool();
            }

            EvaluateIntendedRatio();


        }

        

         void ImagePanel_Resize(object sender, EventArgs e)
        {
            EvaluateIntendedRatio();
            PositionImageAreaSelector();
        }



         void XValueChanged(object sender, EventArgs e)
        {
            if (_consumeValueChangedEvents)
            {
                if (sender.GetType() == typeof(TrackBar))
                {
                    _consumeValueChangedEvents = false;
                    xNumeric.Value = xTrackBar.Value;
                    _selectionToolControl.SetNewXPosition(xTrackBar.Value);
                    _consumeValueChangedEvents = true;
                }
                else
                {
                    _consumeValueChangedEvents = false;
                    xTrackBar.Value = (int)xNumeric.Value;
                    _selectionToolControl.SetNewXPosition((int)xNumeric.Value);
                    _consumeValueChangedEvents = true;
                }
            }
            
        }

         void YValueChanged(object sender, EventArgs e)
        {
            if (_consumeValueChangedEvents)
            {
                if (sender.GetType() == typeof(TrackBar))
                {
                    _consumeValueChangedEvents = false;
                    yNumeric.Value = yTrackBar.Value;
                    _selectionToolControl.SetNewYPosition(yTrackBar.Value, _imageRatio);
                    _consumeValueChangedEvents = true;
                }
                else
                {
                    _consumeValueChangedEvents = false;
                    yTrackBar.Value = (int)yNumeric.Value;
                    _selectionToolControl.SetNewYPosition((int)yNumeric.Value, _imageRatio);
                    _consumeValueChangedEvents = true;
                }
            }
            
        }

         void WValueChanged(object sender, EventArgs e)
        {
            if (_consumeValueChangedEvents)
            {
                if (sender.GetType() == typeof(TrackBar))
                {
                    _consumeValueChangedEvents = false;
                    wNumeric.Value = wTrackBar.Value;
                    _selectionToolControl.SetNewWidth(wTrackBar.Value, _imageRatio);
                    _consumeValueChangedEvents = true;
                }
                else
                {
                    _consumeValueChangedEvents = false;
                    wTrackBar.Value = (int)wNumeric.Value;
                    _selectionToolControl.SetNewWidth((int)wNumeric.Value, _imageRatio);
                    _consumeValueChangedEvents = true;
                }
            }

            
        }

        
    }
}
