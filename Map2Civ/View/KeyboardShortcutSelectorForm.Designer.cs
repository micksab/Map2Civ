namespace Map2CivilizationView
{
    partial class KeyboardShortcutSelectorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyboardShortcutSelectorForm));
            this.controlBox = new System.Windows.Forms.CheckBox();
            this.shiftBox = new System.Windows.Forms.CheckBox();
            this.altBox = new System.Windows.Forms.CheckBox();
            this.modifiersLabel = new System.Windows.Forms.Label();
            this.keyLabel = new System.Windows.Forms.Label();
            this.keysCombo = new System.Windows.Forms.ComboBox();
            this.buttonsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlBox
            // 
            resources.ApplyResources(this.controlBox, "controlBox");
            this.controlBox.Name = "controlBox";
            this.controlBox.UseVisualStyleBackColor = true;
            this.controlBox.CheckedChanged += new System.EventHandler(this.controlBox_CheckedChanged);
            this.controlBox.Validating += new System.ComponentModel.CancelEventHandler(this.controlBox_Validating);
            // 
            // shiftBox
            // 
            resources.ApplyResources(this.shiftBox, "shiftBox");
            this.shiftBox.Name = "shiftBox";
            this.shiftBox.UseVisualStyleBackColor = true;
            this.shiftBox.CheckedChanged += new System.EventHandler(this.controlBox_CheckedChanged);
            this.shiftBox.Validating += new System.ComponentModel.CancelEventHandler(this.controlBox_Validating);
            // 
            // altBox
            // 
            resources.ApplyResources(this.altBox, "altBox");
            this.altBox.Name = "altBox";
            this.altBox.UseVisualStyleBackColor = true;
            this.altBox.CheckedChanged += new System.EventHandler(this.controlBox_CheckedChanged);
            this.altBox.Validating += new System.ComponentModel.CancelEventHandler(this.controlBox_Validating);
            // 
            // modifiersLabel
            // 
            resources.ApplyResources(this.modifiersLabel, "modifiersLabel");
            this.modifiersLabel.Name = "modifiersLabel";
            // 
            // keyLabel
            // 
            resources.ApplyResources(this.keyLabel, "keyLabel");
            this.keyLabel.Name = "keyLabel";
            // 
            // keysCombo
            // 
            this.keysCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.keysCombo.FormattingEnabled = true;
            resources.ApplyResources(this.keysCombo, "keysCombo");
            this.keysCombo.Name = "keysCombo";
            this.keysCombo.SelectedIndexChanged += new System.EventHandler(this.keysCombo_SelectedIndexChanged);
            // 
            // buttonsPanel
            // 
            resources.ApplyResources(this.buttonsPanel, "buttonsPanel");
            this.buttonsPanel.Controls.Add(this.cancelButton, 3, 0);
            this.buttonsPanel.Controls.Add(this.okButton, 1, 0);
            this.buttonsPanel.Name = "buttonsPanel";
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // KeyboardShortcutSelectorForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonsPanel);
            this.Controls.Add(this.keysCombo);
            this.Controls.Add(this.keyLabel);
            this.Controls.Add(this.modifiersLabel);
            this.Controls.Add(this.altBox);
            this.Controls.Add(this.shiftBox);
            this.Controls.Add(this.controlBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KeyboardShortcutSelectorForm";
            this.buttonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox controlBox;
        private System.Windows.Forms.CheckBox shiftBox;
        private System.Windows.Forms.CheckBox altBox;
        private System.Windows.Forms.Label modifiersLabel;
        private System.Windows.Forms.Label keyLabel;
        private System.Windows.Forms.ComboBox keysCombo;
        private System.Windows.Forms.TableLayoutPanel buttonsPanel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
    }
}