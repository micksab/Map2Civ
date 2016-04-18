using System.Collections.Generic;

namespace Map2CivilizationView
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
         System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
         void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.buttonsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.generalTabPage = new System.Windows.Forms.TabPage();
            this.generalTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.uiCultureLabel = new System.Windows.Forms.Label();
            this.uiLanguageComboBox = new System.Windows.Forms.ComboBox();
            this.revertButton = new System.Windows.Forms.Button();
            this.keyboardShortcutsTabPage = new System.Windows.Forms.TabPage();
            this.keyboardShortcutsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelKeyShrortcuts_RepealAssignment = new System.Windows.Forms.Label();
            this.labelKeyShrortcuts_OpenModel = new System.Windows.Forms.Label();
            this.labelKeyShrortcuts_SaveAs = new System.Windows.Forms.Label();
            this.labelKeyShrortcuts_Save = new System.Windows.Forms.Label();
            this.labelKeyShrortcuts_NewModel = new System.Windows.Forms.Label();
            this.labelKeyShrortcuts_ExportToCivMap = new System.Windows.Forms.Label();
            this.labelKeyShrortcuts_EditRegion = new System.Windows.Forms.Label();
            this.labelKeyShrortcuts_EditPlotData = new System.Windows.Forms.Label();
            this.labelKeyShrortcuts_AssignOcean = new System.Windows.Forms.Label();
            this.labelKeyShrortcuts_AssignCoast = new System.Windows.Forms.Label();
            this.labelKeyShrortcuts_AssignFlat = new System.Windows.Forms.Label();
            this.labelKeyShrortcuts_AssignHill = new System.Windows.Forms.Label();
            this.labelKeyShrortcuts_AssignMountain = new System.Windows.Forms.Label();
            this.mapDisplayTabPage = new System.Windows.Forms.TabPage();
            this.gridGroup = new System.Windows.Forms.GroupBox();
            this.highlightedPlotGridWidthLabel = new System.Windows.Forms.Label();
            this.highlightedPlotGridColorLabel = new System.Windows.Forms.Label();
            this.processedMapUnassignedGridColorLabel = new System.Windows.Forms.Label();
            this.originalMapGridLabel = new System.Windows.Forms.Label();
            this.plotWidthGroup = new System.Windows.Forms.GroupBox();
            this.rhombusPlotWidthLabel = new System.Windows.Forms.Label();
            this.squarePlotWidthLabel = new System.Windows.Forms.Label();
            this.hexPlotWidthLabel = new System.Windows.Forms.Label();
            this.terrainGroup = new System.Windows.Forms.GroupBox();
            this.mountainPlotLabel = new System.Windows.Forms.Label();
            this.hillPlotLabel = new System.Windows.Forms.Label();
            this.flatPlotLabel = new System.Windows.Forms.Label();
            this.coastPlotLabel = new System.Windows.Forms.Label();
            this.ocealPlotLabel = new System.Windows.Forms.Label();
            this.zoomGroup = new System.Windows.Forms.GroupBox();
            this.zoomStepLabel = new System.Windows.Forms.Label();
            this.maximumZoomLabel = new System.Windows.Forms.Label();
            this.minZoomLabel = new System.Windows.Forms.Label();
            this.autoCenterRegionEditFormCheckBox = new System.Windows.Forms.CheckBox();
            this.regionEditGroupBox = new System.Windows.Forms.GroupBox();
            this.selectorKeyShrortcuts_RepealAssignment = new Map2CivilizationView.UserControls.KeyboardShortcutSettingSelector();
            this.selectorKeyShrortcuts_OpenModel = new Map2CivilizationView.UserControls.KeyboardShortcutSettingSelector();
            this.selectorKeyShrortcuts_SaveAs = new Map2CivilizationView.UserControls.KeyboardShortcutSettingSelector();
            this.selectorKeyShrortcuts_Save = new Map2CivilizationView.UserControls.KeyboardShortcutSettingSelector();
            this.selectorKeyShrortcuts_NewModel = new Map2CivilizationView.UserControls.KeyboardShortcutSettingSelector();
            this.selectorKeyShrortcuts_ExportToCivMap = new Map2CivilizationView.UserControls.KeyboardShortcutSettingSelector();
            this.selectorKeyShrortcuts_EditRegion = new Map2CivilizationView.UserControls.KeyboardShortcutSettingSelector();
            this.selectorKeyShrortcuts_EditPlotData = new Map2CivilizationView.UserControls.KeyboardShortcutSettingSelector();
            this.selectorKeyShrortcuts_AssignOcean = new Map2CivilizationView.UserControls.KeyboardShortcutSettingSelector();
            this.selectorKeyShrortcuts_AssignCoast = new Map2CivilizationView.UserControls.KeyboardShortcutSettingSelector();
            this.selectorKeyShrortcuts_AssignFlat = new Map2CivilizationView.UserControls.KeyboardShortcutSettingSelector();
            this.selectorKeyShrortcuts_AssignHill = new Map2CivilizationView.UserControls.KeyboardShortcutSettingSelector();
            this.selectorKeyShrortcuts_AssignMountain = new Map2CivilizationView.UserControls.KeyboardShortcutSettingSelector();
            this.highlightedPlotGridWidthNumeric = new Map2CivilizationView.UserControls.NumericSettingSelector();
            this.highlightedGridColorSelector = new Map2CivilizationView.UserControls.ColorSettingSelector();
            this.processedMapUnassignedGridColorSelector = new Map2CivilizationView.UserControls.ColorSettingSelector();
            this.originalMapGridColorSelector = new Map2CivilizationView.UserControls.ColorSettingSelector();
            this.rhombusPlotWidthNumeric = new Map2CivilizationView.UserControls.NumericSettingSelector();
            this.squarePlotWidthNumeric = new Map2CivilizationView.UserControls.NumericSettingSelector();
            this.hexPlotWidthNumeric = new Map2CivilizationView.UserControls.NumericSettingSelector();
            this.mountainColorSelector = new Map2CivilizationView.UserControls.ColorSettingSelector();
            this.hillColorSelector = new Map2CivilizationView.UserControls.ColorSettingSelector();
            this.flatColorSelector = new Map2CivilizationView.UserControls.ColorSettingSelector();
            this.coastColorSelector = new Map2CivilizationView.UserControls.ColorSettingSelector();
            this.oceanColorSelector = new Map2CivilizationView.UserControls.ColorSettingSelector();
            this.zoomStepNumeric = new Map2CivilizationView.UserControls.NumericSettingSelector();
            this.maximumZoomNumeric = new Map2CivilizationView.UserControls.NumericSettingSelector();
            this.minimumZoomNumeric = new Map2CivilizationView.UserControls.NumericSettingSelector();
            this.buttonsPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.generalTabPage.SuspendLayout();
            this.generalTableLayoutPanel.SuspendLayout();
            this.keyboardShortcutsTabPage.SuspendLayout();
            this.keyboardShortcutsTableLayoutPanel.SuspendLayout();
            this.mapDisplayTabPage.SuspendLayout();
            this.gridGroup.SuspendLayout();
            this.plotWidthGroup.SuspendLayout();
            this.terrainGroup.SuspendLayout();
            this.zoomGroup.SuspendLayout();
            this.regionEditGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonsPanel
            // 
            resources.ApplyResources(this.buttonsPanel, "buttonsPanel");
            this.buttonsPanel.Controls.Add(this.cancelButton, 3, 0);
            this.buttonsPanel.Controls.Add(this.applyButton, 1, 0);
            this.buttonsPanel.Name = "buttonsPanel";
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // applyButton
            // 
            resources.ApplyResources(this.applyButton, "applyButton");
            this.applyButton.Name = "applyButton";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.generalTabPage);
            this.tabControl.Controls.Add(this.keyboardShortcutsTabPage);
            this.tabControl.Controls.Add(this.mapDisplayTabPage);
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // generalTabPage
            // 
            resources.ApplyResources(this.generalTabPage, "generalTabPage");
            this.generalTabPage.Controls.Add(this.generalTableLayoutPanel);
            this.generalTabPage.Name = "generalTabPage";
            this.generalTabPage.UseVisualStyleBackColor = true;
            // 
            // generalTableLayoutPanel
            // 
            resources.ApplyResources(this.generalTableLayoutPanel, "generalTableLayoutPanel");
            this.generalTableLayoutPanel.Controls.Add(this.uiCultureLabel, 0, 1);
            this.generalTableLayoutPanel.Controls.Add(this.uiLanguageComboBox, 1, 1);
            this.generalTableLayoutPanel.Controls.Add(this.revertButton, 2, 12);
            this.generalTableLayoutPanel.Name = "generalTableLayoutPanel";
            // 
            // uiCultureLabel
            // 
            resources.ApplyResources(this.uiCultureLabel, "uiCultureLabel");
            this.uiCultureLabel.Name = "uiCultureLabel";
            // 
            // uiLanguageComboBox
            // 
            resources.ApplyResources(this.uiLanguageComboBox, "uiLanguageComboBox");
            this.uiLanguageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uiLanguageComboBox.FormattingEnabled = true;
            this.uiLanguageComboBox.Name = "uiLanguageComboBox";
            // 
            // revertButton
            // 
            resources.ApplyResources(this.revertButton, "revertButton");
            this.revertButton.Name = "revertButton";
            this.revertButton.UseVisualStyleBackColor = true;
            this.revertButton.Click += new System.EventHandler(this.revertButton_Click);
            // 
            // keyboardShortcutsTabPage
            // 
            this.keyboardShortcutsTabPage.Controls.Add(this.keyboardShortcutsTableLayoutPanel);
            resources.ApplyResources(this.keyboardShortcutsTabPage, "keyboardShortcutsTabPage");
            this.keyboardShortcutsTabPage.Name = "keyboardShortcutsTabPage";
            this.keyboardShortcutsTabPage.UseVisualStyleBackColor = true;
            // 
            // keyboardShortcutsTableLayoutPanel
            // 
            resources.ApplyResources(this.keyboardShortcutsTableLayoutPanel, "keyboardShortcutsTableLayoutPanel");
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.selectorKeyShrortcuts_RepealAssignment, 1, 12);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.labelKeyShrortcuts_RepealAssignment, 0, 12);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.selectorKeyShrortcuts_OpenModel, 1, 3);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.labelKeyShrortcuts_OpenModel, 0, 3);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.labelKeyShrortcuts_SaveAs, 0, 0);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.labelKeyShrortcuts_Save, 0, 1);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.labelKeyShrortcuts_NewModel, 0, 2);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.labelKeyShrortcuts_ExportToCivMap, 0, 4);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.labelKeyShrortcuts_EditRegion, 0, 5);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.labelKeyShrortcuts_EditPlotData, 0, 6);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.labelKeyShrortcuts_AssignOcean, 0, 7);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.labelKeyShrortcuts_AssignCoast, 0, 8);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.labelKeyShrortcuts_AssignFlat, 0, 9);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.labelKeyShrortcuts_AssignHill, 0, 10);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.labelKeyShrortcuts_AssignMountain, 0, 11);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.selectorKeyShrortcuts_SaveAs, 1, 0);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.selectorKeyShrortcuts_Save, 1, 1);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.selectorKeyShrortcuts_NewModel, 1, 2);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.selectorKeyShrortcuts_ExportToCivMap, 1, 4);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.selectorKeyShrortcuts_EditRegion, 1, 5);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.selectorKeyShrortcuts_EditPlotData, 1, 6);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.selectorKeyShrortcuts_AssignOcean, 1, 7);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.selectorKeyShrortcuts_AssignCoast, 1, 8);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.selectorKeyShrortcuts_AssignFlat, 1, 9);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.selectorKeyShrortcuts_AssignHill, 1, 10);
            this.keyboardShortcutsTableLayoutPanel.Controls.Add(this.selectorKeyShrortcuts_AssignMountain, 1, 11);
            this.keyboardShortcutsTableLayoutPanel.Name = "keyboardShortcutsTableLayoutPanel";
            // 
            // labelKeyShrortcuts_RepealAssignment
            // 
            resources.ApplyResources(this.labelKeyShrortcuts_RepealAssignment, "labelKeyShrortcuts_RepealAssignment");
            this.labelKeyShrortcuts_RepealAssignment.Name = "labelKeyShrortcuts_RepealAssignment";
            // 
            // labelKeyShrortcuts_OpenModel
            // 
            resources.ApplyResources(this.labelKeyShrortcuts_OpenModel, "labelKeyShrortcuts_OpenModel");
            this.labelKeyShrortcuts_OpenModel.Name = "labelKeyShrortcuts_OpenModel";
            // 
            // labelKeyShrortcuts_SaveAs
            // 
            resources.ApplyResources(this.labelKeyShrortcuts_SaveAs, "labelKeyShrortcuts_SaveAs");
            this.labelKeyShrortcuts_SaveAs.Name = "labelKeyShrortcuts_SaveAs";
            // 
            // labelKeyShrortcuts_Save
            // 
            resources.ApplyResources(this.labelKeyShrortcuts_Save, "labelKeyShrortcuts_Save");
            this.labelKeyShrortcuts_Save.Name = "labelKeyShrortcuts_Save";
            // 
            // labelKeyShrortcuts_NewModel
            // 
            resources.ApplyResources(this.labelKeyShrortcuts_NewModel, "labelKeyShrortcuts_NewModel");
            this.labelKeyShrortcuts_NewModel.Name = "labelKeyShrortcuts_NewModel";
            // 
            // labelKeyShrortcuts_ExportToCivMap
            // 
            resources.ApplyResources(this.labelKeyShrortcuts_ExportToCivMap, "labelKeyShrortcuts_ExportToCivMap");
            this.labelKeyShrortcuts_ExportToCivMap.Name = "labelKeyShrortcuts_ExportToCivMap";
            // 
            // labelKeyShrortcuts_EditRegion
            // 
            resources.ApplyResources(this.labelKeyShrortcuts_EditRegion, "labelKeyShrortcuts_EditRegion");
            this.labelKeyShrortcuts_EditRegion.Name = "labelKeyShrortcuts_EditRegion";
            // 
            // labelKeyShrortcuts_EditPlotData
            // 
            resources.ApplyResources(this.labelKeyShrortcuts_EditPlotData, "labelKeyShrortcuts_EditPlotData");
            this.labelKeyShrortcuts_EditPlotData.Name = "labelKeyShrortcuts_EditPlotData";
            // 
            // labelKeyShrortcuts_AssignOcean
            // 
            resources.ApplyResources(this.labelKeyShrortcuts_AssignOcean, "labelKeyShrortcuts_AssignOcean");
            this.labelKeyShrortcuts_AssignOcean.Name = "labelKeyShrortcuts_AssignOcean";
            // 
            // labelKeyShrortcuts_AssignCoast
            // 
            resources.ApplyResources(this.labelKeyShrortcuts_AssignCoast, "labelKeyShrortcuts_AssignCoast");
            this.labelKeyShrortcuts_AssignCoast.Name = "labelKeyShrortcuts_AssignCoast";
            // 
            // labelKeyShrortcuts_AssignFlat
            // 
            resources.ApplyResources(this.labelKeyShrortcuts_AssignFlat, "labelKeyShrortcuts_AssignFlat");
            this.labelKeyShrortcuts_AssignFlat.Name = "labelKeyShrortcuts_AssignFlat";
            // 
            // labelKeyShrortcuts_AssignHill
            // 
            resources.ApplyResources(this.labelKeyShrortcuts_AssignHill, "labelKeyShrortcuts_AssignHill");
            this.labelKeyShrortcuts_AssignHill.Name = "labelKeyShrortcuts_AssignHill";
            // 
            // labelKeyShrortcuts_AssignMountain
            // 
            resources.ApplyResources(this.labelKeyShrortcuts_AssignMountain, "labelKeyShrortcuts_AssignMountain");
            this.labelKeyShrortcuts_AssignMountain.Name = "labelKeyShrortcuts_AssignMountain";
            // 
            // mapDisplayTabPage
            // 
            this.mapDisplayTabPage.Controls.Add(this.regionEditGroupBox);
            this.mapDisplayTabPage.Controls.Add(this.gridGroup);
            this.mapDisplayTabPage.Controls.Add(this.plotWidthGroup);
            this.mapDisplayTabPage.Controls.Add(this.terrainGroup);
            this.mapDisplayTabPage.Controls.Add(this.zoomGroup);
            resources.ApplyResources(this.mapDisplayTabPage, "mapDisplayTabPage");
            this.mapDisplayTabPage.Name = "mapDisplayTabPage";
            this.mapDisplayTabPage.UseVisualStyleBackColor = true;
            // 
            // gridGroup
            // 
            this.gridGroup.Controls.Add(this.highlightedPlotGridWidthNumeric);
            this.gridGroup.Controls.Add(this.highlightedPlotGridWidthLabel);
            this.gridGroup.Controls.Add(this.highlightedPlotGridColorLabel);
            this.gridGroup.Controls.Add(this.highlightedGridColorSelector);
            this.gridGroup.Controls.Add(this.processedMapUnassignedGridColorLabel);
            this.gridGroup.Controls.Add(this.processedMapUnassignedGridColorSelector);
            this.gridGroup.Controls.Add(this.originalMapGridLabel);
            this.gridGroup.Controls.Add(this.originalMapGridColorSelector);
            resources.ApplyResources(this.gridGroup, "gridGroup");
            this.gridGroup.Name = "gridGroup";
            this.gridGroup.TabStop = false;
            // 
            // highlightedPlotGridWidthLabel
            // 
            resources.ApplyResources(this.highlightedPlotGridWidthLabel, "highlightedPlotGridWidthLabel");
            this.highlightedPlotGridWidthLabel.Name = "highlightedPlotGridWidthLabel";
            // 
            // highlightedPlotGridColorLabel
            // 
            resources.ApplyResources(this.highlightedPlotGridColorLabel, "highlightedPlotGridColorLabel");
            this.highlightedPlotGridColorLabel.Name = "highlightedPlotGridColorLabel";
            // 
            // processedMapUnassignedGridColorLabel
            // 
            resources.ApplyResources(this.processedMapUnassignedGridColorLabel, "processedMapUnassignedGridColorLabel");
            this.processedMapUnassignedGridColorLabel.Name = "processedMapUnassignedGridColorLabel";
            // 
            // originalMapGridLabel
            // 
            resources.ApplyResources(this.originalMapGridLabel, "originalMapGridLabel");
            this.originalMapGridLabel.Name = "originalMapGridLabel";
            // 
            // plotWidthGroup
            // 
            this.plotWidthGroup.Controls.Add(this.rhombusPlotWidthNumeric);
            this.plotWidthGroup.Controls.Add(this.squarePlotWidthNumeric);
            this.plotWidthGroup.Controls.Add(this.hexPlotWidthNumeric);
            this.plotWidthGroup.Controls.Add(this.rhombusPlotWidthLabel);
            this.plotWidthGroup.Controls.Add(this.squarePlotWidthLabel);
            this.plotWidthGroup.Controls.Add(this.hexPlotWidthLabel);
            resources.ApplyResources(this.plotWidthGroup, "plotWidthGroup");
            this.plotWidthGroup.Name = "plotWidthGroup";
            this.plotWidthGroup.TabStop = false;
            // 
            // rhombusPlotWidthLabel
            // 
            resources.ApplyResources(this.rhombusPlotWidthLabel, "rhombusPlotWidthLabel");
            this.rhombusPlotWidthLabel.Name = "rhombusPlotWidthLabel";
            // 
            // squarePlotWidthLabel
            // 
            resources.ApplyResources(this.squarePlotWidthLabel, "squarePlotWidthLabel");
            this.squarePlotWidthLabel.Name = "squarePlotWidthLabel";
            // 
            // hexPlotWidthLabel
            // 
            resources.ApplyResources(this.hexPlotWidthLabel, "hexPlotWidthLabel");
            this.hexPlotWidthLabel.Name = "hexPlotWidthLabel";
            // 
            // terrainGroup
            // 
            this.terrainGroup.Controls.Add(this.mountainColorSelector);
            this.terrainGroup.Controls.Add(this.mountainPlotLabel);
            this.terrainGroup.Controls.Add(this.hillPlotLabel);
            this.terrainGroup.Controls.Add(this.flatPlotLabel);
            this.terrainGroup.Controls.Add(this.coastPlotLabel);
            this.terrainGroup.Controls.Add(this.ocealPlotLabel);
            this.terrainGroup.Controls.Add(this.hillColorSelector);
            this.terrainGroup.Controls.Add(this.flatColorSelector);
            this.terrainGroup.Controls.Add(this.coastColorSelector);
            this.terrainGroup.Controls.Add(this.oceanColorSelector);
            resources.ApplyResources(this.terrainGroup, "terrainGroup");
            this.terrainGroup.Name = "terrainGroup";
            this.terrainGroup.TabStop = false;
            // 
            // mountainPlotLabel
            // 
            resources.ApplyResources(this.mountainPlotLabel, "mountainPlotLabel");
            this.mountainPlotLabel.Name = "mountainPlotLabel";
            // 
            // hillPlotLabel
            // 
            resources.ApplyResources(this.hillPlotLabel, "hillPlotLabel");
            this.hillPlotLabel.Name = "hillPlotLabel";
            // 
            // flatPlotLabel
            // 
            resources.ApplyResources(this.flatPlotLabel, "flatPlotLabel");
            this.flatPlotLabel.Name = "flatPlotLabel";
            // 
            // coastPlotLabel
            // 
            resources.ApplyResources(this.coastPlotLabel, "coastPlotLabel");
            this.coastPlotLabel.Name = "coastPlotLabel";
            // 
            // ocealPlotLabel
            // 
            resources.ApplyResources(this.ocealPlotLabel, "ocealPlotLabel");
            this.ocealPlotLabel.Name = "ocealPlotLabel";
            // 
            // zoomGroup
            // 
            this.zoomGroup.Controls.Add(this.zoomStepNumeric);
            this.zoomGroup.Controls.Add(this.maximumZoomNumeric);
            this.zoomGroup.Controls.Add(this.minimumZoomNumeric);
            this.zoomGroup.Controls.Add(this.zoomStepLabel);
            this.zoomGroup.Controls.Add(this.maximumZoomLabel);
            this.zoomGroup.Controls.Add(this.minZoomLabel);
            resources.ApplyResources(this.zoomGroup, "zoomGroup");
            this.zoomGroup.Name = "zoomGroup";
            this.zoomGroup.TabStop = false;
            // 
            // zoomStepLabel
            // 
            resources.ApplyResources(this.zoomStepLabel, "zoomStepLabel");
            this.zoomStepLabel.Name = "zoomStepLabel";
            // 
            // maximumZoomLabel
            // 
            resources.ApplyResources(this.maximumZoomLabel, "maximumZoomLabel");
            this.maximumZoomLabel.Name = "maximumZoomLabel";
            // 
            // minZoomLabel
            // 
            resources.ApplyResources(this.minZoomLabel, "minZoomLabel");
            this.minZoomLabel.Name = "minZoomLabel";
            // 
            // autoCenterRegionEditFormCheckBox
            // 
            resources.ApplyResources(this.autoCenterRegionEditFormCheckBox, "autoCenterRegionEditFormCheckBox");
            this.autoCenterRegionEditFormCheckBox.Checked = true;
            this.autoCenterRegionEditFormCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoCenterRegionEditFormCheckBox.Name = "autoCenterRegionEditFormCheckBox";
            this.autoCenterRegionEditFormCheckBox.UseVisualStyleBackColor = true;
            this.autoCenterRegionEditFormCheckBox.CheckedChanged += new System.EventHandler(this.autoCenterRegionEditForm_CheckedChanged);
            // 
            // regionEditGroupBox
            // 
            this.regionEditGroupBox.Controls.Add(this.autoCenterRegionEditFormCheckBox);
            resources.ApplyResources(this.regionEditGroupBox, "regionEditGroupBox");
            this.regionEditGroupBox.Name = "regionEditGroupBox";
            this.regionEditGroupBox.TabStop = false;
            // 
            // selectorKeyShrortcuts_RepealAssignment
            // 
            resources.ApplyResources(this.selectorKeyShrortcuts_RepealAssignment, "selectorKeyShrortcuts_RepealAssignment");
            this.selectorKeyShrortcuts_RepealAssignment.Name = "selectorKeyShrortcuts_RepealAssignment";
            // 
            // selectorKeyShrortcuts_OpenModel
            // 
            resources.ApplyResources(this.selectorKeyShrortcuts_OpenModel, "selectorKeyShrortcuts_OpenModel");
            this.selectorKeyShrortcuts_OpenModel.Name = "selectorKeyShrortcuts_OpenModel";
            // 
            // selectorKeyShrortcuts_SaveAs
            // 
            resources.ApplyResources(this.selectorKeyShrortcuts_SaveAs, "selectorKeyShrortcuts_SaveAs");
            this.selectorKeyShrortcuts_SaveAs.Name = "selectorKeyShrortcuts_SaveAs";
            // 
            // selectorKeyShrortcuts_Save
            // 
            resources.ApplyResources(this.selectorKeyShrortcuts_Save, "selectorKeyShrortcuts_Save");
            this.selectorKeyShrortcuts_Save.Name = "selectorKeyShrortcuts_Save";
            // 
            // selectorKeyShrortcuts_NewModel
            // 
            resources.ApplyResources(this.selectorKeyShrortcuts_NewModel, "selectorKeyShrortcuts_NewModel");
            this.selectorKeyShrortcuts_NewModel.Name = "selectorKeyShrortcuts_NewModel";
            // 
            // selectorKeyShrortcuts_ExportToCivMap
            // 
            resources.ApplyResources(this.selectorKeyShrortcuts_ExportToCivMap, "selectorKeyShrortcuts_ExportToCivMap");
            this.selectorKeyShrortcuts_ExportToCivMap.Name = "selectorKeyShrortcuts_ExportToCivMap";
            // 
            // selectorKeyShrortcuts_EditRegion
            // 
            resources.ApplyResources(this.selectorKeyShrortcuts_EditRegion, "selectorKeyShrortcuts_EditRegion");
            this.selectorKeyShrortcuts_EditRegion.Name = "selectorKeyShrortcuts_EditRegion";
            // 
            // selectorKeyShrortcuts_EditPlotData
            // 
            resources.ApplyResources(this.selectorKeyShrortcuts_EditPlotData, "selectorKeyShrortcuts_EditPlotData");
            this.selectorKeyShrortcuts_EditPlotData.Name = "selectorKeyShrortcuts_EditPlotData";
            // 
            // selectorKeyShrortcuts_AssignOcean
            // 
            resources.ApplyResources(this.selectorKeyShrortcuts_AssignOcean, "selectorKeyShrortcuts_AssignOcean");
            this.selectorKeyShrortcuts_AssignOcean.Name = "selectorKeyShrortcuts_AssignOcean";
            // 
            // selectorKeyShrortcuts_AssignCoast
            // 
            resources.ApplyResources(this.selectorKeyShrortcuts_AssignCoast, "selectorKeyShrortcuts_AssignCoast");
            this.selectorKeyShrortcuts_AssignCoast.Name = "selectorKeyShrortcuts_AssignCoast";
            // 
            // selectorKeyShrortcuts_AssignFlat
            // 
            resources.ApplyResources(this.selectorKeyShrortcuts_AssignFlat, "selectorKeyShrortcuts_AssignFlat");
            this.selectorKeyShrortcuts_AssignFlat.Name = "selectorKeyShrortcuts_AssignFlat";
            // 
            // selectorKeyShrortcuts_AssignHill
            // 
            resources.ApplyResources(this.selectorKeyShrortcuts_AssignHill, "selectorKeyShrortcuts_AssignHill");
            this.selectorKeyShrortcuts_AssignHill.Name = "selectorKeyShrortcuts_AssignHill";
            // 
            // selectorKeyShrortcuts_AssignMountain
            // 
            resources.ApplyResources(this.selectorKeyShrortcuts_AssignMountain, "selectorKeyShrortcuts_AssignMountain");
            this.selectorKeyShrortcuts_AssignMountain.Name = "selectorKeyShrortcuts_AssignMountain";
            // 
            // highlightedPlotGridWidthNumeric
            // 
            this.highlightedPlotGridWidthNumeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            resources.ApplyResources(this.highlightedPlotGridWidthNumeric, "highlightedPlotGridWidthNumeric");
            this.highlightedPlotGridWidthNumeric.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.highlightedPlotGridWidthNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.highlightedPlotGridWidthNumeric.Name = "highlightedPlotGridWidthNumeric";
            this.highlightedPlotGridWidthNumeric.NumericSelectorValueChanged = null;
            this.highlightedPlotGridWidthNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // highlightedGridColorSelector
            // 
            this.highlightedGridColorSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.highlightedGridColorSelector.ColorSelectorValueChanged = null;
            resources.ApplyResources(this.highlightedGridColorSelector, "highlightedGridColorSelector");
            this.highlightedGridColorSelector.Name = "highlightedGridColorSelector";
            // 
            // processedMapUnassignedGridColorSelector
            // 
            this.processedMapUnassignedGridColorSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.processedMapUnassignedGridColorSelector.ColorSelectorValueChanged = null;
            resources.ApplyResources(this.processedMapUnassignedGridColorSelector, "processedMapUnassignedGridColorSelector");
            this.processedMapUnassignedGridColorSelector.Name = "processedMapUnassignedGridColorSelector";
            // 
            // originalMapGridColorSelector
            // 
            this.originalMapGridColorSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.originalMapGridColorSelector.ColorSelectorValueChanged = null;
            resources.ApplyResources(this.originalMapGridColorSelector, "originalMapGridColorSelector");
            this.originalMapGridColorSelector.Name = "originalMapGridColorSelector";
            // 
            // rhombusPlotWidthNumeric
            // 
            this.rhombusPlotWidthNumeric.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            resources.ApplyResources(this.rhombusPlotWidthNumeric, "rhombusPlotWidthNumeric");
            this.rhombusPlotWidthNumeric.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.rhombusPlotWidthNumeric.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.rhombusPlotWidthNumeric.Name = "rhombusPlotWidthNumeric";
            this.rhombusPlotWidthNumeric.NumericSelectorValueChanged = null;
            this.rhombusPlotWidthNumeric.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // squarePlotWidthNumeric
            // 
            this.squarePlotWidthNumeric.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            resources.ApplyResources(this.squarePlotWidthNumeric, "squarePlotWidthNumeric");
            this.squarePlotWidthNumeric.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.squarePlotWidthNumeric.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.squarePlotWidthNumeric.Name = "squarePlotWidthNumeric";
            this.squarePlotWidthNumeric.NumericSelectorValueChanged = null;
            this.squarePlotWidthNumeric.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // hexPlotWidthNumeric
            // 
            this.hexPlotWidthNumeric.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            resources.ApplyResources(this.hexPlotWidthNumeric, "hexPlotWidthNumeric");
            this.hexPlotWidthNumeric.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.hexPlotWidthNumeric.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.hexPlotWidthNumeric.Name = "hexPlotWidthNumeric";
            this.hexPlotWidthNumeric.NumericSelectorValueChanged = null;
            this.hexPlotWidthNumeric.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // mountainColorSelector
            // 
            this.mountainColorSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mountainColorSelector.ColorSelectorValueChanged = null;
            resources.ApplyResources(this.mountainColorSelector, "mountainColorSelector");
            this.mountainColorSelector.Name = "mountainColorSelector";
            // 
            // hillColorSelector
            // 
            this.hillColorSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hillColorSelector.ColorSelectorValueChanged = null;
            resources.ApplyResources(this.hillColorSelector, "hillColorSelector");
            this.hillColorSelector.Name = "hillColorSelector";
            // 
            // flatColorSelector
            // 
            this.flatColorSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flatColorSelector.ColorSelectorValueChanged = null;
            resources.ApplyResources(this.flatColorSelector, "flatColorSelector");
            this.flatColorSelector.Name = "flatColorSelector";
            // 
            // coastColorSelector
            // 
            this.coastColorSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.coastColorSelector.ColorSelectorValueChanged = null;
            resources.ApplyResources(this.coastColorSelector, "coastColorSelector");
            this.coastColorSelector.Name = "coastColorSelector";
            // 
            // oceanColorSelector
            // 
            this.oceanColorSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.oceanColorSelector.ColorSelectorValueChanged = null;
            resources.ApplyResources(this.oceanColorSelector, "oceanColorSelector");
            this.oceanColorSelector.Name = "oceanColorSelector";
            // 
            // zoomStepNumeric
            // 
            this.zoomStepNumeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            resources.ApplyResources(this.zoomStepNumeric, "zoomStepNumeric");
            this.zoomStepNumeric.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.zoomStepNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.zoomStepNumeric.Name = "zoomStepNumeric";
            this.zoomStepNumeric.NumericSelectorValueChanged = null;
            this.zoomStepNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // maximumZoomNumeric
            // 
            this.maximumZoomNumeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            resources.ApplyResources(this.maximumZoomNumeric, "maximumZoomNumeric");
            this.maximumZoomNumeric.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.maximumZoomNumeric.Minimum = new decimal(new int[] {
            101,
            0,
            0,
            0});
            this.maximumZoomNumeric.Name = "maximumZoomNumeric";
            this.maximumZoomNumeric.NumericSelectorValueChanged = null;
            this.maximumZoomNumeric.Value = new decimal(new int[] {
            101,
            0,
            0,
            0});
            // 
            // minimumZoomNumeric
            // 
            this.minimumZoomNumeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            resources.ApplyResources(this.minimumZoomNumeric, "minimumZoomNumeric");
            this.minimumZoomNumeric.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.minimumZoomNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minimumZoomNumeric.Name = "minimumZoomNumeric";
            this.minimumZoomNumeric.NumericSelectorValueChanged = null;
            this.minimumZoomNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.buttonsPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.buttonsPanel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.generalTabPage.ResumeLayout(false);
            this.generalTableLayoutPanel.ResumeLayout(false);
            this.generalTableLayoutPanel.PerformLayout();
            this.keyboardShortcutsTabPage.ResumeLayout(false);
            this.keyboardShortcutsTableLayoutPanel.ResumeLayout(false);
            this.keyboardShortcutsTableLayoutPanel.PerformLayout();
            this.mapDisplayTabPage.ResumeLayout(false);
            this.gridGroup.ResumeLayout(false);
            this.gridGroup.PerformLayout();
            this.plotWidthGroup.ResumeLayout(false);
            this.terrainGroup.ResumeLayout(false);
            this.terrainGroup.PerformLayout();
            this.zoomGroup.ResumeLayout(false);
            this.regionEditGroupBox.ResumeLayout(false);
            this.regionEditGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

         System.Windows.Forms.TableLayoutPanel buttonsPanel;
         System.Windows.Forms.Button cancelButton;
         System.Windows.Forms.Button applyButton;
         System.Windows.Forms.TabControl tabControl;
         System.Windows.Forms.TabPage generalTabPage;
         System.Windows.Forms.TableLayoutPanel generalTableLayoutPanel;
         System.Windows.Forms.Label uiCultureLabel;
         System.Windows.Forms.ComboBox uiLanguageComboBox;
         System.Windows.Forms.TabPage keyboardShortcutsTabPage;
         System.Windows.Forms.TableLayoutPanel keyboardShortcutsTableLayoutPanel;
         System.Windows.Forms.Label labelKeyShrortcuts_SaveAs;
         System.Windows.Forms.Label labelKeyShrortcuts_Save;
         System.Windows.Forms.Label labelKeyShrortcuts_NewModel;
         System.Windows.Forms.Label labelKeyShrortcuts_ExportToCivMap;
         System.Windows.Forms.Label labelKeyShrortcuts_EditRegion;
         System.Windows.Forms.Label labelKeyShrortcuts_EditPlotData;
         System.Windows.Forms.Label labelKeyShrortcuts_AssignOcean;
         System.Windows.Forms.Label labelKeyShrortcuts_AssignCoast;
         System.Windows.Forms.Label labelKeyShrortcuts_AssignFlat;
         System.Windows.Forms.Label labelKeyShrortcuts_AssignHill;
         System.Windows.Forms.Label labelKeyShrortcuts_AssignMountain;
         UserControls.KeyboardShortcutSettingSelector selectorKeyShrortcuts_SaveAs;
         UserControls.KeyboardShortcutSettingSelector selectorKeyShrortcuts_Save;
         UserControls.KeyboardShortcutSettingSelector selectorKeyShrortcuts_NewModel;
         UserControls.KeyboardShortcutSettingSelector selectorKeyShrortcuts_ExportToCivMap;
         UserControls.KeyboardShortcutSettingSelector selectorKeyShrortcuts_EditRegion;
         UserControls.KeyboardShortcutSettingSelector selectorKeyShrortcuts_EditPlotData;
         UserControls.KeyboardShortcutSettingSelector selectorKeyShrortcuts_AssignOcean;
         UserControls.KeyboardShortcutSettingSelector selectorKeyShrortcuts_AssignCoast;
         UserControls.KeyboardShortcutSettingSelector selectorKeyShrortcuts_AssignFlat;
         UserControls.KeyboardShortcutSettingSelector selectorKeyShrortcuts_AssignHill;
         UserControls.KeyboardShortcutSettingSelector selectorKeyShrortcuts_AssignMountain;
         System.Windows.Forms.TabPage mapDisplayTabPage;
         System.Windows.Forms.GroupBox gridGroup;
         System.Windows.Forms.Label highlightedPlotGridWidthLabel;
         System.Windows.Forms.Label highlightedPlotGridColorLabel;
         UserControls.ColorSettingSelector highlightedGridColorSelector;
         System.Windows.Forms.Label processedMapUnassignedGridColorLabel;
         UserControls.ColorSettingSelector processedMapUnassignedGridColorSelector;
         System.Windows.Forms.Label originalMapGridLabel;
         UserControls.ColorSettingSelector originalMapGridColorSelector;
         System.Windows.Forms.GroupBox plotWidthGroup;
         System.Windows.Forms.Label rhombusPlotWidthLabel;
         System.Windows.Forms.Label squarePlotWidthLabel;
         System.Windows.Forms.Label hexPlotWidthLabel;
         System.Windows.Forms.GroupBox terrainGroup;
         UserControls.ColorSettingSelector mountainColorSelector;
         System.Windows.Forms.Label mountainPlotLabel;
         System.Windows.Forms.Label hillPlotLabel;
         System.Windows.Forms.Label flatPlotLabel;
         System.Windows.Forms.Label coastPlotLabel;
         System.Windows.Forms.Label ocealPlotLabel;
         UserControls.ColorSettingSelector hillColorSelector;
         UserControls.ColorSettingSelector flatColorSelector;
         UserControls.ColorSettingSelector coastColorSelector;
         UserControls.ColorSettingSelector oceanColorSelector;
         System.Windows.Forms.GroupBox zoomGroup;
         System.Windows.Forms.Label zoomStepLabel;
         System.Windows.Forms.Label maximumZoomLabel;
         System.Windows.Forms.Label minZoomLabel;
         System.Windows.Forms.Button revertButton;
         System.Windows.Forms.Label labelKeyShrortcuts_OpenModel;
         UserControls.KeyboardShortcutSettingSelector selectorKeyShrortcuts_OpenModel;
        private UserControls.NumericSettingSelector highlightedPlotGridWidthNumeric;
        private UserControls.NumericSettingSelector rhombusPlotWidthNumeric;
        private UserControls.NumericSettingSelector squarePlotWidthNumeric;
        private UserControls.NumericSettingSelector hexPlotWidthNumeric;
        private UserControls.NumericSettingSelector zoomStepNumeric;
        private UserControls.NumericSettingSelector maximumZoomNumeric;
        private UserControls.NumericSettingSelector minimumZoomNumeric;
        private UserControls.KeyboardShortcutSettingSelector selectorKeyShrortcuts_RepealAssignment;
        private System.Windows.Forms.Label labelKeyShrortcuts_RepealAssignment;
        private System.Windows.Forms.CheckBox autoCenterRegionEditFormCheckBox;
        private System.Windows.Forms.GroupBox regionEditGroupBox;
    }
}