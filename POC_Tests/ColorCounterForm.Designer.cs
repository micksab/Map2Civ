namespace POC_Tests
{
    partial class ColorCounterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
         System.ComponentModel.IContainer components = null;

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
         void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.fileBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.colorsDetectedLabel = new System.Windows.Forms.Label();
            this.loadButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(27, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(571, 327);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // fileBox
            // 
            this.fileBox.Location = new System.Drawing.Point(76, 355);
            this.fileBox.Name = "fileBox";
            this.fileBox.Size = new System.Drawing.Size(493, 20);
            this.fileBox.TabIndex = 1;
            this.fileBox.TextChanged += new System.EventHandler(this.fileBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 358);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Image File";
            // 
            // colorsDetectedLabel
            // 
            this.colorsDetectedLabel.AutoSize = true;
            this.colorsDetectedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorsDetectedLabel.Location = new System.Drawing.Point(72, 403);
            this.colorsDetectedLabel.Name = "colorsDetectedLabel";
            this.colorsDetectedLabel.Size = new System.Drawing.Size(144, 20);
            this.colorsDetectedLabel.TabIndex = 3;
            this.colorsDetectedLabel.Text = "Colors Detected:";
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(494, 381);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 4;
            this.loadButton.Text = "Load Image";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // ColorCounterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 465);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.colorsDetectedLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileBox);
            this.Controls.Add(this.pictureBox);
            this.Name = "ColorCounterForm";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

         System.Windows.Forms.PictureBox pictureBox;
         System.Windows.Forms.TextBox fileBox;
         System.Windows.Forms.Label label1;
         System.Windows.Forms.Label colorsDetectedLabel;
         System.Windows.Forms.Button loadButton;
    }
}