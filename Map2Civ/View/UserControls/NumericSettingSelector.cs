using System;
using System.Windows.Forms;
using Map2Civilization.Properties;
using System.ComponentModel;
using System.Globalization;

namespace Map2CivilizationView.UserControls
{
    public partial class NumericSettingSelector : UserControl, ISettingControl
    {
        string _propertyName = String.Empty;
        decimal _value = 0;
        EventHandler<EventArgs> _numericSelectorValueChanged;

        public EventHandler<EventArgs> NumericSelectorValueChanged
        {
            get
            {
                return _numericSelectorValueChanged;
            }

            set
            {
                _numericSelectorValueChanged = value;
            }
        }

        

        public NumericSettingSelector()
        {
            InitializeComponent();
        }

        public void AssignNumericProperty(string propertyName)
        {
            _propertyName = propertyName;
            _value = Convert.ToDecimal(Settings.Default[_propertyName], CultureInfo.InvariantCulture);
            this.numericUpDown.Value = _value;

        }

        public decimal Increment
        {
            get
            {
                return numericUpDown.Increment;
            }
            set
            {
                numericUpDown.Increment = value;
            }
        }


        public decimal Minimum
        {
            get
            {
                return numericUpDown.Minimum;
            }
            set
            {
                numericUpDown.Minimum = value;
            }
        }


        public decimal Maximum
        {
            get
            {
                return numericUpDown.Maximum;
            }
            set
            {
                numericUpDown.Maximum = value;
            }
        }

        


        public decimal Value
        {
            get
            {
                return numericUpDown.Value;
            }
            set
            {
                numericUpDown.Value = value;
            }
            
        }

        

        public void SavePropertySetting()
        {
            Type propertyType = Settings.Default[_propertyName].GetType();
            Settings.Default[_propertyName] = Convert.ChangeType(_value, propertyType, CultureInfo.InvariantCulture);
        }

        void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if(_numericSelectorValueChanged != null)
            {
                _numericSelectorValueChanged(this, e);
                _value = numericUpDown.Value;
            }
        }

        
    }
}
