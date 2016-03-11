using System;
using System.Drawing;
using System.Windows.Forms;
using Map2Civilization.Properties;
using Map2CivilizationCtrl.Enumerations;

namespace Map2CivilizationView.UserControls
{
    public partial class CustomEnumComboBox : UserControl
    {
        
        EventHandler _selectedIndexChanged;
        IEnrichedEnumWrapper _dataSource;

        public EventHandler SelectedIndexChanged
        {
            get
            {
                return _selectedIndexChanged;
            }

            set
            {
                _selectedIndexChanged = value;
            }
        }

        public CustomEnumComboBox()
        {
            InitializeComponent();
        }

        

        public void SetEnumDataSource(IEnrichedEnumWrapper source)
        {
            comboBox.Items.Clear();
            if (source != null)
            {
                _dataSource = source;

                foreach (Enum tempEnumValue in Enum.GetValues(source.EnumType))
                {
                    comboBox.Items.Add(tempEnumValue);
                }

                SelectDefaultEnumEntry(source.EnumType);

            }

           
        }


        public Enum SelectedItem
        {
            get
            {
                return (Enum)comboBox.SelectedItem;
            }
            
        }

        //Using code found at http://stackoverflow.com/questions/11445125/disabling-particular-items-in-a-combobox
        private void comboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                using(Font myFont = System.Drawing.SystemFonts.DefaultFont)
                {
                    Enum selectedEnum = (Enum)comboBox.Items[e.Index];
                    Boolean isEnabled = _dataSource.GetEnumValueEnabledStatus(selectedEnum);
                    String displayText = _dataSource.GetEnumValueDescription(selectedEnum);

                    if (!isEnabled)
                    {
                        e.Graphics.DrawString(displayText, myFont, Brushes.LightGray, e.Bounds);
                    }
                    else
                    {
                        e.DrawBackground();
                         
                        e.Graphics.DrawString(displayText, myFont, Brushes.Black, e.Bounds);
                        e.DrawFocusRectangle();
                    }
                }

               
            }
           
            
        }

        //Using code found at http://stackoverflow.com/questions/11445125/disabling-particular-items-in-a-combobox
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox.SelectedIndex >= 0)
            {
                Enum selectedEnum = (Enum)comboBox.Items[comboBox.SelectedIndex];
                Boolean isEnabled = _dataSource.GetEnumValueEnabledStatus(selectedEnum);


                switch(isEnabled)
                {
                    case false:
                    String displayText = _dataSource.GetEnumValueDescription(selectedEnum);
                    CultureAwareMessageBox.Show(Resources.Str_ExporterBase_NotSupportedMessagePart1 +
                        displayText+Resources.Str_ExporterBase_NotSupportedMessagePart2, 
                        Resources.Str_ExporterBase_NotSupportedCaption, MessageBoxButtons.OK, 
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    SelectDefaultEnumEntry(selectedEnum.GetType());
                        break;
                    default:
                        if (SelectedIndexChanged != null)
                        {
                            SelectedIndexChanged(this, e);
                        }
                        break;
                }
            }


        }


        private void SelectDefaultEnumEntry(Type enumType)
        {
            foreach (Enum tempEnum in Enum.GetValues(enumType))
            {
                Boolean tempEnumDefault = _dataSource.GetEnumValueDefaultStatus(tempEnum);

                if (tempEnumDefault)
                {
                    comboBox.SelectedItem = tempEnum;
                }
            }
        }

    }
}
