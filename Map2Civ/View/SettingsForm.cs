using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Windows.Forms;
using Map2Civilization.Properties;
using Map2CivilizationView.UserControls;

namespace Map2CivilizationView
{
    public partial class SettingsForm : Form
    {
        Color _plotCororOcean = Map2Civilization.Properties.Settings.Default.PlotColorOcean;
        Color _plotCororCoast = Map2Civilization.Properties.Settings.Default.PlotColorCoast;
        Color _plotCororFlat = Map2Civilization.Properties.Settings.Default.PlotColorFlat;
        Color _plotCororHill = Map2Civilization.Properties.Settings.Default.PlotColorHill;
        Color _plotCororMountain = Map2Civilization.Properties.Settings.Default.PlotColorMountain;
        String _ReportEMailAddress = Map2Civilization.Properties.Settings.Default.ReportEMailAddress;
        int _plotWidthPixelsSquarePlot = Map2Civilization.Properties.Settings.Default.PlotWidthPixelsSquarePlot;
        int _plotWidthPixelsHexagonalP = Map2Civilization.Properties.Settings.Default.PlotWidthPixelsHexagonalP;
        int _plotWidthPixelsRhombus = Map2Civilization.Properties.Settings.Default.PlotWidthPixelsRhombus;
        Color _mapGridColorModel = Map2Civilization.Properties.Settings.Default.MapGridColorModel;
        Color _processedMapUnAssignedPlotColor = Map2Civilization.Properties.Settings.Default.ProcessedMapUnAssignedPlotGridColor;
        Color _processedMapHighlightedPlotGridColor = Map2Civilization.Properties.Settings.Default.ProcessedMapHighlightedPlotGridColor;
        int _processedMapHighlightedPlotGridWidthPixels = Map2Civilization.Properties.Settings.Default.ProcessedMapHighlightedPlotGridWidthPixels;
        float _minZoomPercent = Map2Civilization.Properties.Settings.Default.MinZoomPercent;
        float _maxZoomPercent = Map2Civilization.Properties.Settings.Default.MaxZoomPercent; 
        float _zoomStepPercent = Map2Civilization.Properties.Settings.Default.ZoomStepPercent;
        Keys _keyShrortcuts_SaveAs = Map2Civilization.Properties.Settings.Default.KeyShrortcuts_SaveAs;
        Keys _keyShrortcuts_Save = Map2Civilization.Properties.Settings.Default.KeyShrortcuts_Save;
        Keys _keyShrortcuts_NewModel = Map2Civilization.Properties.Settings.Default.KeyShrortcuts_NewModel;
        Keys _keyShrortcuts_ExportToCivMap = Map2Civilization.Properties.Settings.Default.KeyShrortcuts_ExportToCivMap;
        Keys _keyShrortcuts_EditRegion = Map2Civilization.Properties.Settings.Default.KeyShrortcuts_EditRegion;
        Keys _keyShrortcuts_EditPlotData = Map2Civilization.Properties.Settings.Default.KeyShrortcuts_EditPlotData;
        Keys _keyShrortcuts_AssignOcean = Map2Civilization.Properties.Settings.Default.KeyShrortcuts_AssignOcean;
        Keys _keyShrortcuts_AssignMountain = Map2Civilization.Properties.Settings.Default.KeyShrortcuts_AssignMountain;
        Keys _keyShrortcuts_AssignHill = Map2Civilization.Properties.Settings.Default.KeyShrortcuts_AssignHill;
        Keys _keyShrortcuts_AssignFlat = Map2Civilization.Properties.Settings.Default.KeyShrortcuts_AssignFlat;
        Keys _keyShrortcuts_AssignCoast = Map2Civilization.Properties.Settings.Default.KeyShrortcuts_AssignCoast;
        Keys _keyShrortcuts_OpenModel = Map2Civilization.Properties.Settings.Default.KeyShrortcuts_OpenModel;
        System.Globalization.CultureInfo _uICulture = Map2Civilization.Properties.Settings.Default.UICulture;

        public SettingsForm()
        {
            InitializeComponent();

            PopulateShortcutsKeysSelectors();
            PopulateNumericBoxes();
            PopulateColorSelectors();
            PopulateLanguagesCombo();
        }

