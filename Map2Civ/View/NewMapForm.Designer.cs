using System.CodeDom.Compiler;


namespace Map2CivilizationView
{
    
    partial class NewMapForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewMapForm));
            this.progressPanel = new System.Windows.Forms.Panel();
            this.progressLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.labelPanel = new System.Windows.Forms.Panel();
            this.messageLabel = new System.Windows.Forms.Label();
            this.standardOptionsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.mapSizeLabel = new System.Windows.Forms.Label();
            this.dataSourceLabel = new System.Windows.Forms.Label();
            this.gridTypeLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.gridTypeBox = new System.Windows.Forms.TextBox();
            this.mapSizeComboBox = new System.Windows.Forms.ComboBox();
            this.extraOptionsPanel = new System.Windows.Forms.Panel();
            this.versionCustomEnumComboBox = new Map2CivilizationView.UserControls.CustomEnumComboBox();
            this.dataSourceCustomEnumComboBox = new Map2CivilizationView.UserControls.CustomEnumComboBox();
            this.progressPanel.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            this.labelPanel.SuspendLayout();
            this.standardOptionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressPanel
            // 
            this.progressPanel.Controls.Add(this.progressLabel);
            this.progressPanel.Controls.Add(this.progressBar);
            resources.ApplyResources(this.progressPanel, "progressPanel");
            this.progressPanel.Name = "progressPanel";
            // 
            // progressLabel
            // 
            resources.ApplyResources(this.progressLabel, "progressLabel");
            this.progressLabel.Name = "progressLabel";
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // buttonsPanel
            // 
            resources.ApplyResources(this.buttonsPanel, "buttonsPanel");
            this.buttonsPanel.Controls.Add(this.cancelButton, 3, 0);
            this.buttonsPanel.Controls.Add(this.createButton, 1, 0);
            this.buttonsPanel.Name = "buttonsPanel";
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // createButton
            // 
            resources.ApplyResources(this.createButton, "createButton");
            this.createButton.Name = "createButton";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // labelPanel
            // 
            this.labelPanel.Controls.Add(this.messageLabel);
            resources.ApplyResources(this.labelPanel, "labelPanel");
            this.labelPanel.Name = "labelPanel";
            // 
            // messageLabel
            // 
            resources.ApplyResources(this.messageLabel, "messageLabel");
            this.messageLabel.Name = "messageLabel";
            // 
            // standardOptionsPanel
            // 
            resources.ApplyResources(this.standardOptionsPanel, "standardOptionsPanel");
            this.standardOptionsPanel.Controls.Add(this.mapSizeLabel, 0, 3);
            this.standardOptionsPanel.Controls.Add(this.dataSourceLabel, 0, 2);
            this.standardOptionsPanel.Controls.Add(this.gridTypeLabel, 0, 1);
            this.standardOptionsPanel.Controls.Add(this.versionCustomEnumComboBox, 1, 0);
            this.standardOptionsPanel.Controls.Add(this.dataSourceCustomEnumComboBox, 1, 2);
            this.standardOptionsPanel.Controls.Add(this.versionLabel, 0, 0);
            this.standardOptionsPanel.Controls.Add(this.gridTypeBox, 1, 1);
            this.standardOptionsPanel.Controls.Add(this.mapSizeComboBox, 1, 3);
            this.standardOptionsPanel.Name = "standardOptionsPanel";
            // 
            // mapSizeLabel
            // 
            resources.ApplyResources(this.mapSizeLabel, "mapSizeLabel");
            this.mapSizeLabel.Name = "mapSizeLabel";
            // 
            // dataSourceLabel
            // 
            resources.ApplyResources(this.dataSourceLabel, "dataSourceLabel");
            this.dataSourceLabel.Name = "dataSourceLabel";
            // 
            // gridTypeLabel
            // 
            resources.ApplyResources(this.gridTypeLabel, "gridTypeLabel");
            this.gridTypeLabel.Name = "gridTypeLabel";
            // 
            // versionLabel
            // 
            resources.ApplyResources(this.versionLabel, "versionLabel");
            this.versionLabel.Name = "versionLabel";
            // 
            // gridTypeBox
            // 
            this.gridTypeBox.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.gridTypeBox, "gridTypeBox");
            this.gridTypeBox.Name = "gridTypeBox";
            this.gridTypeBox.ReadOnly = true;
            // 
            // mapSizeComboBox
            // 
            this.mapSizeComboBox.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.mapSizeComboBox, "mapSizeComboBox");
            this.mapSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapSizeComboBox.FormattingEnabled = true;
            this.mapSizeComboBox.Name = "mapSizeComboBox";
            this.mapSizeComboBox.SelectedValueChanged += new System.EventHandler(this.mapSizeComboBox_SelectedValueChanged);
            // 
            // extraOptionsPanel
            // 
            resources.ApplyResources(this.extraOptionsPanel, "extraOptionsPanel");
            this.extraOptionsPanel.BackgroundImage = global::Map2Civilization.Properties.Resources.Settings_Image;
            this.extraOptionsPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.extraOptionsPanel.Name = "extraOptionsPanel";
            // 
            // versionCustomEnumComboBox
            // 
            resources.ApplyResources(this.versionCustomEnumComboBox, "versionCustomEnumComboBox");
            this.versionCustomEnumComboBox.Name = "versionCustomEnumComboBox";
            // 
            // dataSourceCustomEnumComboBox
            // 
            resources.ApplyResources(this.dataSourceCustomEnumComboBox, "dataSourceCustomEnumComboBox");
            this.dataSourceCustomEnumComboBox.Name = "dataSourceCustomEnumComboBox";
            // 
            // NewMapForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.extraOptionsPanel);
            this.Controls.Add(this.standardOptionsPanel);
            this.Controls.Add(this.labelPanel);
            this.Controls.Add(this.buttonsPanel);
            this.Controls.Add(this.progressPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewMapForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NewMapForm_FormClosed);
            this.progressPanel.ResumeLayout(false);
            this.buttonsPanel.ResumeLayout(false);
            this.labelPanel.ResumeLayout(false);
            this.standardOptionsPanel.ResumeLayout(false);
            this.standardOptionsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel progressPanel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TableLayoutPanel buttonsPanel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Panel labelPanel;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.TableLayoutPanel standardOptionsPanel;
        private Map2CivilizationView.UserControls.CustomEnumComboBox versionCustomEnumComboBox;
        private Map2CivilizationView.UserControls.CustomEnumComboBox dataSourceCustomEnumComboBox;
        private System.Windows.Forms.Label mapSizeLabel;
        private System.Windows.Forms.Label dataSourceLabel;
        private System.Windows.Forms.Label gridTypeLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Panel extraOptionsPanel;
        private System.Windows.Forms.TextBox gridTypeBox;
        private System.Windows.Forms.ComboBox mapSizeComboBox;
        private System.Windows.Forms.Label progressLabel;
    }
}