using System;
using System.Drawing;

using System.Windows.Forms;


namespace Map2CivilizationView
{
    public partial class CanvasSizeForm : Form
    {
        private int _minWidth;
        private int _minHeight;
        private double _intentedRatio;
        private Size _imageSize;
        private Color _backColor = Color.Blue;

        public CanvasSizeForm(Size imageSize, double intendedRatio)
        {
            InitializeComponent();
            _intentedRatio = intendedRatio;
            _imageSize = imageSize;

            _minWidth = _imageSize.Width;
            _minHeight = _imageSize.Height;

            widthNumeric.Minimum = _minWidth;
            heightNumeric.Minimum = _minHeight;
            colorPanel.BackColor = _backColor;

        }

        #region Public methods

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public Size GetCanvasWidthHeight()
        {
            Size toReturn;

            if (nearestRadio.Checked)
            {
                double imageRatio = (double)_minWidth / (double)_minHeight;

                if (_intentedRatio <= imageRatio)
                {
                    //We need to adjust the height
                    double newHeight = _imageSize.Width/ _intentedRatio;

                    toReturn = new Size(_imageSize.Width, (int)newHeight);
                }
                else
                {
                    //We need to adjust the width
                    double newWidth = _imageSize.Height * _intentedRatio;

                    toReturn = new Size((int)newWidth, _imageSize.Height);
                }
            }
            else
            {
                toReturn = new Size((int)widthNumeric.Value, (int)heightNumeric.Value);
            }

            
            return toReturn;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public Color GetBackgroundColor()
        {
            return _backColor;
        }

        #endregion


        #region Event Handlers

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void radioCheckedChanged(object sender, EventArgs e)
        {
            if (nearestRadio.Checked)
            {
                sizeGroupBox.Enabled = false;
            }
            else
            {
                sizeGroupBox.Enabled = true;
            }
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog.ShowDialog();

            if(result == DialogResult.OK)
            {
                Color newColor = colorDialog.Color;
                colorPanel.BackColor = newColor;
                _backColor = newColor;
            }
        }

        #endregion
    }
}
