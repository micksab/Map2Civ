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
using Map2CivilizationCtrl;

namespace Map2CivilizationView
{
    public partial class SettingsForm : Form
    {

        List<ISettingControl> _settingControlList = new List<ISettingControl>();

        const string PlotColorOcean = "PlotColorOcean";
        const string PlotColorCoast = "PlotColorCoast";
        const string PlotColorFlat = "PlotColorFlat";
        const string PlotColorHill = "PlotColorHill";
        const string PlotColorMountain = "PlotColorMountain";
        const string ReportEMailAddress = "ReportEMailAddress";
        const string PlotWidthPixelsSquarePlot = "PlotWidthPixelsSquarePlot";
        const string PlotWidthPixelsHexagonalP = "PlotWidthPixelsHexagonalP";
        const string PlotWidthPixelsRhombus = "PlotWidthPixelsRhombus";
        const string MapGridColorModel = "MapGridColorModel";
        const string ProcessedMapUnAssignedPlotGridColor = "ProcessedMapUnAssignedPlotGridColor";
        const string ProcessedMapHighlightedPlotGridColor = "ProcessedMapHighlightedPlotGridColor";
        const string ProcessedMapHighlightedPlotGridWidthPixels = "ProcessedMapHighlightedPlotGridWidthPixels";
        const string MinZoomPercent = "MinZoomPercent";
        const string MaxZoomPercent = "MaxZoomPercent";
        const string ZoomStepPercent = "ZoomStepPercent";
        const string KeyShrortcuts_SaveAs = "KeyShrortcuts_SaveAs";
        const string KeyShrortcuts_Save = "KeyShrortcuts_Save";
        const string KeyShrortcuts_NewModel = "KeyShrortcuts_NewModel";
        const string KeyShrortcuts_ExportToCivMap = "KeyShrortcuts_ExportToCivMap";
        const string KeyShrortcuts_EditRegion = "KeyShrortcuts_EditRegion";
        const string KeyShrortcuts_EditPlotData = "KeyShrortcuts_EditPlotData";
        const string KeyShrortcuts_AssignOcean = "KeyShrortcuts_AssignOcean";
        const string KeyShrortcuts_AssignMountain = "KeyShrortcuts_AssignMountain";
        const string KeyShrortcuts_AssignHill = "KeyShrortcuts_AssignHill";
        const string KeyShrortcuts_AssignFlat = "KeyShrortcuts_AssignFlat";
        const string KeyShrortcuts_AssignCoast = "KeyShrortcuts_AssignCoast";
        const string KeyShrortcuts_OpenModel = "KeyShrortcuts_OpenModel";
        const string UiCulture = "UICulture";

       
        string _ReportEMailAddress = Map2Civilization.Properties.Settings.Default.ReportEMailAddress;
        System.Globalization.CultureInfo _uICulture = Map2Civilization.Properties.Settings.Default.UICulture;

        public SettingsForm()
        {
            InitializeComponent();

            PopulateShortcutsKeysSelectors();
            PopulateNumericBoxes();
            PopulateColorSelectors();
            PopulateLanguagesCombo();
        }

         void PopulateShortcutsKeysSelectors()
        {
            

            selectorKeyShrortcuts_SaveAs.AssignKeyShortcutProperty(KeyShrortcuts_SaveAs, true);
            _settingControlList.Add(selectorKeyShrortcuts_SaveAs);
            selectorKeyShrortcuts_Save.AssignKeyShortcutProperty(KeyShrortcuts_Save, true);
            _settingControlList.Add(selectorKeyShrortcuts_Save);
            selectorKeyShrortcuts_NewModel.AssignKeyShortcutProperty(KeyShrortcuts_NewModel, true);
            _settingControlList.Add(selectorKeyShrortcuts_NewModel);
            selectorKeyShrortcuts_ExportToCivMap.AssignKeyShortcutProperty(KeyShrortcuts_ExportToCivMap, true);
            _settingControlList.Add(selectorKeyShrortcuts_ExportToCivMap);
            selectorKeyShrortcuts_EditRegion.AssignKeyShortcutProperty(KeyShrortcuts_EditRegion, true);
            _settingControlList.Add(selectorKeyShrortcuts_EditRegion);
            selectorKeyShrortcuts_EditPlotData.AssignKeyShortcutProperty(KeyShrortcuts_EditPlotData, true);
            _settingControlList.Add(selectorKeyShrortcuts_EditPlotData);
            selectorKeyShrortcuts_AssignOcean.AssignKeyShortcutProperty(KeyShrortcuts_AssignOcean, false);
            _settingControlList.Add(selectorKeyShrortcuts_AssignOcean);
            selectorKeyShrortcuts_AssignMountain.AssignKeyShortcutProperty(KeyShrortcuts_AssignMountain, false);
            _settingControlList.Add(selectorKeyShrortcuts_AssignMountain);
            selectorKeyShrortcuts_AssignHill.AssignKeyShortcutProperty(KeyShrortcuts_AssignHill, false);
            _settingControlList.Add(selectorKeyShrortcuts_AssignHill);
            selectorKeyShrortcuts_AssignFlat.AssignKeyShortcutProperty(KeyShrortcuts_AssignFlat, false);
            _settingControlList.Add(selectorKeyShrortcuts_AssignFlat);
            selectorKeyShrortcuts_AssignCoast.AssignKeyShortcutProperty(KeyShrortcuts_AssignCoast, false);
            _settingControlList.Add(selectorKeyShrortcuts_AssignCoast);
            selectorKeyShrortcuts_OpenModel.AssignKeyShortcutProperty(KeyShrortcuts_OpenModel, true);
            _settingControlList.Add(selectorKeyShrortcuts_OpenModel);
            

            foreach(ISettingControl tempControl in _settingControlList)
            {
                if(tempControl.GetType() == typeof(KeyboardShortcutSettingSelector))
                    ((KeyboardShortcutSettingSelector)tempControl).KeyboardShortcutSelectorValueChangedEventHandler += 
                        KeyboardShortcutSelectorValue_ChangedHandler;
            }



            
            RefreshAssignedKeysList();

        }

