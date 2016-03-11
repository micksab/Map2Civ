using System.CodeDom.Compiler;

namespace Map2CivilizationView
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        [GeneratedCodeAttribute("Winform Designer GeneratedCode", "VS2015")]
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
        [GeneratedCodeAttribute("Winform Designer GeneratedCode", "VS2015")]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.newModelButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.loadMapButton = new System.Windows.Forms.ToolStripButton();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.saveAsButton = new System.Windows.Forms.ToolStripButton();
            this.exportToCivMap = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.zoomInButton = new System.Windows.Forms.ToolStripButton();
            this.zoomOutButton = new System.Windows.Forms.ToolStripButton();
            this.zoomDefaultButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.helpButton = new System.Windows.Forms.ToolStripButton();
            this.aboutButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToCivStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.plotHeaderLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.selectedPlotLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.coordinatesHeaderLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.plotCoordinatesLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.civilizationVersionHeaderLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.civVersionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mapSizeHeaderLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MapSizeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.colorsDetectedHeaderLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.colorCountLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.percentCompleteHeaderLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.percentCompleteLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.workingAreaPanel = new System.Windows.Forms.Panel();
            this.tabContainer = new System.Windows.Forms.TabControl();
            this.originalMapTabPage = new System.Windows.Forms.TabPage();
            this.processedMapTabPage = new System.Windows.Forms.TabPage();
            this.tabImageList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.workingAreaPanel.SuspendLayout();
            this.tabContainer.SuspendLayout();
            this.processedMapTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer.Name = "splitContainer";
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.toolStrip);
            this.buttonsPanel.Controls.Add(this.menuStrip);
            resources.ApplyResources(this.buttonsPanel, "buttonsPanel");
            this.buttonsPanel.Name = "buttonsPanel";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newModelButton,
            this.toolStripSeparator1,
            this.loadMapButton,
            this.saveButton,
            this.saveAsButton,
            this.exportToCivMap,
            this.toolStripSeparator2,
            this.zoomInButton,
            this.zoomOutButton,
            this.zoomDefaultButton,
            this.toolStripSeparator3,
            this.settingsButton,
            this.toolStripSeparator4,
            this.helpButton,
            this.aboutButton});
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Name = "toolStrip";
            // 
            // newModelButton
            // 
            resources.ApplyResources(this.newModelButton, "newModelButton");
            this.newModelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newModelButton.Name = "newModelButton";
            this.newModelButton.Click += new System.EventHandler(this.NewModel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // loadMapButton
            // 
            resources.ApplyResources(this.loadMapButton, "loadMapButton");
            this.loadMapButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loadMapButton.Name = "loadMapButton";
            this.loadMapButton.Click += new System.EventHandler(this.LoadModel_Click);
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveButton.Image = global::Map2Civilization.Properties.Resources.Save_Image;
            this.saveButton.Name = "saveButton";
            this.saveButton.Click += new System.EventHandler(this.SaveModel_Click);
            // 
            // saveAsButton
            // 
            this.saveAsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.saveAsButton, "saveAsButton");
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Click += new System.EventHandler(this.SaveAsModel_Click);
            // 
            // exportToCivMap
            // 
            resources.ApplyResources(this.exportToCivMap, "exportToCivMap");
            this.exportToCivMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exportToCivMap.Image = global::Map2Civilization.Properties.Resources.Export_Image;
            this.exportToCivMap.Name = "exportToCivMap";
            this.exportToCivMap.Click += new System.EventHandler(this.ExportToCivMap_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // zoomInButton
            // 
            resources.ApplyResources(this.zoomInButton, "zoomInButton");
            this.zoomInButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomInButton.Image = global::Map2Civilization.Properties.Resources.Zoom_in_Image;
            this.zoomInButton.Name = "zoomInButton";
            this.zoomInButton.Click += new System.EventHandler(this.zoomInButton_Click);
            // 
            // zoomOutButton
            // 
            resources.ApplyResources(this.zoomOutButton, "zoomOutButton");
            this.zoomOutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomOutButton.Image = global::Map2Civilization.Properties.Resources.Zoom_out_Image;
            this.zoomOutButton.Name = "zoomOutButton";
            this.zoomOutButton.Click += new System.EventHandler(this.zoomOutButton_Click);
            // 
            // zoomDefaultButton
            // 
            resources.ApplyResources(this.zoomDefaultButton, "zoomDefaultButton");
            this.zoomDefaultButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomDefaultButton.Image = global::Map2Civilization.Properties.Resources.Zoom100_Image;
            this.zoomDefaultButton.Name = "zoomDefaultButton";
            this.zoomDefaultButton.Click += new System.EventHandler(this.defaultZoomButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // settingsButton
            // 
            resources.ApplyResources(this.settingsButton, "settingsButton");
            this.settingsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // helpButton
            // 
            this.helpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.helpButton, "helpButton");
            this.helpButton.Name = "helpButton";
            // 
            // aboutButton
            // 
            resources.ApplyResources(this.aboutButton, "aboutButton");
            this.aboutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.aboutButton.Image = global::Map2Civilization.Properties.Resources.About_Image;
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Click += new System.EventHandler(this.About_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.settingsMenu,
            this.helpMenu});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newStripMenuItem,
            this.openStripMenuItem,
            this.saveStripMenuItem,
            this.saveAsStripMenuItem,
            this.exportToCivStripMenuItem});
            this.fileMenu.Name = "fileMenu";
            resources.ApplyResources(this.fileMenu, "fileMenu");
            // 
            // newStripMenuItem
            // 
            resources.ApplyResources(this.newStripMenuItem, "newStripMenuItem");
            this.newStripMenuItem.Name = "newStripMenuItem";
            this.newStripMenuItem.ShortcutKeys = global::Map2Civilization.Properties.Settings.Default.KeyShrortcuts_NewModel;
            this.newStripMenuItem.Click += new System.EventHandler(this.NewModel_Click);
            // 
            // openStripMenuItem
            // 
            resources.ApplyResources(this.openStripMenuItem, "openStripMenuItem");
            this.openStripMenuItem.Name = "openStripMenuItem";
            this.openStripMenuItem.ShortcutKeys = global::Map2Civilization.Properties.Settings.Default.KeyShrortcuts_OpenModel;
            this.openStripMenuItem.Click += new System.EventHandler(this.LoadModel_Click);
            // 
            // saveStripMenuItem
            // 
            resources.ApplyResources(this.saveStripMenuItem, "saveStripMenuItem");
            this.saveStripMenuItem.Image = global::Map2Civilization.Properties.Resources.Save_Image;
            this.saveStripMenuItem.Name = "saveStripMenuItem";
            this.saveStripMenuItem.ShortcutKeys = global::Map2Civilization.Properties.Settings.Default.KeyShrortcuts_Save;
            this.saveStripMenuItem.Click += new System.EventHandler(this.SaveModel_Click);
            // 
            // saveAsStripMenuItem
            // 
            resources.ApplyResources(this.saveAsStripMenuItem, "saveAsStripMenuItem");
            this.saveAsStripMenuItem.Name = "saveAsStripMenuItem";
            this.saveAsStripMenuItem.ShortcutKeys = global::Map2Civilization.Properties.Settings.Default.KeyShrortcuts_SaveAs;
            this.saveAsStripMenuItem.Click += new System.EventHandler(this.SaveAsModel_Click);
            // 
            // exportToCivStripMenuItem
            // 
            resources.ApplyResources(this.exportToCivStripMenuItem, "exportToCivStripMenuItem");
            this.exportToCivStripMenuItem.Image = global::Map2Civilization.Properties.Resources.Export_Image;
            this.exportToCivStripMenuItem.Name = "exportToCivStripMenuItem";
            this.exportToCivStripMenuItem.ShortcutKeys = global::Map2Civilization.Properties.Settings.Default.KeyShrortcuts_ExportToCivMap;
            this.exportToCivStripMenuItem.Click += new System.EventHandler(this.ExportToCivMap_Click);
            // 
            // settingsMenu
            // 
            this.settingsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsStripMenuItem});
            this.settingsMenu.Name = "settingsMenu";
            resources.ApplyResources(this.settingsMenu, "settingsMenu");
            // 
            // settingsStripMenuItem
            // 
            resources.ApplyResources(this.settingsStripMenuItem, "settingsStripMenuItem");
            this.settingsStripMenuItem.Name = "settingsStripMenuItem";
            this.settingsStripMenuItem.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpStripMenuItem,
            this.aboutStripMenuItem});
            this.helpMenu.Name = "helpMenu";
            resources.ApplyResources(this.helpMenu, "helpMenu");
            // 
            // helpStripMenuItem
            // 
            resources.ApplyResources(this.helpStripMenuItem, "helpStripMenuItem");
            this.helpStripMenuItem.Name = "helpStripMenuItem";
            // 
            // aboutStripMenuItem
            // 
            this.aboutStripMenuItem.Image = global::Map2Civilization.Properties.Resources.About_Image;
            this.aboutStripMenuItem.Name = "aboutStripMenuItem";
            resources.ApplyResources(this.aboutStripMenuItem, "aboutStripMenuItem");
            this.aboutStripMenuItem.Click += new System.EventHandler(this.About_Click);
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.statusStrip);
            resources.ApplyResources(this.bottomPanel, "bottomPanel");
            this.bottomPanel.Name = "bottomPanel";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plotHeaderLabel,
            this.selectedPlotLabel,
            this.coordinatesHeaderLabel,
            this.plotCoordinatesLabel,
            this.civilizationVersionHeaderLabel,
            this.civVersionLabel,
            this.mapSizeHeaderLabel,
            this.MapSizeLabel,
            this.colorsDetectedHeaderLabel,
            this.colorCountLabel,
            this.percentCompleteHeaderLabel,
            this.percentCompleteLabel,
            this.progressBar});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // plotHeaderLabel
            // 
            this.plotHeaderLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.plotHeaderLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.plotHeaderLabel.Name = "plotHeaderLabel";
            resources.ApplyResources(this.plotHeaderLabel, "plotHeaderLabel");
            // 
            // selectedPlotLabel
            // 
            resources.ApplyResources(this.selectedPlotLabel, "selectedPlotLabel");
            this.selectedPlotLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.selectedPlotLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.selectedPlotLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.selectedPlotLabel.Name = "selectedPlotLabel";
            // 
            // coordinatesHeaderLabel
            // 
            this.coordinatesHeaderLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.coordinatesHeaderLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.coordinatesHeaderLabel.Name = "coordinatesHeaderLabel";
            resources.ApplyResources(this.coordinatesHeaderLabel, "coordinatesHeaderLabel");
            // 
            // plotCoordinatesLabel
            // 
            resources.ApplyResources(this.plotCoordinatesLabel, "plotCoordinatesLabel");
            this.plotCoordinatesLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.plotCoordinatesLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.plotCoordinatesLabel.Name = "plotCoordinatesLabel";
            // 
            // civilizationVersionHeaderLabel
            // 
            this.civilizationVersionHeaderLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.civilizationVersionHeaderLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.civilizationVersionHeaderLabel.Name = "civilizationVersionHeaderLabel";
            resources.ApplyResources(this.civilizationVersionHeaderLabel, "civilizationVersionHeaderLabel");
            // 
            // civVersionLabel
            // 
            resources.ApplyResources(this.civVersionLabel, "civVersionLabel");
            this.civVersionLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.civVersionLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.civVersionLabel.Name = "civVersionLabel";
            // 
            // mapSizeHeaderLabel
            // 
            this.mapSizeHeaderLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.mapSizeHeaderLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.mapSizeHeaderLabel.Name = "mapSizeHeaderLabel";
            resources.ApplyResources(this.mapSizeHeaderLabel, "mapSizeHeaderLabel");
            // 
            // MapSizeLabel
            // 
            resources.ApplyResources(this.MapSizeLabel, "MapSizeLabel");
            this.MapSizeLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.MapSizeLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.MapSizeLabel.Name = "MapSizeLabel";
            // 
            // colorsDetectedHeaderLabel
            // 
            this.colorsDetectedHeaderLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.colorsDetectedHeaderLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.colorsDetectedHeaderLabel.Name = "colorsDetectedHeaderLabel";
            resources.ApplyResources(this.colorsDetectedHeaderLabel, "colorsDetectedHeaderLabel");
            // 
            // colorCountLabel
            // 
            resources.ApplyResources(this.colorCountLabel, "colorCountLabel");
            this.colorCountLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.colorCountLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.colorCountLabel.Name = "colorCountLabel";
            // 
            // percentCompleteHeaderLabel
            // 
            this.percentCompleteHeaderLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.percentCompleteHeaderLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.percentCompleteHeaderLabel.Name = "percentCompleteHeaderLabel";
            resources.ApplyResources(this.percentCompleteHeaderLabel, "percentCompleteHeaderLabel");
            // 
            // percentCompleteLabel
            // 
            resources.ApplyResources(this.percentCompleteLabel, "percentCompleteLabel");
            this.percentCompleteLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.percentCompleteLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.percentCompleteLabel.Name = "percentCompleteLabel";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Step = 1;
            // 
            // workingAreaPanel
            // 
            this.workingAreaPanel.Controls.Add(this.tabContainer);
            resources.ApplyResources(this.workingAreaPanel, "workingAreaPanel");
            this.workingAreaPanel.Name = "workingAreaPanel";
            // 
            // tabContainer
            // 
            this.tabContainer.Controls.Add(this.originalMapTabPage);
            this.tabContainer.Controls.Add(this.processedMapTabPage);
            resources.ApplyResources(this.tabContainer, "tabContainer");
            this.tabContainer.ImageList = this.tabImageList;
            this.tabContainer.Name = "tabContainer";
            this.tabContainer.SelectedIndex = 0;
            // 
            // originalMapTabPage
            // 
            resources.ApplyResources(this.originalMapTabPage, "originalMapTabPage");
            this.originalMapTabPage.Name = "originalMapTabPage";
            this.originalMapTabPage.UseVisualStyleBackColor = true;
            // 
            // processedMapTabPage
            // 
            resources.ApplyResources(this.processedMapTabPage, "processedMapTabPage");
            this.processedMapTabPage.Controls.Add(this.splitContainer);
            this.processedMapTabPage.Name = "processedMapTabPage";
            this.processedMapTabPage.UseVisualStyleBackColor = true;
            // 
            // tabImageList
            // 
            this.tabImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tabImageList.ImageStream")));
            this.tabImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.tabImageList.Images.SetKeyName(0, "MiniRuler_Image.png");
            this.tabImageList.Images.SetKeyName(1, "Minimap_Image.png");
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.workingAreaPanel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.buttonsPanel);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.buttonsPanel.ResumeLayout(false);
            this.buttonsPanel.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.workingAreaPanel.ResumeLayout(false);
            this.tabContainer.ResumeLayout(false);
            this.processedMapTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Panel workingAreaPanel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.ToolStripButton exportToCivMap;
        private System.Windows.Forms.TabControl tabContainer;
        private System.Windows.Forms.TabPage originalMapTabPage;
        private System.Windows.Forms.TabPage processedMapTabPage;
        private System.Windows.Forms.ToolStripStatusLabel selectedPlotLabel;
        private System.Windows.Forms.ToolStripStatusLabel MapSizeLabel;
        private System.Windows.Forms.ToolStripStatusLabel colorCountLabel;
        private System.Windows.Forms.ToolStripStatusLabel percentCompleteLabel;
        private System.Windows.Forms.ToolStripButton newModelButton;
        private System.Windows.Forms.ToolStripButton loadMapButton;
        private System.Windows.Forms.ToolStripButton aboutButton;
        private System.Windows.Forms.ToolStripStatusLabel plotCoordinatesLabel;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ToolStripButton settingsButton;
        private System.Windows.Forms.ToolStripButton saveAsButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton helpButton;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem newStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToCivStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsMenu;
        private System.Windows.Forms.ToolStripMenuItem settingsStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem helpStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ImageList tabImageList;
        private System.Windows.Forms.ToolStripStatusLabel civVersionLabel;
        private System.Windows.Forms.ToolStripButton zoomInButton;
        private System.Windows.Forms.ToolStripButton zoomOutButton;
        private System.Windows.Forms.ToolStripButton zoomDefaultButton;
        private System.Windows.Forms.ToolStripStatusLabel plotHeaderLabel;
        private System.Windows.Forms.ToolStripStatusLabel coordinatesHeaderLabel;
        private System.Windows.Forms.ToolStripStatusLabel civilizationVersionHeaderLabel;
        private System.Windows.Forms.ToolStripStatusLabel mapSizeHeaderLabel;
        private System.Windows.Forms.ToolStripStatusLabel colorsDetectedHeaderLabel;
        private System.Windows.Forms.ToolStripStatusLabel percentCompleteHeaderLabel;
    }
}

