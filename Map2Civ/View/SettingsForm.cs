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
using Map2CivilizationView.UserControls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;

namespace Map2CivilizationView
{
    public partial class SettingsForm : Form
    {
        private List<ISettingControl> _settingControlList = new List<ISettingControl>();

        private const string PlotColorOcean = "PlotColorOcean";
        private const string PlotColorCoast = "PlotColorCoast";
        private const string PlotColorFlat = "PlotColorFlat";
        private const string PlotColorHill = "PlotColorHill";
        private const string PlotColorMountain = "PlotColorMountain";
        private const string ReportEMailAddress = "ReportEMailAddress";
        private const string PlotWidthPixelsSquarePlot = "PlotWidthPixelsSquarePlot";
        private const string PlotWidthPixelsHexagonalP = "PlotWidthPixelsHexagonalP";
        private const string PlotWidthPixelsRhombus = "PlotWidthPixelsRhombus";
        private const string MapGridColorModel = "MapGridColorModel";
        private const string ProcessedMapUnAssignedPlotGridColor = "ProcessedMapUnAssignedPlotGridColor";
        private const string ProcessedMapHighlightedPlotGridColor = "ProcessedMapHighlightedPlotGridColor";
        private const string ProcessedMapHighlightedPlotGridWidthPixels = "ProcessedMapHighlightedPlotGridWidthPixels";
        private const string MinZoomPercent = "MinZoomPercent";
        private const string MaxZoomPercent = "MaxZoomPercent";
        private const string ZoomStepPercent = "ZoomStepPercent";
        private const string KeyShrortcuts_SaveAs = "KeyShrortcuts_SaveAs";
        private const string KeyShrortcuts_Save = "KeyShrortcuts_Save";
        private const string KeyShrortcuts_NewModel = "KeyShrortcuts_NewModel";
        private const string KeyShrortcuts_ExportToCivMap = "KeyShrortcuts_ExportToCivMap";
        private const string KeyShrortcuts_EditRegion = "KeyShrortcuts_EditRegion";
        private const string KeyShrortcuts_EditPlotData = "KeyShrortcuts_EditPlotData";
        private const string KeyShrortcuts_AssignOcean = "KeyShrortcuts_AssignOcean";
        private const string KeyShrortcuts_AssignMountain = "KeyShrortcuts_AssignMountain";
        private const string KeyShrortcuts_AssignHill = "KeyShrortcuts_AssignHill";
        private const string KeyShrortcuts_AssignFlat = "KeyShrortcuts_AssignFlat";
        private const string KeyShrortcuts_AssignCoast = "KeyShrortcuts_AssignCoast";
        private const string KeyShrortcuts_OpenModel = "KeyShrortcuts_OpenModel";
        private const string KeyShortcuts_RepealAssignment = "KeyShrortcuts_RepealAssignment";
        private const string UiCulture = "UICulture";

        private string _ReportEMailAddress = Map2Civilization.Properties.Settings.Default.ReportEMailAddress;
        private System.Globalization.CultureInfo _uICulture = Map2Civilization.Properties.Settings.Default.UICulture;

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
            selectorKeyShrortcuts_RepealAssignment.AssignKeyShortcutProperty(KeyShortcuts_RepealAssignment, false);
            _settingControlList.Add(selectorKeyShrortcuts_RepealAssignment);
            selectorKeyShrortcuts_AssignCoast.AssignKeyShortcutProperty(KeyShrortcuts_AssignCoast, false);
            _settingControlList.Add(selectorKeyShrortcuts_AssignCoast);
            selectorKeyShrortcuts_OpenModel.AssignKeyShortcutProperty(KeyShrortcuts_OpenModel, true);
            _settingControlList.Add(selectorKeyShrortcuts_OpenModel);

            foreach (ISettingControl tempControl in _settingControlList)
            {
                if (tempControl.GetType() == typeof(KeyboardShortcutSettingSelector))
                    ((KeyboardShortcutSettingSelector)tempControl).KeyboardShortcutSelectorValueChangedEventHandler +=
                        KeyboardShortcutSelectorValue_ChangedHandler;
            }

            RefreshAssignedKeysList();
        }

        private void RefreshAssignedKeysList()
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

