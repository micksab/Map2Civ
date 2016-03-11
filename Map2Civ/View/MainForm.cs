using System;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using Map2Civilization.Ctrl.ModelFileStorage;
using Map2Civilization.Properties;
using Map2CivilizationCtrl;
using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationCtrl.Listener;
using Map2CivilizationCtrl.ModelFileStorage;
using Map2CivilizationView.UserControls;

namespace Map2CivilizationView
{
    public partial class MainForm :  Form, IUiListenerPlotLocation, IUiListenerCentralForm, IUiListenerDetectedColorsCounter,
        IUiListenerProgress, IUiListenerModel
    {

        
        FeedbackToolstripLabel _feedbackLabel = new FeedbackToolstripLabel();
        ZoomSplitButton _zoomSplitButton = new ZoomSplitButton();

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public MainForm()
        {
            InitializeComponent();
            RegisteredListenersCtrl.CentralFormListeners.RegisterObserver(this);
            RegisteredListenersCtrl.PlotLocationListeners.RegisterObserver(this);
            RegisteredListenersCtrl.DetectedColorsCounters.RegisterObserver(this);
            RegisteredListenersCtrl.ProgressListeners.RegisterObserver(this);
            RegisteredListenersCtrl.ModelListeners.RegisterObserver(this);


            MapControlOriginal originalMapControl = new MapControlOriginal(true);
            originalMapTabPage.Controls.Add(originalMapControl);
            originalMapControl.Location = new Point(0, 0);
            originalMapControl.Dock = DockStyle.Fill;


            MapControlProcessed processedMapControl = new MapControlProcessed(true, ProcessedMapControlMode.Enumeration.ColorEditor);
            splitContainer.Panel1.Controls.Add(processedMapControl);
            processedMapControl.Location = new Point(0, 0);
            processedMapControl.Dock = DockStyle.Fill;


            splitContainer.Panel2.BackgroundImage = Map2Civilization.Properties.Resources.MeasuringTape_Image;
            splitContainer.Panel2.BackgroundImageLayout = ImageLayout.Center;


            

            


            




            toolStrip.Items.Add(_feedbackLabel);
            statusStrip.Items.Add(_zoomSplitButton);

            HandleDestroyed += MainForm_Closing;

        }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Windows.Forms.Control.set_Text(System.String)")]
        public void UpdateCurrentModelFile(string fileName)
        {
            string displayableFilestring = VariousUtilityMethods.ExtractDisplayableModelFilePath(fileName);

            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string productName;
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
            if (attributes.Length == 0)
            {
                productName = "";
            }
            productName = ((AssemblyProductAttribute)attributes[0]).Product;

            string toDisplay = string.Concat(productName, " v", version, " ", "...", displayableFilestring);

            Text = toDisplay;

            
               
        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public void ModelChanged()
        {
            this.civVersionLabel.Text = CivilizationVersion.Singleton.GetEnumValueDescription(ModelCtrl.GetCivilizationVersion());
            this.MapSizeLabel.Text = ModelCtrl.GetMapSize().Description;

            //Check the type of the new model..
            switch (ModelCtrl.GetModelDataSourceType())
            {
                case MapDataSource.Enumeration.GeoDataProvider:
                    throw new NotImplementedException("No implementation for Geo-Data Source Settings.");
                case MapDataSource.Enumeration.ReliefMapImage:
                    //Clear any existing control from the data manipulation panel
                    foreach(Control tempControl in splitContainer.Panel2.Controls)
                    {
                        tempControl.Dispose();
                    }
                    splitContainer.Panel2.Controls.Clear();
                    //... and add a DetectedColorsGrid control in it.
                    splitContainer.Panel2.BackgroundImage = null;
                    DetectedColorsGrid gridControl = new DetectedColorsGrid();
                    gridControl.Location = new Point(0, 0);
                    gridControl.Dock = DockStyle.Fill;
                    splitContainer.Panel2.Controls.Add(gridControl);
                    return;
            }

        }


         void MainForm_Closing(object sender, EventArgs e)
        {
            RegisteredListenersCtrl.PlotLocationListeners.DeregisterObserver(this);
            RegisteredListenersCtrl.CentralFormListeners.DeregisterObserver(this);
            RegisteredListenersCtrl.ProgressListeners.DeregisterObserver(this);
            RegisteredListenersCtrl.ModelListeners.DeregisterObserver(this);

        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Windows.Forms.ToolStripItem.set_Text(System.string)")]
        public void UpdatePlotLocation(PlotId id)
        {
            
            selectedPlotLabel.Text = id.Name;

            PointF plotPixelCoordinates = GridCoordinateHelperCtrl.ConvertPlotIdToPixelLocation(id, true);
            plotCoordinatesLabel.Text = string.Concat(plotPixelCoordinates.X, Resources.Str_MainForm_CoordinateSeparator, plotPixelCoordinates.Y);

        }

        public void UpdateColorListCount(int count)
        {
            colorCountLabel.Text = string.Concat(count);
        }


        public void SetMapSizeLabel(MapDimension mapSize)
        {
            MapSizeLabel.Text = mapSize.Description;   
        }


        public void UpdateMapSize(MapDimension mapSize)
        {
            SetMapSizeLabel(mapSize);
        }


        public void UpdateAssignedPercentComplete()
        {
            double percent = ModelCtrl.GetAssignedPercentComplete();
            percentCompleteLabel.Text = percent.ToString("F", CultureInfo.CurrentCulture);
            if (Math.Abs(percent - 100d) > Double.Epsilon)
            {
                percentCompleteLabel.ForeColor = Color.Red;
                exportToCivMap.Enabled = false;
                exportToCivStripMenuItem.Enabled = false;

            }
            else
            {
                percentCompleteLabel.ForeColor = Color.Teal;
                exportToCivMap.Enabled = true;
                exportToCivStripMenuItem.Enabled = true;

            }
        }

         void About_Click(object sender, EventArgs e)
        {
            using (AboutBox aboutForm = new AboutBox())
            {
                aboutForm.ShowDialog();

            }
        }




        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
         void SaveModel_Click(object sender, EventArgs e)
        {
            string currentFile = ModelCtrl.GetCurrentModelFile();
            if (!string.IsNullOrEmpty(currentFile))
            {
                SaveModelProcessor.StartProcess(currentFile);
                //Due to the asynchronous nature of model (it is based on instances of Backgroundworker)
                // disposal of the instance is performed inside the instance itself as soon 
                // as the operation is complete

            }
            else
            {
                SaveAsModel_Click(this, new EventArgs());
            }
            
        }

         void SaveAsModel_Click(object sender, EventArgs e)
        {
            using(SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = Resources.Str_OpenFileDialogFilter;
                saveFileDialog.DefaultExt = Resources.Str_OpenFileDialogDefaultExt;
                DialogResult result = saveFileDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrEmpty(saveFileDialog.FileName))
                {
                    //SaveLoadModel model = new SaveLoadModel();
                    SaveModelProcessor.StartProcess(saveFileDialog.FileName);
                    //Due to the asynchronous nature of model (it is based on instances of Backgroundworker)
                    // disposal of the instance is performed inside the instance itself as soon 
                    // as the operation is complete
                }
            }
            
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
         void LoadModel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = Resources.Str_OpenFileDialogFilter;
                openFileDialog.DefaultExt = Resources.Str_OpenFileDialogDefaultExt;
                DialogResult result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrEmpty(openFileDialog.FileName))
                {
                   LoadModelProcessor.StartProcess(openFileDialog.FileName);
                    //Due to the asynchronous nature of model (it is based on instances of Backgroundworker)
                    // disposal of the instance is performed inside the instance itself as soon 
                    // as the operation is complete
                }
            }
        }