        void RefreshAssignedKeysList()
        {
            List<Keys> toTransmit = new List<Keys>();

            foreach (ISettingControl tempControl in _settingControlList)
            {
                if (tempControl.GetType() == typeof(KeyboardShortcutSettingSelector))
                    toTransmit.Add(((KeyboardShortcutSettingSelector)tempControl).CurrentlySelectedShortcut);
            }

            foreach (ISettingControl tempControl in _settingControlList)
            {
                if (tempControl.GetType() == typeof(KeyboardShortcutSettingSelector))
                    ((KeyboardShortcutSettingSelector)tempControl).SetAssignedKeysList(toTransmit);
            }

            
        }
        


         void PopulateNumericBoxes()
        {
            zoomStepNumeric.AssignNumericProperty(ZoomStepPercent);
            _settingControlList.Add(zoomStepNumeric);
            minimumZoomNumeric.AssignNumericProperty(MinZoomPercent);
            minimumZoomNumeric.Increment = zoomStepNumeric.Value;
            _settingControlList.Add(minimumZoomNumeric);
            maximumZoomNumeric.AssignNumericProperty(MaxZoomPercent);
            maximumZoomNumeric.Increment = zoomStepNumeric.Value;
            _settingControlList.Add(maximumZoomNumeric);
            
            hexPlotWidthNumeric.AssignNumericProperty(PlotWidthPixelsHexagonalP);
            _settingControlList.Add(hexPlotWidthNumeric);
            squarePlotWidthNumeric.AssignNumericProperty(PlotWidthPixelsSquarePlot);
            _settingControlList.Add(squarePlotWidthNumeric);
            rhombusPlotWidthNumeric.AssignNumericProperty(PlotWidthPixelsRhombus);
            _settingControlList.Add(rhombusPlotWidthNumeric);
            highlightedPlotGridWidthNumeric.AssignNumericProperty(ProcessedMapHighlightedPlotGridWidthPixels);
            _settingControlList.Add(highlightedPlotGridWidthNumeric);

            foreach(ISettingControl tempControl in _settingControlList)
            {
                if(tempControl.GetType() == typeof(NumericSettingSelector))
                {
                    ((NumericSettingSelector)tempControl).NumericSelectorValueChanged
                        += zoomNumerics_ValueChanged;
                }
                    

            }


           
        }