        private void PopulateShortcutsKeysSelectors()
        {
            

            selectorKeyShrortcuts_SaveAs.CurrentlySelectedShortcut = _keyShrortcuts_SaveAs;
            selectorKeyShrortcuts_SaveAs.RequiresKeyModifier = true;
            selectorKeyShrortcuts_Save.CurrentlySelectedShortcut = _keyShrortcuts_Save;
            selectorKeyShrortcuts_Save.RequiresKeyModifier = true;
            selectorKeyShrortcuts_NewModel.CurrentlySelectedShortcut = _keyShrortcuts_NewModel;
            selectorKeyShrortcuts_NewModel.RequiresKeyModifier = true;
            selectorKeyShrortcuts_ExportToCivMap.CurrentlySelectedShortcut = _keyShrortcuts_ExportToCivMap;
            selectorKeyShrortcuts_ExportToCivMap.RequiresKeyModifier = true;
            selectorKeyShrortcuts_EditRegion.CurrentlySelectedShortcut = _keyShrortcuts_EditRegion;
            selectorKeyShrortcuts_EditRegion.RequiresKeyModifier = true;
            selectorKeyShrortcuts_EditPlotData.CurrentlySelectedShortcut = _keyShrortcuts_EditPlotData;
            selectorKeyShrortcuts_EditPlotData.RequiresKeyModifier = true;
            selectorKeyShrortcuts_AssignOcean.CurrentlySelectedShortcut = _keyShrortcuts_AssignOcean;
            selectorKeyShrortcuts_AssignMountain.CurrentlySelectedShortcut = _keyShrortcuts_AssignMountain;
            selectorKeyShrortcuts_AssignHill.CurrentlySelectedShortcut = _keyShrortcuts_AssignHill;
            selectorKeyShrortcuts_AssignFlat.CurrentlySelectedShortcut = _keyShrortcuts_AssignFlat;
            selectorKeyShrortcuts_AssignCoast.CurrentlySelectedShortcut = _keyShrortcuts_AssignCoast;
            selectorKeyShrortcuts_OpenModel.CurrentlySelectedShortcut = _keyShrortcuts_OpenModel;
            selectorKeyShrortcuts_OpenModel.RequiresKeyModifier = true;


            selectorKeyShrortcuts_SaveAs.KeyboardShortcutSelectorValueChangedEventHandler +=
                KeyboardShortcutSelectorValue_ChangedHandler;
            selectorKeyShrortcuts_Save.KeyboardShortcutSelectorValueChangedEventHandler +=
                KeyboardShortcutSelectorValue_ChangedHandler;
            selectorKeyShrortcuts_NewModel.KeyboardShortcutSelectorValueChangedEventHandler +=
                KeyboardShortcutSelectorValue_ChangedHandler;
            selectorKeyShrortcuts_ExportToCivMap.KeyboardShortcutSelectorValueChangedEventHandler +=
                KeyboardShortcutSelectorValue_ChangedHandler;
            selectorKeyShrortcuts_EditRegion.KeyboardShortcutSelectorValueChangedEventHandler +=
                KeyboardShortcutSelectorValue_ChangedHandler;
            selectorKeyShrortcuts_EditPlotData.KeyboardShortcutSelectorValueChangedEventHandler +=
                KeyboardShortcutSelectorValue_ChangedHandler;
            selectorKeyShrortcuts_AssignOcean.KeyboardShortcutSelectorValueChangedEventHandler +=
                KeyboardShortcutSelectorValue_ChangedHandler;
            selectorKeyShrortcuts_AssignMountain.KeyboardShortcutSelectorValueChangedEventHandler +=
                KeyboardShortcutSelectorValue_ChangedHandler;
            selectorKeyShrortcuts_AssignHill.KeyboardShortcutSelectorValueChangedEventHandler +=
                KeyboardShortcutSelectorValue_ChangedHandler;
            selectorKeyShrortcuts_AssignFlat.KeyboardShortcutSelectorValueChangedEventHandler +=
                KeyboardShortcutSelectorValue_ChangedHandler;
            selectorKeyShrortcuts_AssignCoast.KeyboardShortcutSelectorValueChangedEventHandler +=
                KeyboardShortcutSelectorValue_ChangedHandler;
            selectorKeyShrortcuts_OpenModel.KeyboardShortcutSelectorValueChangedEventHandler +=
                KeyboardShortcutSelectorValue_ChangedHandler;

            RefreshAssignedKeysList();

        }

        void RefreshAssignedKeysList()
        {
            Dictionary<KeyboardShortcutSelector, Keys> keysList = RefreshAssignedKeysList(this);

            List<Keys> toTransmit = keysList.Values.ToList<Keys>();

            foreach (KeyValuePair<KeyboardShortcutSelector, Keys> temp in keysList)
            {
                temp.Key.AssignedKeysList.AddRange(toTransmit);
            }
        }

