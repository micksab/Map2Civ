using Map2Civilization.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Map2CivilizationView.UserControls
{
    public partial class ColorSettingSelector : UserControl, ISettingControl
    {
        Color _currentlySelectedColor;
        EventHandler<ColorSelectorValueChangedEventArgs> _colorSelectorValueChanged;
        string _propertyName = String.Empty;

        

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
         void UpdateColorDisplay()
        {
            colorBox.Text = string.Concat(Convert.ToInt32(_currentlySelectedColor.R), Resources.Str_ColorSelector_RGBSeparator, 
                Convert.ToInt32(_currentlySelectedColor.G), Resources.Str_ColorSelector_RGBSeparator
                , Convert.ToInt32(_currentlySelectedColor.B));

            colorPanel.BackColor = _currentlySelectedColor;
        }



        

         void colorButton_Click(object sender, EventArgs e)
        {
            using(ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = _currentlySelectedColor;
                colorDialog.AnyColor = true;
                colorDialog.FullOpen = true;
                colorDialog.SolidColorOnly = true;

                DialogResult result = colorDialog.ShowDialog();

                if(result == DialogResult.OK)
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
         Color _color;

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

    #endregion
}
