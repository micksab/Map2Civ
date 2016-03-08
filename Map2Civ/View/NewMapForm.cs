using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Map2CivilizationCtrl.Listener;
using Map2CivilizationCtrl;
using Map2CivilizationView.UserControls;

using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationCtrl.Analyzer;
using Map2CivilizationModel;
using Map2Civilization.Properties;

namespace Map2CivilizationView
{
    public partial class NewMapForm : Form, IUiListenerProgress
    {

        private GridType.Enumeration _gridTypeValue;

        public NewMapForm()
        {
            InitializeComponent();

            this.versionCustomEnumComboBox.SelectedIndexChanged += SelectedCivVersionChanged;
            this.dataSourceCustomEnumComboBox.SelectedIndexChanged += SelectedSourceTypeChanged;
            //Set the data sources for the custom combos..
            this.versionCustomEnumComboBox.SetEnumDataSource(CivilizationVersion.Singleton);
            this.dataSourceCustomEnumComboBox.SetEnumDataSource(MapDataSource.Singleton);

            //Raise a couple of events to let all controls sync their status...
            mapSizeComboBox_SelectedValueChanged(this, new EventArgs());
            SelectedCivVersionChanged(this, new EventArgs());

            RegisteredListenersCtrl.ProgressListeners.RegisterObserver(this);
        }



        private void SelectedCivVersionChanged(Object sender, EventArgs e)
        {
            CivilizationVersion.Enumeration version = 
                (CivilizationVersion.Enumeration)versionCustomEnumComboBox.SelectedItem;

            mapSizeComboBox.DataSource = CivilizationVersion.Singleton.GetVersionMapDimensions(
                        version);
            mapSizeComboBox.DisplayMember = "Description";
            SelectDefaultMapSize();

            GridType.Enumeration gridTypeEnum = CivilizationVersion.Singleton.GetVersionGridType(version);
            _gridTypeValue = gridTypeEnum;
            gridTypeBox.Text = GridType.Singleton.GetEnumValueDescription(gridTypeEnum);

            foreach(Control tempControl in this.extraOptionsPanel.Controls)
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

            if (dataSourceCustomEnumComboBox.SelectedItem.Equals(MapDataSource.Enumeration.ReliefMapImage))
            {
                settingsControlToAdd = new UserControls.SourceSettingsControlReliefMap();
                extraOptionsPanel.Controls.Add(settingsControlToAdd);
                settingsControlToAdd.Location = new Point(0, 0);
                createButton.Enabled = true;
            }
            else if (dataSourceCustomEnumComboBox.SelectedItem.Equals(MapDataSource.Enumeration.GeoDataProvider))
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
            
            foreach(Control tempControl in this.extraOptionsPanel.Controls)
            {
                ((SourceSettingsControlBase)tempControl).SelectedMapDimension = (MapDimension)this.mapSizeComboBox.SelectedItem;
            }
        }



        #region IUIListener_Progress method implementations

        public void SetProgressPercent(int percent)
        {
            progressBar.Value = percent;
            progressLabel.Text = String.Concat(Resources.Str_NewMapForm_AnalysingPlotsPart1, percent, 
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
            progressLabel.Text = String.Empty;
        }

        #endregion




        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void NewMapForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RegisteredListenersCtrl.ProgressListeners.DeregisterObserver(this);
        }


        private void nextButton_Click(object sender, EventArgs e)
        {
            try
            {

                ISourceMapSettings settings = ((SourceSettingsControlBase)extraOptionsPanel.Controls[0]).Settings;

                AnalyzerFactory analyser = AnalyzerFactory.GetAnalyzer(settings, _gridTypeValue, 
                    (MapDimension)mapSizeComboBox.SelectedItem, (CivilizationVersion.Enumeration)versionCustomEnumComboBox.SelectedItem);

                analyser.AnalyzeData();

            }
            catch (InvalidOperationException ioe)
            {
                using(ErrorForm errorForm = new ErrorForm(false, String.Empty, ioe))
                {
                    errorForm.ShowDialog();
                }
            }
            catch(NotImplementedException nie)
            {
                using (ErrorForm errorForm = new ErrorForm(false, String.Empty, nie))
                {
                    errorForm.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                using (ErrorForm errorForm = new ErrorForm(true, Resources.Str_NewMapForm_UnhandledError, ex)) 
                {
                    errorForm.ShowDialog();
                }
            }
        }


    }
}



