using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;
using Map2CivilizationCtrl;

using Map2CivilizationCtrl.Enumerations;

namespace Map2CivilizationView
{
    public partial class MassColorEditForm : Form
    {
        private String[] colorIDs;

        public MassColorEditForm(String[] theColorIds )
        {
            InitializeComponent();

            colorIDs = theColorIds;

            StringBuilder sb = new StringBuilder();
            foreach(String color in colorIDs)
            {
                sb.Append(color);
                sb.Append(",");
            }

            colorsTextBox.Text = sb.ToString();

            terrainsCombo.DataSource = Enum.GetValues(typeof(TerrainType.Enumeration));
            terrainsCombo.SelectedIndex = 0;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            TerrainType.Enumeration selectedValue = (TerrainType.Enumeration)terrainsCombo.SelectedValue;
            DetectedColorCollectionCtrl.UpdateDetectedColorsAndRefreshProcessedMap(colorIDs, selectedValue);
            DialogResult = DialogResult.OK;
            Close();
           
        }
    }
}
