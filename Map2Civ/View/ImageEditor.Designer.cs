using System.CodeDom.Compiler;

namespace Map2CivilizationView
{
    partial class ImageEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
         System.ComponentModel.IContainer components = null;

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
         void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageEditor));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.resizeButton = new System.Windows.Forms.ToolStripButton();
            this.cancelButton = new System.Windows.Forms.ToolStripButton();
            this.okButton = new System.Windows.Forms.ToolStripButton();
            this.selectAreaOnButton = new System.Windows.Forms.ToolStripButton();
            this.selectAreaOffButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.intentedRatioLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageWidthLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageHeightLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.slidersPanel = new System.Windows.Forms.TableLayoutPanel();
            this.wNumeric = new System.Windows.Forms.NumericUpDown();
            this.wTrackBar = new System.Windows.Forms.TrackBar();
            this.wLabel = new System.Windows.Forms.Label();
            this.yNumeric = new System.Windows.Forms.NumericUpDown();
            this.yTrackBar = new System.Windows.Forms.TrackBar();
            this.yLabel = new System.Windows.Forms.Label();
            this.xLabel = new System.Windows.Forms.Label();
            this.xTrackBar = new System.Windows.Forms.TrackBar();
            this.xNumeric = new System.Windows.Forms.NumericUpDown();
            this.imagePanel = new System.Windows.Forms.Panel();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.slidersPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resizeButton,
            this.cancelButton,
            this.okButton,
            this.selectAreaOnButton,
            this.selectAreaOffButton});
            this.toolStrip.Name = "toolStrip";
            // 
            // resizeButton
            // 
            resources.ApplyResources(this.resizeButton, "resizeButton");
            this.resizeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.resizeButton.Image = global::Map2Civilization.Properties.Resources.CanvasResize_Image;
            this.resizeButton.Name = "resizeButton";
            this.resizeButton.Click += new System.EventHandler(this.ResizeButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cancelButton.Image = global::Map2Civilization.Properties.Resources.Cancel_Image;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.okButton.Image = global::Map2Civilization.Properties.Resources.OK_Image;
            this.okButton.Name = "okButton";
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // selectAreaOnButton
            // 
            resources.ApplyResources(this.selectAreaOnButton, "selectAreaOnButton");
            this.selectAreaOnButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.selectAreaOnButton.Image = global::Map2Civilization.Properties.Resources.Select_Image;
            this.selectAreaOnButton.Name = "selectAreaOnButton";
            this.selectAreaOnButton.Click += new System.EventHandler(this.SelectAreaButton_Click);
            // 
            // selectAreaOffButton
            // 
            resources.ApplyResources(this.selectAreaOffButton, "selectAreaOffButton");
            this.selectAreaOffButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.selectAreaOffButton.Image = global::Map2Civilization.Properties.Resources.SelectOff_Image;
            this.selectAreaOffButton.Name = "selectAreaOffButton";
            this.selectAreaOffButton.Click += new System.EventHandler(this.SelectAreaButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.intentedRatioLabel,
            this.imageWidthLabel,
            this.imageHeightLabel});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // intentedRatioLabel
            // 
            this.intentedRatioLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.intentedRatioLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.intentedRatioLabel.Name = "intentedRatioLabel";
            resources.ApplyResources(this.intentedRatioLabel, "intentedRatioLabel");
            // 
            // imageWidthLabel
            // 
            this.imageWidthLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.imageWidthLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.imageWidthLabel.Name = "imageWidthLabel";
            resources.ApplyResources(this.imageWidthLabel, "imageWidthLabel");
            // 
            // imageHeightLabel
            // 
            this.imageHeightLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.imageHeightLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.imageHeightLabel.Name = "imageHeightLabel";
            resources.ApplyResources(this.imageHeightLabel, "imageHeightLabel");
            // 
            // slidersPanel
            // 
            resources.ApplyResources(this.slidersPanel, "slidersPanel");
            this.slidersPanel.Controls.Add(this.wNumeric, 2, 2);
            this.slidersPanel.Controls.Add(this.wTrackBar, 1, 2);
            this.slidersPanel.Controls.Add(this.wLabel, 0, 2);
            this.slidersPanel.Controls.Add(this.yNumeric, 2, 1);
            this.slidersPanel.Controls.Add(this.yTrackBar, 1, 1);
            this.slidersPanel.Controls.Add(this.yLabel, 0, 1);
            this.slidersPanel.Controls.Add(this.xLabel, 0, 0);
            this.slidersPanel.Controls.Add(this.xTrackBar, 1, 0);
            this.slidersPanel.Controls.Add(this.xNumeric, 2, 0);
            this.slidersPanel.Name = "slidersPanel";
            // 
            // wNumeric
            // 
            resources.ApplyResources(this.wNumeric, "wNumeric");
            this.wNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.wNumeric.Name = "wNumeric";
            this.wNumeric.ReadOnly = true;
            this.wNumeric.TabStop = false;
            this.wNumeric.ValueChanged += new System.EventHandler(this.WValueChanged);
            // 
            // wTrackBar
            // 
            resources.ApplyResources(this.wTrackBar, "wTrackBar");
            this.wTrackBar.LargeChange = 10;
            this.wTrackBar.Maximum = 1000;
            this.wTrackBar.Name = "wTrackBar";
            this.wTrackBar.TabStop = false;
            this.wTrackBar.ValueChanged += new System.EventHandler(this.WValueChanged);
            // 
            // wLabel
            // 
            resources.ApplyResources(this.wLabel, "wLabel");
            this.wLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.wLabel.Name = "wLabel";
            // 
            // yNumeric
            // 
            resources.ApplyResources(this.yNumeric, "yNumeric");
            this.yNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.yNumeric.Name = "yNumeric";
            this.yNumeric.ReadOnly = true;
            this.yNumeric.TabStop = false;
            this.yNumeric.ValueChanged += new System.EventHandler(this.YValueChanged);
            // 
            // yTrackBar
            // 
            resources.ApplyResources(this.yTrackBar, "yTrackBar");
            this.yTrackBar.LargeChange = 10;
            this.yTrackBar.Maximum = 1000;
            this.yTrackBar.Name = "yTrackBar";
            this.yTrackBar.TabStop = false;
            this.yTrackBar.ValueChanged += new System.EventHandler(this.YValueChanged);
            // 
            // yLabel
            // 
            resources.ApplyResources(this.yLabel, "yLabel");
            this.yLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.yLabel.Name = "yLabel";
            // 
            // xLabel
            // 
            resources.ApplyResources(this.xLabel, "xLabel");
            this.xLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.xLabel.Name = "xLabel";
            // 
            // xTrackBar
            // 
            resources.ApplyResources(this.xTrackBar, "xTrackBar");
            this.xTrackBar.LargeChange = 10;
            this.xTrackBar.Maximum = 1000;
            this.xTrackBar.Name = "xTrackBar";
            this.xTrackBar.TabStop = false;
            this.xTrackBar.ValueChanged += new System.EventHandler(this.XValueChanged);
            // 
            // xNumeric
            // 
            resources.ApplyResources(this.xNumeric, "xNumeric");
            this.xNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.xNumeric.Name = "xNumeric";
            this.xNumeric.ReadOnly = true;
            this.xNumeric.TabStop = false;
            this.xNumeric.ValueChanged += new System.EventHandler(this.XValueChanged);
            // 
            // imagePanel
            // 
            this.imagePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.imagePanel, "imagePanel");
            this.imagePanel.Name = "imagePanel";
            // 
            // ImageEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.imagePanel);
            this.Controls.Add(this.slidersPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Name = "ImageEditor";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ImageEditor_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.slidersPanel.ResumeLayout(false);
            this.slidersPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

         System.Windows.Forms.ToolStrip toolStrip;
         System.Windows.Forms.ToolStripButton resizeButton;
         System.Windows.Forms.ToolStripButton cancelButton;
         System.Windows.Forms.ToolStripButton okButton;
         System.Windows.Forms.StatusStrip statusStrip;
         System.Windows.Forms.ToolStripStatusLabel intentedRatioLabel;
         System.Windows.Forms.ToolStripStatusLabel imageWidthLabel;
         System.Windows.Forms.ToolStripStatusLabel imageHeightLabel;
         System.Windows.Forms.ToolStripButton selectAreaOnButton;
         System.Windows.Forms.ToolStripButton selectAreaOffButton;
         System.Windows.Forms.TableLayoutPanel slidersPanel;
         System.Windows.Forms.Panel imagePanel;
         System.Windows.Forms.NumericUpDown wNumeric;
         System.Windows.Forms.TrackBar wTrackBar;
         System.Windows.Forms.Label wLabel;
         System.Windows.Forms.NumericUpDown yNumeric;
         System.Windows.Forms.TrackBar yTrackBar;
         System.Windows.Forms.Label yLabel;
         System.Windows.Forms.Label xLabel;
         System.Windows.Forms.TrackBar xTrackBar;
         System.Windows.Forms.NumericUpDown xNumeric;
    }
}