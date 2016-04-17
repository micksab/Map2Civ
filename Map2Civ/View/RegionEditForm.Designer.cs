using System.CodeDom.Compiler;

namespace Map2CivilizationView
{
    partial class RegionEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegionEditForm));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.plotTitleLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.plotValueLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            resources.ApplyResources(this.splitContainer.Panel1, "splitContainer.Panel1");
            this.splitContainer.Panel1.Resize += new System.EventHandler(this.SplitPanelsSizeChanged);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            resources.ApplyResources(this.splitContainer.Panel2, "splitContainer.Panel2");
            this.splitContainer.Panel2.Resize += new System.EventHandler(this.SplitPanelsSizeChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plotTitleLabel,
            this.plotValueLabel});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // plotTitleLabel
            // 
            this.plotTitleLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.plotTitleLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.plotTitleLabel.Name = "plotTitleLabel";
            resources.ApplyResources(this.plotTitleLabel, "plotTitleLabel");
            // 
            // plotValueLabel
            // 
            this.plotValueLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.plotValueLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.plotValueLabel.Margin = new System.Windows.Forms.Padding(-1, 3, 0, 2);
            this.plotValueLabel.Name = "plotValueLabel";
            resources.ApplyResources(this.plotValueLabel, "plotValueLabel");
            // 
            // RegionEditForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip);
            this.Name = "RegionEditForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegionEditForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
         System.Windows.Forms.StatusStrip statusStrip;
         System.Windows.Forms.ToolStripStatusLabel plotTitleLabel;
         System.Windows.Forms.ToolStripStatusLabel plotValueLabel;
         System.Windows.Forms.SplitContainer splitContainer;
    }
}