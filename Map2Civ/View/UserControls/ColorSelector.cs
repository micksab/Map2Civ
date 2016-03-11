using Map2Civilization.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Map2CivilizationView.UserControls
{
    public partial class ColorSelector : UserControl
    {
        Color _color;
         EventHandler<ColorSelectorValueChangedEventArgs> _colorSelectorValueChanged;

        public Color Color
        {
            get
            {
                return _color;
            }

            set
            {
                _color = value;
                UpdateColorDisplay();
            }
        }

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

        public ColorSelector()
        {
            InitializeComponent();
            UpdateColorDisplay();
        }

        public ColorSelector(Color color)
        {
            InitializeComponent();
            _color = color;
            UpdateColorDisplay();

        }




        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Windows.Forms.Control.set_Text(System.string)")]
         void UpdateColorDisplay()
        {
            colorBox.Text = string.Concat(Convert.ToInt32(_color.R), Resources.Str_ColorSelector_RGBSeparator, 
                Convert.ToInt32(_color.G), Resources.Str_ColorSelector_RGBSeparator
                , Convert.ToInt32(_color.B));

            colorPanel.BackColor = _color;
        }



        

         void colorButton_Click(object sender, EventArgs e)
        {
            using(ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = _color;
                colorDialog.AnyColor = true;
                colorDialog.FullOpen = true;
                colorDialog.SolidColorOnly = true;

                DialogResult result = colorDialog.ShowDialog();

                if(result == DialogResult.OK)
                {
                    _color = colorDialog.Color;
                    UpdateColorDisplay();

                    if (_colorSelectorValueChanged != null)
                    {
                        ColorSelectorValueChangedEventArgs ce = new ColorSelectorValueChangedEventArgs();
                        ce.SelectedColor = _color;
                        _colorSelectorValueChanged(this, ce);
                    }

                }
            }
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
