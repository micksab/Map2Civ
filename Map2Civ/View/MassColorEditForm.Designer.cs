using System.CodeDom.Compiler;

namespace Map2CivilizationView
{
    partial class MassColorEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MassColorEditForm));
            this.terrainsCombo = new System.Windows.Forms.ComboBox();
            this.colorsLabel = new System.Windows.Forms.Label();
            this.colorsTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // terrainsCombo
            // 
            this.terrainsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.terrainsCombo.FormattingEnabled = true;
            resources.ApplyResources(this.terrainsCombo, "terrainsCombo");
            this.terrainsCombo.Name = "terrainsCombo";
            // 
            // colorsLabel
            // 
            resources.ApplyResources(this.colorsLabel, "colorsLabel");
            this.colorsLabel.Name = "colorsLabel";
            // 
            // colorsTextBox
            // 
            resources.ApplyResources(this.colorsTextBox, "colorsTextBox");
            this.colorsTextBox.Name = "colorsTextBox";
            this.colorsTextBox.ReadOnly = true;
            this.colorsTextBox.ShortcutsEnabled = false;
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // MassColorEditForm
            // 
            this.AcceptButton = this.okButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.colorsTextBox);
            this.Controls.Add(this.colorsLabel);
            this.Controls.Add(this.terrainsCombo);
            this.Name = "MassColorEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
         System.Windows.Forms.ComboBox terrainsCombo;
         System.Windows.Forms.Label colorsLabel;
         System.Windows.Forms.TextBox colorsTextBox;
         System.Windows.Forms.Button okButton;
         System.Windows.Forms.Button cancelButton;
    }
}