        Dictionary<KeyboardShortcutSelector, Keys> RefreshAssignedKeysList(Control control)
        {
            Dictionary<KeyboardShortcutSelector, Keys> keysList = new Dictionary<KeyboardShortcutSelector, Keys>();
           

            foreach(Control tempControl in control.Controls)
            {
                Dictionary<KeyboardShortcutSelector, Keys> innerList = RefreshAssignedKeysList(tempControl);
                foreach(KeyValuePair<KeyboardShortcutSelector, Keys> tempPair in innerList)
                {
                    keysList.Add(tempPair.Key, tempPair.Value);
                }
            }
            
            foreach (Control tempControl in control.Controls)
            {
                if (tempControl.GetType() == typeof(KeyboardShortcutSelector))
                {
                    KeyboardShortcutSelector selectorControl = (KeyboardShortcutSelector)tempControl;
                    keysList.Add(selectorControl, selectorControl.CurrentlySelectedShortcut);
                }
            }

            return keysList;
            
        }


        private void PopulateNumericBoxes()
        {
            minimumZoomNumeric.Value = (decimal)_minZoomPercent;
            maximumZoomNumeric.Value = (decimal)_maxZoomPercent;
            zoomStepNumeric.Value = (decimal)_zoomStepPercent;
            hexPlotWidthNumeric.Value = _plotWidthPixelsHexagonalP;
            squarePlotWidthNumeric.Value = _plotWidthPixelsSquarePlot;
            rhombusPlotWidthNumeric.Value = _plotWidthPixelsRhombus;
            highlightedPlotGridWidthNumeric.Value = _processedMapHighlightedPlotGridWidthPixels;


            highlightedPlotGridWidthNumeric.ValueChanged += zoomNumerics_ValueChanged;
            rhombusPlotWidthNumeric.ValueChanged += zoomNumerics_ValueChanged;
            squarePlotWidthNumeric.ValueChanged += zoomNumerics_ValueChanged;
            hexPlotWidthNumeric.ValueChanged += zoomNumerics_ValueChanged;
            zoomStepNumeric.ValueChanged += zoomNumerics_ValueChanged;
            maximumZoomNumeric.ValueChanged += zoomNumerics_ValueChanged;
            minimumZoomNumeric.ValueChanged += zoomNumerics_ValueChanged;
        }


