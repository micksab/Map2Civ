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

            terrainsCombo.DataSource = Enum.GetValues(typeof(TerrainTypeEnumWrapper.TerrainType));
            terrainsCombo.SelectedIndex = 0;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            TerrainTypeEnumWrapper.TerrainType selectedValue = (TerrainTypeEnumWrapper.TerrainType)terrainsCombo.SelectedValue;
            DetectedColorCollectionCtrl.UpdateDetectedColorsAndRefreshProcessedMap(colorIDs, selectedValue);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}