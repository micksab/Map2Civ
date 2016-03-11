using System.CodeDom.Compiler;

namespace Map2CivilizationView.UserControls
{

    
    partial class SourceSettingsControlReliefMap
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
         System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "_mapBitmap")]
        [GeneratedCodeAttribute("Winform Designer GeneratedCode", "VS2015")]
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        [GeneratedCodeAttribute("Winform Designer GeneratedCode", "VS2015")]
         void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SourceSettingsControlReliefMap));
            this.imageLabel = new System.Windows.Forms.Label();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.advancedGroup = new System.Windows.Forms.GroupBox();
            this.smoothingModeBox = new System.Windows.Forms.ComboBox();
            this.smoothingLabel = new System.Windows.Forms.Label();
            this.composingQualityBox = new System.Windows.Forms.ComboBox();
            this.compositingLabel = new System.Windows.Forms.Label();
            this.interpolationBox = new System.Windows.Forms.ComboBox();
            this.interpolationLabel = new System.Windows.Forms.Label();
            this.defaultCheck = new System.Windows.Forms.CheckBox();
            this.colorDepthBox = new System.Windows.Forms.ComboBox();
            this.depthLabel = new System.Windows.Forms.Label();
            this.openFileButton = new System.Windows.Forms.Button();
            this.advancedGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageLabel
            // 
            resources.ApplyResources(this.imageLabel, "imageLabel");
            this.imageLabel.Name = "imageLabel";
            // 
            // pathBox
            // 
            resources.ApplyResources(this.pathBox, "pathBox");
            this.pathBox.Name = "pathBox";
            this.pathBox.ReadOnly = true;
            // 
            // advancedGroup
            // 
            this.advancedGroup.Controls.Add(this.smoothingModeBox);
            this.advancedGroup.Controls.Add(this.smoothingLabel);
            this.advancedGroup.Controls.Add(this.composingQualityBox);
            this.advancedGroup.Controls.Add(this.compositingLabel);
            this.advancedGroup.Controls.Add(this.interpolationBox);
            this.advancedGroup.Controls.Add(this.interpolationLabel);
            this.advancedGroup.Controls.Add(this.defaultCheck);
            this.advancedGroup.Controls.Add(this.colorDepthBox);
            this.advancedGroup.Controls.Add(this.depthLabel);
            resources.ApplyResources(this.advancedGroup, "advancedGroup");
            this.advancedGroup.Name = "advancedGroup";
            this.advancedGroup.TabStop = false;
            // 
            // smoothingModeBox
            // 
            this.smoothingModeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.smoothingModeBox, "smoothingModeBox");
            this.smoothingModeBox.FormattingEnabled = true;
            this.smoothingModeBox.Name = "smoothingModeBox";
            // 
            // smoothingLabel
            // 
            resources.ApplyResources(this.smoothingLabel, "smoothingLabel");
            this.smoothingLabel.Name = "smoothingLabel";
            // 
            // composingQualityBox
            // 
            this.composingQualityBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.composingQualityBox, "composingQualityBox");
            this.composingQualityBox.FormattingEnabled = true;
            this.composingQualityBox.Name = "composingQualityBox";
            // 
            // compositingLabel
            // 
            resources.ApplyResources(this.compositingLabel, "compositingLabel");
            this.compositingLabel.Name = "compositingLabel";
            // 
            // interpolationBox
            // 
            this.interpolationBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.interpolationBox, "interpolationBox");
            this.interpolationBox.FormattingEnabled = true;
            this.interpolationBox.Name = "interpolationBox";
            // 
            // interpolationLabel
            // 
            resources.ApplyResources(this.interpolationLabel, "interpolationLabel");
            this.interpolationLabel.Name = "interpolationLabel";
            // 
            // defaultCheck
            // 
            resources.ApplyResources(this.defaultCheck, "defaultCheck");
            this.defaultCheck.Checked = true;
            this.defaultCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.defaultCheck.Name = "defaultCheck";
            this.defaultCheck.UseVisualStyleBackColor = true;
            this.defaultCheck.CheckedChanged += new System.EventHandler(this.defaultCheck_CheckedChanged);
            // 
            // colorDepthBox
            // 
            this.colorDepthBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.colorDepthBox, "colorDepthBox");
            this.colorDepthBox.FormattingEnabled = true;
            this.colorDepthBox.Name = "colorDepthBox";
            // 
            // depthLabel
            // 
            resources.ApplyResources(this.depthLabel, "depthLabel");
            this.depthLabel.Name = "depthLabel";
            // 
            // openFileButton
            // 
            this.openFileButton.Image = global::Map2Civilization.Properties.Resources.Open_Image;
            resources.ApplyResources(this.openFileButton, "openFileButton");
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // SourceSettingsControlReliefMap
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.advancedGroup);
            this.Controls.Add(this.imageLabel);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.pathBox);
            this.Name = "SourceSettingsControlReliefMap";
            this.advancedGroup.ResumeLayout(false);
            this.advancedGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

         System.Windows.Forms.Label imageLabel;
         System.Windows.Forms.Button openFileButton;
         System.Windows.Forms.TextBox pathBox;
         System.Windows.Forms.GroupBox advancedGroup;
         System.Windows.Forms.ComboBox smoothingModeBox;
         System.Windows.Forms.Label smoothingLabel;
         System.Windows.Forms.ComboBox composingQualityBox;
         System.Windows.Forms.Label compositingLabel;
         System.Windows.Forms.ComboBox interpolationBox;
         System.Windows.Forms.Label interpolationLabel;
         System.Windows.Forms.CheckBox defaultCheck;
         System.Windows.Forms.ComboBox colorDepthBox;
         System.Windows.Forms.Label depthLabel;
    }
}
