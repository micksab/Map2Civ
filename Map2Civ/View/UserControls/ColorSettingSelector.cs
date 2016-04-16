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


using Map2Civilization.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Map2CivilizationView.UserControls
{
    public partial class ColorSettingSelector : UserControl, ISettingControl
    {
        private Color _currentlySelectedColor;
        private EventHandler<ColorSelectorValueChangedEventArgs> _colorSelectorValueChanged;
        private string _propertyName = String.Empty;

        public EventHandler<ColorSelectorValueChangedEventArgs> ColorSelectorValueChanged
        {
            get
            {
                return _colorSelectorValueChanged;
            }

            set
            {
                _colorSelectorValueChanged = value;
            }
        }

        public ColorSettingSelector()
        {
            InitializeComponent();
            UpdateColorDisplay();
        }

        public void AssignColorProperty(string propertyName)
        {
            _propertyName = propertyName;
            _currentlySelectedColor = (Color)Settings.Default[_propertyName];
            UpdateColorDisplay();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Windows.Forms.Control.set_Text(System.string)")]
        private void UpdateColorDisplay()
        {
            colorBox.Text = string.Concat(Convert.ToInt32(_currentlySelectedColor.R), Resources.Str_ColorSelector_RGBSeparator,
                Convert.ToInt32(_currentlySelectedColor.G), Resources.Str_ColorSelector_RGBSeparator
                , Convert.ToInt32(_currentlySelectedColor.B));

            colorPanel.BackColor = _currentlySelectedColor;
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = _currentlySelectedColor;
                colorDialog.AnyColor = true;
                colorDialog.FullOpen = true;
                colorDialog.SolidColorOnly = true;

                DialogResult result = colorDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    _currentlySelectedColor = colorDialog.Color;
                    UpdateColorDisplay();

                    if (_colorSelectorValueChanged != null)
                    {
                        ColorSelectorValueChangedEventArgs ce = new ColorSelectorValueChangedEventArgs();
                        ce.SelectedColor = _currentlySelectedColor;
                        _colorSelectorValueChanged(this, ce);
                    }
                }
            }
        }

        public void SavePropertySetting()
        {
            Settings.Default[_propertyName] = _currentlySelectedColor;
        }
    }

    #region EventArgs definition for custom ColorSelectorValueChanged event of the user control.

    public class ColorSelectorValueChangedEventArgs : EventArgs
    {
        private Color _color;

        public Color SelectedColor
        {
            get
            {
                return _color;
            }

            set
            {
                _color = value;
            }
        }
    }

    #endregion EventArgs definition for custom ColorSelectorValueChanged event of the user control.
}