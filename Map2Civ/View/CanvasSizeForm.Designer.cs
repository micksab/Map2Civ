using System.CodeDom.Compiler;

namespace Map2CivilizationView
{
    partial class CanvasSizeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CanvasSizeForm));
            this.widthLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.widthNumeric = new System.Windows.Forms.NumericUpDown();
            this.heightNumeric = new System.Windows.Forms.NumericUpDown();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.nearestRadio = new System.Windows.Forms.RadioButton();
            this.customRadio = new System.Windows.Forms.RadioButton();
            this.sizeGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.colorButton = new System.Windows.Forms.Button();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.widthNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumeric)).BeginInit();
            this.sizeGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // widthLabel
            // 
            resources.ApplyResources(this.widthLabel, "widthLabel");
            this.widthLabel.Name = "widthLabel";
            // 
            // heightLabel
            // 
            resources.ApplyResources(this.heightLabel, "heightLabel");
            this.heightLabel.Name = "heightLabel";
            // 
            // widthNumeric
            // 
            resources.ApplyResources(this.widthNumeric, "widthNumeric");
            this.widthNumeric.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.widthNumeric.Name = "widthNumeric";
            // 
            // heightNumeric
            // 
            resources.ApplyResources(this.heightNumeric, "heightNumeric");
            this.heightNumeric.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.heightNumeric.Name = "heightNumeric";
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
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // nearestRadio
            // 
            resources.ApplyResources(this.nearestRadio, "nearestRadio");
            this.nearestRadio.Checked = true;
            this.nearestRadio.Name = "nearestRadio";
            this.nearestRadio.TabStop = true;
            this.nearestRadio.UseVisualStyleBackColor = true;
            this.nearestRadio.CheckedChanged += new System.EventHandler(this.radioCheckedChanged);
            // 
            // customRadio
            // 
            resources.ApplyResources(this.customRadio, "customRadio");
            this.customRadio.Name = "customRadio";
            this.customRadio.UseVisualStyleBackColor = true;
            this.customRadio.CheckedChanged += new System.EventHandler(this.radioCheckedChanged);
            // 
            // sizeGroupBox
            // 
            this.sizeGroupBox.Controls.Add(this.widthNumeric);
            this.sizeGroupBox.Controls.Add(this.widthLabel);
            this.sizeGroupBox.Controls.Add(this.heightNumeric);
            this.sizeGroupBox.Controls.Add(this.heightLabel);
            resources.ApplyResources(this.sizeGroupBox, "sizeGroupBox");
            this.sizeGroupBox.Name = "sizeGroupBox";
            this.sizeGroupBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.colorButton);
            this.groupBox1.Controls.Add(this.colorPanel);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // colorButton
            // 
            resources.ApplyResources(this.colorButton, "colorButton");
            this.colorButton.Name = "colorButton";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // colorPanel
            // 
            this.colorPanel.BackColor = System.Drawing.Color.Blue;
            this.colorPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.colorPanel, "colorPanel");
            this.colorPanel.Name = "colorPanel";
            // 
            // colorDialog
            // 
            this.colorDialog.Color = System.Drawing.Color.Blue;
            // 
            // CanvasSizeForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sizeGroupBox);
            this.Controls.Add(this.customRadio);
            this.Controls.Add(this.nearestRadio);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "CanvasSizeForm";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.widthNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumeric)).EndInit();
            this.sizeGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

         System.Windows.Forms.Label widthLabel;
         System.Windows.Forms.Label heightLabel;
         System.Windows.Forms.NumericUpDown widthNumeric;
         System.Windows.Forms.NumericUpDown heightNumeric;
         System.Windows.Forms.Button okButton;
         System.Windows.Forms.Button cancelButton;
         System.Windows.Forms.RadioButton nearestRadio;
         System.Windows.Forms.RadioButton customRadio;
         System.Windows.Forms.GroupBox sizeGroupBox;
         System.Windows.Forms.GroupBox groupBox1;
         System.Windows.Forms.Button colorButton;
         System.Windows.Forms.Panel colorPanel;
         System.Windows.Forms.ColorDialog colorDialog;
    }
}