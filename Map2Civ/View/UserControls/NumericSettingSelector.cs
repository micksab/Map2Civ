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
using System.Globalization;
using System.Windows.Forms;

namespace Map2CivilizationView.UserControls
{
    public partial class NumericSettingSelector : UserControl, ISettingControl
    {
        private string _propertyName = String.Empty;
        private decimal _value = 0;
        private EventHandler<EventArgs> _numericSelectorValueChanged;

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

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (_numericSelectorValueChanged != null)
            {
                _numericSelectorValueChanged(this, e);
                _value = numericUpDown.Value;
            }
        }
    }
}