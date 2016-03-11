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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.plotTitleLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.plotValueLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
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
            this.plotTitleLabel.Name = "plotTitleLabel";
            resources.ApplyResources(this.plotTitleLabel, "plotTitleLabel");
            // 
            // plotValueLabel
            // 
            this.plotValueLabel.Name = "plotValueLabel";
            resources.ApplyResources(this.plotValueLabel, "plotValueLabel");
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
            // RegionEditForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip);
            this.Name = "RegionEditForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegionEditForm_FormClosing);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
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