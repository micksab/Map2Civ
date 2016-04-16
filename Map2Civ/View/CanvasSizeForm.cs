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

        public Size CanvasSize
        {
            get
            {
                Size toReturn;

                if (nearestRadio.Checked)
                {
                    double imageRatio = (double)_minWidth / (double)_minHeight;

                    if (_intentedRatio <= imageRatio)
                    {
                        //We need to adjust the height
                        double newHeight = _imageSize.Width / _intentedRatio;

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
            
        }

        public Color CanvasBackgroundColor
        {
            get
            {
                return _backColor;

            }
        }

        #endregion Public methods

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

            if (result == DialogResult.OK)
            {
                Color newColor = colorDialog.Color;
                colorPanel.BackColor = newColor;
                _backColor = newColor;
            }
        }

        #endregion Event Handlers
    }
}