         void PopulateColorSelectors()
        {
            oceanColorSelector.AssignColorProperty(PlotColorOcean);
            _settingControlList.Add(oceanColorSelector);
            coastColorSelector.AssignColorProperty(PlotColorCoast);
            _settingControlList.Add(coastColorSelector);
            flatColorSelector.AssignColorProperty(PlotColorFlat);
            _settingControlList.Add(flatColorSelector);
            hillColorSelector.AssignColorProperty(PlotColorHill);
            _settingControlList.Add(hillColorSelector);
            mountainColorSelector.AssignColorProperty(PlotColorMountain);
            _settingControlList.Add(mountainColorSelector);
            originalMapGridColorSelector.AssignColorProperty(MapGridColorModel);
            _settingControlList.Add(originalMapGridColorSelector);
            processedMapUnassignedGridColorSelector.AssignColorProperty(ProcessedMapUnAssignedPlotGridColor);
            _settingControlList.Add(processedMapUnassignedGridColorSelector);
            highlightedGridColorSelector.AssignColorProperty(ProcessedMapHighlightedPlotGridColor);
            _settingControlList.Add(highlightedGridColorSelector);
            

            foreach(ISettingControl tempControl in _settingControlList)
            {
                if(tempControl.GetType()== typeof(ColorSettingSelector))
                    ((ColorSettingSelector)tempControl).ColorSelectorValueChanged += ColorSelectorValue_Changed;
            }
        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Console.WriteLine(System.String)")]
        void PopulateLanguagesCombo()
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


         void SettingsChanged()
        {
            applyButton.Enabled = true;
        }

         void ColorSelectorValue_Changed(object sender, UserControls.ColorSelectorValueChangedEventArgs e)
        {
            SettingsChanged();
        }

         void KeyboardShortcutSelectorValue_ChangedHandler(object sender,
            UserControls.KeyboardShortcutSelectorValueChangedEventArgs e)
        {
            SettingsChanged();
            KeyboardShortcutSettingSelector selector = (KeyboardShortcutSettingSelector)sender;


            RefreshAssignedKeysList();
        }

         void zoomNumerics_ValueChanged(object sender, EventArgs e)
        {
            SettingsChanged();
            NumericSettingSelector selector = (NumericSettingSelector)sender;

            if(sender == maximumZoomNumeric || sender == minimumZoomNumeric)
            {
                if (maximumZoomNumeric.Value <= minimumZoomNumeric.Value)
                {
                    CultureAwareMessageBox.Show(Resources.Str_SettingsForm_MinimumZoomErrorText,
                    Resources.Str_SettingsForm_MinimumZoomErrorCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                    if (sender == maximumZoomNumeric)
                    {
                        maximumZoomNumeric.Value = maximumZoomNumeric.Value + zoomStepNumeric.Value;
                    }
                    else
                    {
                        minimumZoomNumeric.Value = minimumZoomNumeric.Value - zoomStepNumeric.Value;
                    }
                }
            }


            if(sender == zoomStepNumeric)
            {
                decimal stepValue = zoomStepNumeric.Value;
                minimumZoomNumeric.Increment = stepValue;
                maximumZoomNumeric.Increment = stepValue;
            }
        }

        


         void zoomNumerics_Validating(object sender, CancelEventArgs e)
        {
            if (minimumZoomNumeric.Value+zoomStepNumeric.Value >= maximumZoomNumeric.Value)
            {
                e.Cancel = true;
                CultureAwareMessageBox.Show(Resources.Str_SettingsForm_MinimumZoomErrorText, 
                    Resources.Str_SettingsForm_MinimumZoomErrorCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

         void plotWidthNumerics_Validating(object sender, CancelEventArgs e)
        {
            if(((NumericUpDown)sender).Value % 2 == 0)
            {
                e.Cancel = true;
                CultureAwareMessageBox.Show(Resources.Str_SettingsForm_PlotWidthErrorText,
                    Resources.Str_SettingsForm_PlotWidthErrorCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }


         void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

         void uiLanguageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _uICulture = (System.Globalization.CultureInfo)uiLanguageComboBox.SelectedItem;
            SettingsChanged();
        }

         void revertButton_Click(object sender, EventArgs e)
        {
            Settings.Default.Reset();
            Settings.Default.Save();
            RestartApp();
        }

         void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            string keyShortcutTypeString = typeof(KeyboardShortcutSettingSelector).ToString().ToUpper();
            string colorSelectorTypeString = typeof(ColorSettingSelector).ToString().ToUpper();
            string numericSelectorTypeString = typeof(NumericSettingSelector).ToString().ToUpper();

            foreach (ISettingControl tempControl in _settingControlList)
            {

                string controlTypeString = tempControl.GetType().ToString().ToUpper();

                if (controlTypeString.Equals(keyShortcutTypeString))
                {
                    ((KeyboardShortcutSettingSelector)tempControl).KeyboardShortcutSelectorValueChangedEventHandler -=
                            KeyboardShortcutSelectorValue_ChangedHandler;
                }
                else if(controlTypeString.Equals(colorSelectorTypeString))
                {
                    ((ColorSettingSelector)tempControl).ColorSelectorValueChanged -=
                                ColorSelectorValue_Changed;
                }
                else if (controlTypeString.Equals(numericSelectorTypeString))
                {
                    ((NumericSettingSelector)tempControl).NumericSelectorValueChanged -=
                        zoomNumerics_ValueChanged;
                }

                
            }
            

            this.uiLanguageComboBox.SelectedIndexChanged -=uiLanguageComboBox_SelectedIndexChanged;

        }

         void applyButton_Click(object sender, EventArgs e)
        {
            
            Map2Civilization.Properties.Settings.Default.ReportEMailAddress = _ReportEMailAddress;
            Map2Civilization.Properties.Settings.Default.UICulture= _uICulture;


            foreach(ISettingControl tempControl in _settingControlList)
            {
                tempControl.SavePropertySetting();
            }

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