         void NewModel_Click(object sender, EventArgs e)
        {
            using (NewMapForm startForm = new NewMapForm())
            {
                startForm.ShowDialog();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "Civ")]
         void ExportToCivMap_Click(object sender, EventArgs e)
        {
            using(SaveFileDialog exportFileDialog = new SaveFileDialog())
            {
                exportFileDialog.Filter = CivilizationVersion.Singleton.GetSaveFileFilter(ModelCtrl.GetCivilizationVersion());
                exportFileDialog.DefaultExt = CivilizationVersion.Singleton.GetSaveFileDefaultExtension(ModelCtrl.GetCivilizationVersion());

                DialogResult result = exportFileDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrEmpty(exportFileDialog.FileName))
                {
                    ExporterBase exporter = ExporterBase.GetExporter(ModelCtrl.GetCivilizationVersion());
                    exporter.ExportModel(ModelCtrl.GetDataModel(), exportFileDialog.FileName);
                   
                }
            }
        }

        

         void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.KeyCode == Keys.N && e.Control)
            {
                NewModel_Click(this, new EventArgs());
            }
            else if (e.Control && e.Shift && e.KeyCode == Keys.S)
            {
                SaveAsModel_Click(this, new EventArgs());
            }
            else if (e.KeyCode == Keys.S && e.Control)
            {
                SaveModel_Click(this, new EventArgs());
            }
            else if (e.KeyCode == Keys.O && e.Control)
            {
                LoadModel_Click(this, new EventArgs());

            }
            else if (e.KeyCode == Keys.E && e.Control)
            {
                ExportToCivMap_Click(this, new EventArgs());

            }
        }


       
        public void ProgressStarted()
        {
            buttonsPanel.Enabled = false;
        }

        public void ProgressFinished()
        {
            buttonsPanel.Enabled = true;
            progressBar.Value = 0;
        }


        public void SetProgressPercent(int percent)
        {
            progressBar.Value = percent;
        }


        

        public void PublishNewInfoMessage(string infoMessage)
        {
            _feedbackLabel.AddFeedbackMessage(infoMessage);

        }


        public void SetModelButtonAndMenusEnabledState(Boolean saveActive, Boolean saveAsActive)
        {
            saveButton.Enabled = saveActive;
            saveAsButton.Enabled = saveAsActive;
            saveStripMenuItem.Enabled = saveActive;
            saveAsStripMenuItem.Enabled = saveAsActive;
            zoomInButton.Enabled = true;
            zoomOutButton.Enabled = true;
            _zoomSplitButton.Enabled = true;
            zoomDefaultButton.Enabled = true;
        }

        

        


       

         void zoomInButton_Click(object sender, EventArgs e)
        {
            float newZoomFactor = GridCoordinateHelperCtrl.GetNextZoomInFactor();
            RegisteredListenersCtrl.ZoomChangedUpdate(newZoomFactor);
        }

         void zoomOutButton_Click(object sender, EventArgs e)
        {
            float newZoomFactor = GridCoordinateHelperCtrl.GetNextZoomOutFactor();
            RegisteredListenersCtrl.ZoomChangedUpdate(newZoomFactor);
        }

         void settingsButton_Click(object sender, EventArgs e)
        {
            using (SettingsForm settingsForm = new SettingsForm())
            {
                settingsForm.ShowDialog();
            }
        }

         void defaultZoomButton_Click(object sender, EventArgs e)
        {
            RegisteredListenersCtrl.ZoomChangedUpdate(1f);
        }
    }
}