        private void PopulateColorSelectors()
        {
            oceanColorSelector.Color = _plotCororOcean;
            coastColorSelector.Color = _plotCororCoast;
            flatColorSelector.Color = _plotCororFlat;
            hillColorSelector.Color = _plotCororHill;
            mountainColorSelector.Color = _plotCororMountain;
            originalMapGridColorSelector.Color = _mapGridColorModel;
            processedMapUnassignedGridColorSelector.Color = _processedMapUnAssignedPlotColor;
            highlightedGridColorSelector.Color = _processedMapHighlightedPlotGridColor;


            oceanColorSelector.ColorSelectorValueChanged += ColorSelectorValue_Changed;
            coastColorSelector.ColorSelectorValueChanged += ColorSelectorValue_Changed;
            flatColorSelector.ColorSelectorValueChanged += ColorSelectorValue_Changed;
            hillColorSelector.ColorSelectorValueChanged += ColorSelectorValue_Changed;
            mountainColorSelector.ColorSelectorValueChanged += ColorSelectorValue_Changed;
            originalMapGridColorSelector.ColorSelectorValueChanged += ColorSelectorValue_Changed;
            processedMapUnassignedGridColorSelector.ColorSelectorValueChanged += ColorSelectorValue_Changed;
            highlightedGridColorSelector.ColorSelectorValueChanged += ColorSelectorValue_Changed;
        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Console.WriteLine(System.String)")]
        private void PopulateLanguagesCombo()
        {
            ResourceManager rm = new ResourceManager(typeof(Map2Civilization.Properties.Resources));

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach (CultureInfo culture in cultures)
            {
                try
                {
                    ResourceSet rs = rm.GetResourceSet(culture, true, false);
                    if (rs != null)
                    {
                        if(culture != CultureInfo.InvariantCulture)
                        {
                            uiLanguageComboBox.Items.Add(culture);
                            uiLanguageComboBox.DisplayMember = "NativeName";
                        }
                       
                    }
                }
                catch (CultureNotFoundException exc)
                {
                    Console.WriteLine(culture + " is not available on the machine or is an invalid culture identifier: "+ exc.Message);
                }
            }

            if(CultureInfo.CurrentCulture == CultureInfo.InvariantCulture)
            {
                uiLanguageComboBox.SelectedItem = CultureInfo.GetCultureInfo("en-US");
            }
            else
            {
                uiLanguageComboBox.SelectedItem = CultureInfo.CurrentCulture;
            }

            this.uiLanguageComboBox.SelectedIndexChanged += uiLanguageComboBox_SelectedIndexChanged;
            rm.ReleaseAllResources();

        }


        private void SettingsChanged()
        {
            applyButton.Enabled = true;
        }

        private void ColorSelectorValue_Changed(object sender, UserControls.ColorSelectorValueChangedEventArgs e)
        {
            SettingsChanged();
            ColorSelector selector = (ColorSelector)sender;

            if (selector == oceanColorSelector)
                _plotCororOcean = e.SelectedColor;
            else if (selector == coastColorSelector)
                _plotCororCoast = e.SelectedColor;
            else if (selector == flatColorSelector)
                _plotCororFlat = e.SelectedColor;
            else if (selector == hillColorSelector)
                _plotCororHill = e.SelectedColor;
            else if (selector == mountainColorSelector)
                _plotCororMountain = e.SelectedColor;
            else if (selector == originalMapGridColorSelector)
                _mapGridColorModel = e.SelectedColor;
            else if (selector == processedMapUnassignedGridColorSelector)
                _processedMapUnAssignedPlotColor = e.SelectedColor;
            else if (selector == highlightedGridColorSelector)
                _processedMapHighlightedPlotGridColor = e.SelectedColor;
        }

        private void KeyboardShortcutSelectorValue_ChangedHandler(object sender,
            UserControls.KeyboardShortcutSelectorValueChangedEventArgs e)
        {
            SettingsChanged();
            KeyboardShortcutSelector selector = (KeyboardShortcutSelector)sender;

            if (selector == selectorKeyShrortcuts_SaveAs)
                _keyShrortcuts_SaveAs = e.Shortcut;
            else if (selector == selectorKeyShrortcuts_Save)
                _keyShrortcuts_Save = e.Shortcut;
            else if (selector == selectorKeyShrortcuts_NewModel)
                _keyShrortcuts_NewModel = e.Shortcut;
            else if (selector == selectorKeyShrortcuts_ExportToCivMap)
                _keyShrortcuts_ExportToCivMap = e.Shortcut;
            else if (selector == selectorKeyShrortcuts_EditRegion)
                _keyShrortcuts_EditRegion = e.Shortcut;
            else if (selector == selectorKeyShrortcuts_EditPlotData)
                _keyShrortcuts_EditPlotData = e.Shortcut;
            else if (selector == selectorKeyShrortcuts_AssignOcean)
                _keyShrortcuts_AssignOcean = e.Shortcut;
            else if (selector == selectorKeyShrortcuts_AssignCoast)
                _keyShrortcuts_AssignCoast = e.Shortcut;
            else if (selector == selectorKeyShrortcuts_AssignFlat)
                _keyShrortcuts_AssignFlat = e.Shortcut;
            else if (selector == selectorKeyShrortcuts_AssignHill)
                _keyShrortcuts_AssignHill = e.Shortcut;
            else if (selector == selectorKeyShrortcuts_AssignMountain)
                _keyShrortcuts_AssignMountain = e.Shortcut;
            else if (selector == selectorKeyShrortcuts_OpenModel)
                _keyShrortcuts_OpenModel = e.Shortcut;

            RefreshAssignedKeysList();
        }

        private void zoomNumerics_ValueChanged(object sender, EventArgs e)
        {
            SettingsChanged();
            NumericUpDown selector = (NumericUpDown)sender;

            if (selector == minimumZoomNumeric)
                _minZoomPercent = (float)selector.Value;
            else if (selector == maximumZoomNumeric)
                _maxZoomPercent = (float)selector.Value;
            else if (selector == zoomStepNumeric)
                _zoomStepPercent = (float)selector.Value;
            else if (selector == hexPlotWidthNumeric)
                _plotWidthPixelsHexagonalP = (int)selector.Value;
            else if (selector == squarePlotWidthNumeric)
                _plotWidthPixelsSquarePlot = (int)selector.Value;
            else if (selector == rhombusPlotWidthNumeric)
                _plotWidthPixelsRhombus = (int)selector.Value;
            else if (selector == highlightedPlotGridWidthNumeric)
                _processedMapHighlightedPlotGridWidthPixels = (int)selector.Value;
        }

        


        private void zoomNumerics_Validating(object sender, CancelEventArgs e)
        {
            if (minimumZoomNumeric.Value >= maximumZoomNumeric.Value)
            {
                e.Cancel = true;
                CultureAwareMessageBox.Show(Resources.Str_SettingsForm_MinimumZoomErrorText, 
                    Resources.Str_SettingsForm_MinimumZoomErrorCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void plotWidthNumerics_Validating(object sender, CancelEventArgs e)
        {
            if(((NumericUpDown)sender).Value % 2 == 0)
            {
                e.Cancel = true;
                CultureAwareMessageBox.Show(Resources.Str_SettingsForm_PlotWidthErrorText,
                    Resources.Str_SettingsForm_PlotWidthErrorCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }


        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void uiLanguageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _uICulture = (System.Globalization.CultureInfo)uiLanguageComboBox.SelectedItem;
            SettingsChanged();
        }

        private void revertButton_Click(object sender, EventArgs e)
        {
            Settings.Default.Reset();
            Settings.Default.Save();
            RestartApp();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            selectorKeyShrortcuts_SaveAs.KeyboardShortcutSelectorValueChangedEventHandler -=
                KeyboardShortcutSelectorValue_ChangedHandler;
            selectorKeyShrortcuts_Save.KeyboardShortcutSelectorValueChangedEventHandler -=
                KeyboardShortcutSelectorValue_ChangedHandler;
            selectorKeyShrortcuts_NewModel.KeyboardShortcutSelectorValueChangedEventHandler -=
                KeyboardShortcutSelectorValue_ChangedHandler;
            selectorKeyShrortcuts_ExportToCivMap.KeyboardShortcutSelectorValueChangedEventHandler -=
                KeyboardShortcutSelectorValue_ChangedHandler;
            selectorKeyShrortcuts_EditRegion.KeyboardShortcutSelectorValueChangedEventHandler -=
                KeyboardShortcutSelectorValue_ChangedHandler;
            selectorKeyShrortcuts_EditPlotData.KeyboardShortcutSelectorValueChangedEventHandler -=
                KeyboardShortcutSelectorValue_ChangedHandler;
            selectorKeyShrortcuts_AssignOcean.KeyboardShortcutSelectorValueChangedEventHandler -=
                KeyboardShortcutSelectorValue_ChangedHandler;
            selectorKeyShrortcuts_AssignMountain.KeyboardShortcutSelectorValueChangedEventHandler -=
                KeyboardShortcutSelectorValue_ChangedHandler;
            selectorKeyShrortcuts_AssignHill.KeyboardShortcutSelectorValueChangedEventHandler -=
                KeyboardShortcutSelectorValue_ChangedHandler;
            selectorKeyShrortcuts_AssignFlat.KeyboardShortcutSelectorValueChangedEventHandler -=
                KeyboardShortcutSelectorValue_ChangedHandler;
            selectorKeyShrortcuts_AssignCoast.KeyboardShortcutSelectorValueChangedEventHandler -=
                KeyboardShortcutSelectorValue_ChangedHandler;
            selectorKeyShrortcuts_OpenModel.KeyboardShortcutSelectorValueChangedEventHandler -=
                KeyboardShortcutSelectorValue_ChangedHandler;

            oceanColorSelector.ColorSelectorValueChanged -= ColorSelectorValue_Changed;
            coastColorSelector.ColorSelectorValueChanged -= ColorSelectorValue_Changed;
            flatColorSelector.ColorSelectorValueChanged -= ColorSelectorValue_Changed;
            hillColorSelector.ColorSelectorValueChanged -= ColorSelectorValue_Changed;
            mountainColorSelector.ColorSelectorValueChanged -= ColorSelectorValue_Changed;
            originalMapGridColorSelector.ColorSelectorValueChanged -= ColorSelectorValue_Changed;
            processedMapUnassignedGridColorSelector.ColorSelectorValueChanged -= ColorSelectorValue_Changed;
            highlightedGridColorSelector.ColorSelectorValueChanged -= ColorSelectorValue_Changed;

            oceanColorSelector.ColorSelectorValueChanged -= ColorSelectorValue_Changed;
            coastColorSelector.ColorSelectorValueChanged -= ColorSelectorValue_Changed;
            flatColorSelector.ColorSelectorValueChanged -= ColorSelectorValue_Changed;
            hillColorSelector.ColorSelectorValueChanged -= ColorSelectorValue_Changed;
            mountainColorSelector.ColorSelectorValueChanged -= ColorSelectorValue_Changed;
            originalMapGridColorSelector.ColorSelectorValueChanged -= ColorSelectorValue_Changed;
            processedMapUnassignedGridColorSelector.ColorSelectorValueChanged -= ColorSelectorValue_Changed;
            highlightedGridColorSelector.ColorSelectorValueChanged -= ColorSelectorValue_Changed;

            this.uiLanguageComboBox.SelectedIndexChanged -=uiLanguageComboBox_SelectedIndexChanged;

        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            Map2Civilization.Properties.Settings.Default.PlotColorOcean = _plotCororOcean;
            Map2Civilization.Properties.Settings.Default.PlotColorCoast  = _plotCororCoast;
            Map2Civilization.Properties.Settings.Default.PlotColorFlat = _plotCororFlat;
            Map2Civilization.Properties.Settings.Default.PlotColorHill=_plotCororHill;
            Map2Civilization.Properties.Settings.Default.PlotColorMountain = _plotCororMountain;
            Map2Civilization.Properties.Settings.Default.ReportEMailAddress = _ReportEMailAddress;
            Map2Civilization.Properties.Settings.Default.PlotWidthPixelsSquarePlot = _plotWidthPixelsSquarePlot;
            Map2Civilization.Properties.Settings.Default.PlotWidthPixelsHexagonalP = _plotWidthPixelsHexagonalP;
            Map2Civilization.Properties.Settings.Default.PlotWidthPixelsRhombus = _plotWidthPixelsRhombus;
            Map2Civilization.Properties.Settings.Default.MapGridColorModel = _mapGridColorModel;
            Map2Civilization.Properties.Settings.Default.ProcessedMapUnAssignedPlotGridColor = _processedMapUnAssignedPlotColor;
            Map2Civilization.Properties.Settings.Default.ProcessedMapHighlightedPlotGridColor = _processedMapHighlightedPlotGridColor;
            Map2Civilization.Properties.Settings.Default.ProcessedMapHighlightedPlotGridWidthPixels = _processedMapHighlightedPlotGridWidthPixels;
            Map2Civilization.Properties.Settings.Default.MinZoomPercent = _minZoomPercent;
            Map2Civilization.Properties.Settings.Default.MaxZoomPercent= _maxZoomPercent;
            Map2Civilization.Properties.Settings.Default.ZoomStepPercent = _zoomStepPercent;
            Map2Civilization.Properties.Settings.Default.KeyShrortcuts_SaveAs= _keyShrortcuts_SaveAs;
            Map2Civilization.Properties.Settings.Default.KeyShrortcuts_Save= _keyShrortcuts_Save;
            Map2Civilization.Properties.Settings.Default.KeyShrortcuts_NewModel= _keyShrortcuts_NewModel;
            Map2Civilization.Properties.Settings.Default.KeyShrortcuts_ExportToCivMap= _keyShrortcuts_ExportToCivMap;
            Map2Civilization.Properties.Settings.Default.KeyShrortcuts_EditRegion= _keyShrortcuts_EditRegion;
            Map2Civilization.Properties.Settings.Default.KeyShrortcuts_EditPlotData= _keyShrortcuts_EditPlotData;
            Map2Civilization.Properties.Settings.Default.KeyShrortcuts_AssignOcean= _keyShrortcuts_AssignOcean;
            Map2Civilization.Properties.Settings.Default.KeyShrortcuts_AssignMountain= _keyShrortcuts_AssignMountain;
            Map2Civilization.Properties.Settings.Default.KeyShrortcuts_AssignHill= _keyShrortcuts_AssignHill;
            Map2Civilization.Properties.Settings.Default.KeyShrortcuts_AssignFlat= _keyShrortcuts_AssignFlat;
            Map2Civilization.Properties.Settings.Default.KeyShrortcuts_AssignCoast= _keyShrortcuts_AssignCoast;
            Map2Civilization.Properties.Settings.Default.KeyShrortcuts_OpenModel = _keyShrortcuts_OpenModel;
            Map2Civilization.Properties.Settings.Default.UICulture= _uICulture;


            Map2Civilization.Properties.Settings.Default.Save();

            RestartApp();

        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        void RestartApp()
        {
            CultureAwareMessageBox.Show(Resources.Str_SettingsForm_RestartText,
                Resources.Str_SettingsForm_RestartCaption,
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            Application.Restart();
        }
    }
}
