namespace Map2CivilizationView
{
    partial class ImageProcessingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageProcessingForm));
            this.buttonsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.previewCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.blueLabel = new System.Windows.Forms.Label();
            this.greenLabel = new System.Windows.Forms.Label();
            this.redLabel = new System.Windows.Forms.Label();
            this.redTrackBar = new System.Windows.Forms.TrackBar();
            this.greenTrackBar = new System.Windows.Forms.TrackBar();
            this.blueTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.brightnessTrackBar = new System.Windows.Forms.TrackBar();
            this.contrastTrackBar = new System.Windows.Forms.TrackBar();
            this.contrastLabel = new System.Windows.Forms.Label();
            this.previewImageBox = new System.Windows.Forms.PictureBox();
            this.brightnessLabel = new System.Windows.Forms.Label();
            this.buttonsPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.redTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTrackBar)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.ColumnCount = 5;
            this.buttonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
            this.buttonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.buttonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.buttonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.buttonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.44445F));
            this.buttonsPanel.Controls.Add(this.okButton, 1, 0);
            this.buttonsPanel.Controls.Add(this.cancelButton, 3, 0);
            this.buttonsPanel.Controls.Add(this.previewCheckBox, 4, 0);
            this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonsPanel.Location = new System.Drawing.Point(0, 571);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.RowCount = 1;
            this.buttonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonsPanel.Size = new System.Drawing.Size(1135, 51);
            this.buttonsPanel.TabIndex = 0;
            // 
            // okButton
            // 
            this.okButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.okButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.okButton.Location = new System.Drawing.Point(391, 3);
            this.okButton.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(110, 45);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "Apply";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancelButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cancelButton.Location = new System.Drawing.Point(633, 3);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(110, 45);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // previewCheckBox
            // 
            this.previewCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.previewCheckBox.AutoSize = true;
            this.previewCheckBox.Checked = true;
            this.previewCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.previewCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.previewCheckBox.Location = new System.Drawing.Point(1023, 3);
            this.previewCheckBox.Name = "previewCheckBox";
            this.previewCheckBox.Size = new System.Drawing.Size(109, 17);
            this.previewCheckBox.TabIndex = 9;
            this.previewCheckBox.Text = "Preview Changes";
            this.previewCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 507);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1135, 64);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gamma Correction";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.blueLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.greenLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.redLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.redTrackBar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.greenTrackBar, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.blueTrackBar, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1129, 45);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // blueLabel
            // 
            this.blueLabel.AutoSize = true;
            this.blueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blueLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.blueLabel.Location = new System.Drawing.Point(3, 30);
            this.blueLabel.Name = "blueLabel";
            this.blueLabel.Size = new System.Drawing.Size(370, 15);
            this.blueLabel.TabIndex = 14;
            this.blueLabel.Text = "Blue";
            this.blueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // greenLabel
            // 
            this.greenLabel.AutoSize = true;
            this.greenLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.greenLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.greenLabel.Location = new System.Drawing.Point(379, 30);
            this.greenLabel.Name = "greenLabel";
            this.greenLabel.Size = new System.Drawing.Size(370, 15);
            this.greenLabel.TabIndex = 13;
            this.greenLabel.Text = "Green";
            this.greenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // redLabel
            // 
            this.redLabel.AutoSize = true;
            this.redLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.redLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.redLabel.Location = new System.Drawing.Point(755, 30);
            this.redLabel.Name = "redLabel";
            this.redLabel.Size = new System.Drawing.Size(371, 15);
            this.redLabel.TabIndex = 12;
            this.redLabel.Text = "Red";
            this.redLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // redTrackBar
            // 
            this.redTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.redTrackBar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.redTrackBar.Location = new System.Drawing.Point(3, 3);
            this.redTrackBar.Maximum = 50;
            this.redTrackBar.Minimum = 2;
            this.redTrackBar.Name = "redTrackBar";
            this.redTrackBar.Size = new System.Drawing.Size(370, 24);
            this.redTrackBar.TabIndex = 7;
            this.redTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.redTrackBar.Value = 24;
            this.redTrackBar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.trackBars_KeyUp);
            this.redTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBars_MouseUp);
            // 
            // greenTrackBar
            // 
            this.greenTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.greenTrackBar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.greenTrackBar.Location = new System.Drawing.Point(379, 3);
            this.greenTrackBar.Maximum = 50;
            this.greenTrackBar.Minimum = 2;
            this.greenTrackBar.Name = "greenTrackBar";
            this.greenTrackBar.Size = new System.Drawing.Size(370, 24);
            this.greenTrackBar.TabIndex = 9;
            this.greenTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.greenTrackBar.Value = 24;
            this.greenTrackBar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.trackBars_KeyUp);
            this.greenTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBars_MouseUp);
            // 
            // blueTrackBar
            // 
            this.blueTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blueTrackBar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.blueTrackBar.Location = new System.Drawing.Point(755, 3);
            this.blueTrackBar.Maximum = 50;
            this.blueTrackBar.Minimum = 2;
            this.blueTrackBar.Name = "blueTrackBar";
            this.blueTrackBar.Size = new System.Drawing.Size(371, 24);
            this.blueTrackBar.TabIndex = 11;
            this.blueTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.blueTrackBar.Value = 24;
            this.blueTrackBar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.trackBars_KeyUp);
            this.blueTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBars_MouseUp);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 443);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1135, 64);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Brightness/Contrast";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.brightnessLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.contrastLabel, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.brightnessTrackBar, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.contrastTrackBar, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1129, 45);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // brightnessTrackBar
            // 
            this.brightnessTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.brightnessTrackBar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.brightnessTrackBar.Location = new System.Drawing.Point(3, 3);
            this.brightnessTrackBar.Maximum = 255;
            this.brightnessTrackBar.Minimum = -255;
            this.brightnessTrackBar.Name = "brightnessTrackBar";
            this.brightnessTrackBar.Size = new System.Drawing.Size(558, 24);
            this.brightnessTrackBar.TabIndex = 1;
            this.brightnessTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.brightnessTrackBar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.trackBars_KeyUp);
            this.brightnessTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBars_MouseUp);
            // 
            // contrastTrackBar
            // 
            this.contrastTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contrastTrackBar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.contrastTrackBar.Location = new System.Drawing.Point(567, 3);
            this.contrastTrackBar.Maximum = 200;
            this.contrastTrackBar.Name = "contrastTrackBar";
            this.contrastTrackBar.Size = new System.Drawing.Size(559, 24);
            this.contrastTrackBar.TabIndex = 2;
            this.contrastTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.contrastTrackBar.Value = 100;
            this.contrastTrackBar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.trackBars_KeyUp);
            this.contrastTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBars_MouseUp);
            // 
            // contrastLabel
            // 
            this.contrastLabel.AutoSize = true;
            this.contrastLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contrastLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.contrastLabel.Location = new System.Drawing.Point(567, 30);
            this.contrastLabel.Name = "contrastLabel";
            this.contrastLabel.Size = new System.Drawing.Size(559, 15);
            this.contrastLabel.TabIndex = 6;
            this.contrastLabel.Text = "Contrast";
            this.contrastLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // previewImageBox
            // 
            this.previewImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewImageBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.previewImageBox.Location = new System.Drawing.Point(0, 0);
            this.previewImageBox.Name = "previewImageBox";
            this.previewImageBox.Size = new System.Drawing.Size(1135, 443);
            this.previewImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previewImageBox.TabIndex = 3;
            this.previewImageBox.TabStop = false;
            // 
            // brightnessLabel
            // 
            this.brightnessLabel.AutoSize = true;
            this.brightnessLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.brightnessLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.brightnessLabel.Location = new System.Drawing.Point(3, 30);
            this.brightnessLabel.Name = "brightnessLabel";
            this.brightnessLabel.Size = new System.Drawing.Size(558, 15);
            this.brightnessLabel.TabIndex = 7;
            this.brightnessLabel.Text = "Brightness";
            this.brightnessLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ImageProcessingForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(1135, 622);
            this.Controls.Add(this.previewImageBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonsPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImageProcessingForm";
            this.Text = "Image Processing Form";
            this.buttonsPanel.ResumeLayout(false);
            this.buttonsPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.redTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTrackBar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel buttonsPanel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TrackBar redTrackBar;
        private System.Windows.Forms.TrackBar greenTrackBar;
        private System.Windows.Forms.TrackBar blueTrackBar;
        private System.Windows.Forms.Label redLabel;
        private System.Windows.Forms.Label greenLabel;
        private System.Windows.Forms.Label blueLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TrackBar brightnessTrackBar;
        private System.Windows.Forms.TrackBar contrastTrackBar;
        private System.Windows.Forms.CheckBox previewCheckBox;
        private System.Windows.Forms.Label brightnessLabel;
        private System.Windows.Forms.Label contrastLabel;
        private System.Windows.Forms.PictureBox previewImageBox;
    }
}