        private void PopulateNumericBoxes()
        {
            zoomStepNumeric.AssignNumericProperty(ZoomStepPercent);
            _settingControlList.Add(zoomStepNumeric);
            minimumZoomNumeric.AssignNumericProperty(MinZoomPercent);
            _settingControlList.Add(minimumZoomNumeric);
            maximumZoomNumeric.AssignNumericProperty(MaxZoomPercent);
            _settingControlList.Add(maximumZoomNumeric);

            hexPlotWidthNumeric.AssignNumericProperty(PlotWidthPixelsHexagonalP);
            _settingControlList.Add(hexPlotWidthNumeric);
            squarePlotWidthNumeric.AssignNumericProperty(PlotWidthPixelsSquarePlot);
            _settingControlList.Add(squarePlotWidthNumeric);
            rhombusPlotWidthNumeric.AssignNumericProperty(PlotWidthPixelsRhombus);
            _settingControlList.Add(rhombusPlotWidthNumeric);
            highlightedPlotGridWidthNumeric.AssignNumericProperty(ProcessedMapHighlightedPlotGridWidthPixels);
            _settingControlList.Add(highlightedPlotGridWidthNumeric);

            foreach (ISettingControl tempControl in _settingControlList)
            {
                if (tempControl.GetType() == typeof(NumericSettingSelector))
                {
                    ((NumericSettingSelector)tempControl).NumericSelectorValueChanged
                        += zoomNumerics_ValueChanged;
                }
            }
        }

        private void PopulateColorSelectors()
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

            foreach (ISettingControl tempControl in _settingControlList)
            {
                if (tempControl.GetType() == typeof(ColorSettingSelector))
                    ((ColorSettingSelector)tempControl).ColorSelectorValueChanged += ColorSelectorValue_Changed;
            }
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
                        if (culture != CultureInfo.InvariantCulture)
                        {
                            uiLanguageComboBox.Items.Add(culture);
                            uiLanguageComboBox.DisplayMember = "NativeName";
                        }
                    }
                }
                catch (CultureNotFoundException exc)
                {
                    Console.WriteLine(culture + " is not available on the machine or is an invalid culture identifier: " + exc.Message);
                }
            }

            if (CultureInfo.CurrentCulture == CultureInfo.InvariantCulture)
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
        }

        private void KeyboardShortcutSelectorValue_ChangedHandler(object sender,
           UserControls.KeyboardShortcutSelectorValueChangedEventArgs e)
        {
            SettingsChanged();
            RefreshAssignedKeysList();
        }

        private void zoomNumerics_ValueChanged(object sender, EventArgs e)
        {
            SettingsChanged();
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
            Type keyShortcutType = typeof(KeyboardShortcutSettingSelector);
            Type colorSelectorType = typeof(ColorSettingSelector);
            Type numericSelectorType = typeof(NumericSettingSelector);

            foreach (ISettingControl tempControl in _settingControlList)
            {
                Type controlType = tempControl.GetType();

                if (controlType.Equals(keyShortcutType))
                {
                    ((KeyboardShortcutSettingSelector)tempControl).KeyboardShortcutSelectorValueChangedEventHandler -=
                            KeyboardShortcutSelectorValue_ChangedHandler;
                }
                else if (controlType.Equals(colorSelectorType))
                {
                    ((ColorSettingSelector)tempControl).ColorSelectorValueChanged -=
                                ColorSelectorValue_Changed;
                }
                else if (controlType.Equals(numericSelectorType))
                {
                    ((NumericSettingSelector)tempControl).NumericSelectorValueChanged -=
                        zoomNumerics_ValueChanged;
                }
            }

            this.uiLanguageComboBox.SelectedIndexChanged -= uiLanguageComboBox_SelectedIndexChanged;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            Settings.Default.ReportEMailAddress = _ReportEMailAddress;
            Settings.Default.UICulture = _uICulture;

            foreach (ISettingControl tempControl in _settingControlList)
            {
                tempControl.SavePropertySetting();
            }

            Settings.Default.Save();

            RestartApp();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        private void RestartApp()
        {
            CultureAwareMessageBox.Show(Resources.Str_SettingsForm_RestartText,
                Resources.Str_SettingsForm_RestartCaption,
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            Application.Restart();
        }
    }
}