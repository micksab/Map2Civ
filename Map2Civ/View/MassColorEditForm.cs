using Map2CivilizationCtrl;
using Map2CivilizationCtrl.Enumerations;
using System;
using System.Text;
using System.Windows.Forms;

namespace Map2CivilizationView
{
    public partial class MassColorEditForm : Form
    {
        private string[] colorIDs;

        public MassColorEditForm(string[] theColorIds)
        {
            InitializeComponent();

            colorIDs = theColorIds;

            StringBuilder sb = new StringBuilder();
            foreach (string color in colorIDs)
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