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
using Map2CivilizationCtrl;
using Map2CivilizationCtrl.Analyzer;
using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationCtrl.Listener;
using Map2CivilizationView.UserControls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Map2CivilizationView
{
    public partial class NewMapForm : Form, IUiListenerProgress
    {
        private GridTypeEnumWrapper.GridType _gridTypeValue;

        public NewMapForm()
        {
            InitializeComponent();

            this.versionCustomEnumComboBox.SelectedIndexChanged += SelectedCivVersionChanged;
            this.dataSourceCustomEnumComboBox.SelectedIndexChanged += SelectedSourceTypeChanged;
            //Set the data sources for the custom combos..
            this.versionCustomEnumComboBox.SetEnumDataSource(CivilizationVersionEnumWrapper.Singleton);
            this.dataSourceCustomEnumComboBox.SetEnumDataSource(MapDataSourceEnumWrapper.Singleton);

            //Raise a couple of events to let all controls sync their status...
            mapSizeComboBox_SelectedValueChanged(this, new EventArgs());
            SelectedCivVersionChanged(this, new EventArgs());

            RegisteredListenersCtrl.ProgressListeners.RegisterObserver(this);
        }

        private void SelectedCivVersionChanged(Object sender, EventArgs e)
        {
            CivilizationVersionEnumWrapper.CivilizationVersion version =
                (CivilizationVersionEnumWrapper.CivilizationVersion)versionCustomEnumComboBox.SelectedItem;

            mapSizeComboBox.DataSource = CivilizationVersionEnumWrapper.Singleton.GetVersionMapDimensions(
                        version);
            mapSizeComboBox.DisplayMember = "Description";
            SelectDefaultMapSize();

            GridTypeEnumWrapper.GridType gridTypeEnum = CivilizationVersionEnumWrapper.Singleton.GetVersionGridType(version);
            _gridTypeValue = gridTypeEnum;
            gridTypeBox.Text = GridTypeEnumWrapper.Singleton.GetEnumValueDescription(gridTypeEnum);

            foreach (Control tempControl in this.extraOptionsPanel.Controls)
            {
                ((SourceSettingsControlBase)tempControl).SelectedGridType = gridTypeEnum;
            }
        }

        private void SelectDefaultMapSize()
        {
            foreach (Object tempItem in mapSizeComboBox.Items)
            {
                if (((MapDimension)tempItem).IsDefault)
                {
                    mapSizeComboBox.SelectedItem = tempItem;
                    break;
                }
            }
        }

        private void SelectedSourceTypeChanged(Object sender, EventArgs e)
        {
            //Dispose of the controls that are currently being displayed
            for (int i = extraOptionsPanel.Controls.Count - 1; i >= 0; --i)
            {
                extraOptionsPanel.Controls[i].Dispose();
            }

            extraOptionsPanel.Controls.Clear();
            createButton.Enabled = false;
            SourceSettingsControlBase settingsControlToAdd;

            if (dataSourceCustomEnumComboBox.SelectedItem.Equals(MapDataSourceEnumWrapper.MapDataSource.ReliefMapImage))
            {
                settingsControlToAdd = new UserControls.SourceSettingsControlReliefMap(this);
                extraOptionsPanel.Controls.Add(settingsControlToAdd);
                settingsControlToAdd.Location = new Point(0, 0);
                createButton.Enabled = true;
            }
            else if (dataSourceCustomEnumComboBox.SelectedItem.Equals(MapDataSourceEnumWrapper.MapDataSource.GeoDataProvider))
            {
                settingsControlToAdd = new UserControls.SourceSettingsControlGeoData();
                extraOptionsPanel.Controls.Add(settingsControlToAdd);
                settingsControlToAdd.Location = new Point(0, 0);
                createButton.Enabled = true;
            }
            else
            {
                throw new InvalidEnumArgumentException("Unexpected enum entry in combo box 'Data Source Type'");
            }
        }

        private void mapSizeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (Control tempControl in this.extraOptionsPanel.Controls)
            {
                ((SourceSettingsControlBase)tempControl).SelectedMapDimension = (MapDimension)this.mapSizeComboBox.SelectedItem;
            }
        }

        #region IUIListener_Progress method implementations

        public void SetProgressPercent(int percent)
        {
            progressBar.Value = percent;
            progressLabel.Text = string.Concat(Resources.Str_NewMapForm_AnalysingPlotsPart1, percent,
                Resources.Str_NewMapForm_AnalysingPlotsPart2);
        }

        public void ProgressStarted()
        {
            foreach (Control temp in Controls)
            {
                temp.Enabled = false;
            }

            progressLabel.Enabled = true;
            progressLabel.Text = Resources.Str_NewMapForm_CreatingAnalysisImage;
        }

        public void ProgressFinished()
        {
            Close();
            progressLabel.Enabled = false;
            progressLabel.Text = string.Empty;
        }

        #endregion IUIListener_Progress method implementations

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void NewMapForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RegisteredListenersCtrl.ProgressListeners.DeregisterObserver(this);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        private void nextButton_Click(object sender, EventArgs e)
        {
            try
            {
                ISourceMapSettings settings = ((SourceSettingsControlBase)extraOptionsPanel.Controls[0]).Settings;

                AnalyzerFactory analyser = AnalyzerFactory.GetAnalyzer(settings, _gridTypeValue,
                    (MapDimension)mapSizeComboBox.SelectedItem, (CivilizationVersionEnumWrapper.CivilizationVersion)versionCustomEnumComboBox.SelectedItem);

                analyser.AnalyzeData();
            }
            catch (InvalidOperationException ioe)
            {
                using (ErrorForm errorForm = new ErrorForm(false, string.Empty, ioe))
                {
                    errorForm.ShowDialog();
                }
            }
            catch (NotImplementedException nie)
            {
                using (ErrorForm errorForm = new ErrorForm(false, string.Empty, nie))
                {
                    errorForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                using (ErrorForm errorForm = new ErrorForm(true, Resources.Str_NewMapForm_UnhandledError, ex))
                {
                    errorForm.ShowDialog();
                }
            }
        }
    }
}