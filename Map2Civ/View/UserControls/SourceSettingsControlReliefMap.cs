using Map2Civilization.Properties;
using Map2CivilizationCtrl.Analyzer;
using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Enumerations;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Map2CivilizationView.UserControls
{
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<SourceSettingsControlBase, UserControl>))]
    public partial class SourceSettingsControlReliefMap : SourceSettingsControlBase
    {
        private Bitmap _mapBitmap;
        private MapDimension _mapDimension;
        private GridType.Enumeration _gridTypeEnum;
        private Form _ownerForm;

        public SourceSettingsControlReliefMap(Form ownerForm)
        {
            InitializeComponent();
            PopulateListBoxes();
            _ownerForm = ownerForm;
        }

        override public MapDimension SelectedMapDimension
        {
            set
            {
                _mapDimension = value;
                if (_mapBitmap != null)
                {
                    _mapBitmap = CheckImageDimensionsCompatibility(_mapBitmap);
                }
            }
            get
            {
                return _mapDimension;
            }
        }

        public override GridType.Enumeration SelectedGridType
        {
            set
            {
                _gridTypeEnum = value;
            }
            get
            {
                return _gridTypeEnum;
            }
        }

        private void PopulateListBoxes()
        {
            colorDepthBox.DataSource = Enum.GetValues(typeof(System.Drawing.Imaging.PixelFormat));

            interpolationBox.DataSource = Enum.GetValues(typeof(System.Drawing.Drawing2D.InterpolationMode));
            composingQualityBox.DataSource = Enum.GetValues(typeof(System.Drawing.Drawing2D.CompositingQuality));
            smoothingModeBox.DataSource = Enum.GetValues(typeof(System.Drawing.Drawing2D.SmoothingMode));

            SetRestoreDefaultValues();
        }

        private void SetRestoreDefaultValues()
        {
            colorDepthBox.SelectedItem = System.Drawing.Imaging.PixelFormat.Format8bppIndexed;
            interpolationBox.SelectedItem = System.Drawing.Drawing2D.InterpolationMode.Default;
            composingQualityBox.SelectedItem = System.Drawing.Drawing2D.CompositingQuality.Default;
            smoothingModeBox.SelectedItem = System.Drawing.Drawing2D.SmoothingMode.Default;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Windows.Forms.FileDialog.set_Filter(System.String)")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "png")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Windows.Forms.FileDialog.set_Filter(System.string)")]
        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image files (*.bmp, *.jpg, *.jpeg, *.png)|*.bmp;*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 0;
                    openFileDialog.Multiselect = false;

                    if (openFileDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(openFileDialog.FileName))
                    {
                        string selectedFile = openFileDialog.FileNames[0];
                        pathBox.Text = selectedFile;

                        using (Bitmap toProc = (Bitmap)Image.FromFile(openFileDialog.FileName))
                        {
                            toProc.SetResolution(96, 96);
                            _mapBitmap = new Bitmap(toProc.Width, toProc.Height);

                            using (Graphics g = Graphics.FromImage(_mapBitmap))
                            {
                                g.DrawImageUnscaled(toProc, 0, 0);
                            }

                            _mapBitmap.SetResolution(96, 96);

                            _mapBitmap = CheckImageDimensionsCompatibility(_mapBitmap);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                using (ErrorForm toShow = new ErrorForm(true, Resources.Str_SourceSettingsControlReliefMap_ErrorOpeningFile, ex))
                {
                    toShow.ShowDialog();
                }
            }
        }

        override public string SettingsAreComplete
        {
            get
            {
                switch (string.IsNullOrEmpty(pathBox.Text))
                {
                    case true:
                        return Resources.Str_SourceSettingsControlReliefMap_NoImageSelected;

                    default:
                        return string.Empty;
                }
            }
        }

        override public ISourceMapSettings Settings
        {
            get
            {
                string completeCheckResult = SettingsAreComplete;
                if (string.IsNullOrEmpty(completeCheckResult))
                {
                    SourceReliefMapSettings settings;

                    settings = new SourceReliefMapSettings(_mapBitmap,
                        (System.Drawing.Imaging.PixelFormat)colorDepthBox.SelectedItem,
                        (System.Drawing.Drawing2D.InterpolationMode)interpolationBox.SelectedItem,
                        (System.Drawing.Drawing2D.CompositingQuality)composingQualityBox.SelectedItem,
                        (System.Drawing.Drawing2D.SmoothingMode)smoothingModeBox.SelectedItem);

                    return (ISourceMapSettings)settings;
                }
                else
                {
                    throw new InvalidOperationException(completeCheckResult);
                }
            }
        }

        private void defaultCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (defaultCheck.Checked)
            {
                SetRestoreDefaultValues();
            }

            colorDepthBox.Enabled = !defaultCheck.Checked;
            depthLabel.Enabled = !defaultCheck.Checked;
            interpolationBox.Enabled = !defaultCheck.Checked;
            interpolationLabel.Enabled = !defaultCheck.Checked;
            composingQualityBox.Enabled = !defaultCheck.Checked;
            compositingLabel.Enabled = !defaultCheck.Checked;
            smoothingModeBox.Enabled = !defaultCheck.Checked;
            smoothingLabel.Enabled = !defaultCheck.Checked;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2001:AvoidCallingProblematicMethods", MessageId = "System.GC.Collect")]
        private Bitmap CheckImageDimensionsCompatibility(Bitmap sourceImage)
        {
            double modelRatio = GridType.Singleton.GetMapRatio(_gridTypeEnum, _mapDimension.WidthPlots, _mapDimension.HeightPlots);
            double imageRatio = (double)sourceImage.Width / (double)sourceImage.Height;

            //Allow for 1% tolerance..
            if (imageRatio <= (modelRatio * (1.01d)) && imageRatio >= (modelRatio * (0.99d)))
            {
                return sourceImage;
            }
            else
            {
                DialogResult result = CultureAwareMessageBox.Show(Resources.Str_SourceSettingsControlReliefMap_ImageSizeMsgBoxWaringText,
                        Resources.Str_SourceSettingsControlReliefMap_ImageSizeMsgBoxWaringCaption,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.No)
                {
                    return sourceImage;
                }
                else
                {
                    Bitmap toReturn;
                    using (ImageEditor editorForm = new ImageEditor(sourceImage, modelRatio))
                    {
                        DialogResult editorResult = editorForm.ShowDialog(_ownerForm);
                        

                        switch (editorResult)
                        {
                            case DialogResult.OK:
                                toReturn = editorForm.GetBitmapToProcess();
                                break;

                            case DialogResult.Cancel:
                                toReturn = sourceImage;
                                break;

                            default:
                                throw new InvalidEnumArgumentException("Unexpected Dialog Result Value");
                        }
                    }

                    //Force Garbage collection because Bitmaps that are not explicitly disposed are
                    // very slow to be sweapt by the garbage collector..
                    GC.Collect();
                    return toReturn;
                }



            }
        }
    }

}

