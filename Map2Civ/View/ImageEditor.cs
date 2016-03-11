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
        private Bitmap _originalBmp;
        private double _intendedRatio;
        private double _imageRatio;
        private double _panelRatio;
        private Boolean _consumeValueChangedEvents = true;

        UserControls.ImageAreaSelector _selectionToolControl;

        public ImageEditor(Bitmap image, double intendedRatio)
        {
            InitializeComponent();

            _intendedRatio = intendedRatio;

            intentedRatioLabel.Text = Resources.Str_ImageEditor_IntendedRatio +
                _intendedRatio.ToString("N6", Thread.CurrentThread.CurrentCulture);

            if (image != null)
            {
                _originalBmp = (Bitmap)image.Clone();
               
                CalculatePanelRatio();
                _selectionToolControl = new UserControls.ImageAreaSelector(_intendedRatio, this);
                imagePanel.Controls.Add(_selectionToolControl);

                setImage(_originalBmp);
                EvaluateIntendedRatio();
            }
            else
            {
                throw new ArgumentNullException(nameof(image));
            }
        }


       


        private void PositionImageAreaSelector()
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


        private Boolean EvaluateIntendedRatio()
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


        private void CalculateImageRatio()
        {
             _imageRatio = (double)_selectionToolControl.BackgroundImage.Width / (double)_selectionToolControl.BackgroundImage.Height;
        }

        private void CalculatePanelRatio()
        {
             _panelRatio = (double)imagePanel.Width / (double)imagePanel.Height;
        }


        


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public Bitmap GetBitmapToProcess()
        {
            Bitmap toReturn = null;

            if (_selectionToolControl.SelectorIsVisible==false && DialogResult == DialogResult.OK)
            {
                toReturn = (Bitmap)_selectionToolControl.BackgroundImage.Clone();
            }
            else if(_selectionToolControl.SelectorIsVisible == true && DialogResult== DialogResult.OK)
            {
                toReturn = (Bitmap)_selectionToolControl.GetSelectedAreaImage().Clone();
            }

            toReturn.SetResolution(96, 96);
            return toReturn;
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



        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }




        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "px")]
        private void showImageSize(Bitmap bmp)
        {
            imageWidthLabel.Text = String.Concat(Resources.Str_ImageEditor_ImageWidth, bmp.Width, 
                Resources.Str_ImageEditor_ImagePixels);
            imageHeightLabel.Text = String.Concat(Resources.Str_ImageEditor_ImageHeight, bmp.Height,
                Resources.Str_ImageEditor_ImagePixels);
        }


        

        private void setImage(Bitmap bmp)
        {
            _selectionToolControl.BackgroundImage = bmp;
            showImageSize(bmp);
            CalculateImageRatio();
            PositionImageAreaSelector();
        }

        private void resizeButton_Click(object sender, EventArgs e)
        {
            using (CanvasSizeForm canvasForm = new CanvasSizeForm(_originalBmp.Size, _intendedRatio))
            {
                DialogResult result = canvasForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Size toResize = canvasForm.GetCanvasWidthHeight();
                    Color toApply = canvasForm.GetBackgroundColor();
                    Bitmap newImage = BitmapOperationsCtrl.ResizeCanvas(_originalBmp, toApply, toResize.Width, toResize.Height);
                    setImage(newImage);
                    EvaluateIntendedRatio();
                }
            }

                
        }

        private void selectAreaButton_Click(object sender, EventArgs e)
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

        

        private void imagePanel_Resize(object sender, EventArgs e)
        {
            EvaluateIntendedRatio();
            PositionImageAreaSelector();
        }



        private void xValueChanged(object sender, EventArgs e)
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

        private void yValueChanged(object sender, EventArgs e)
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

        private void wValueChanged(object sender, EventArgs e)
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
