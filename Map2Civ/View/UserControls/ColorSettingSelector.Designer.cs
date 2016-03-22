namespace Map2CivilizationView.UserControls
{
    partial class ColorSettingSelector
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
         void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorSettingSelector));
            this.colorPanel = new System.Windows.Forms.Panel();
            this.colorButton = new System.Windows.Forms.Button();
            this.colorBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // colorPanel
            // 
            this.colorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.colorPanel, "colorPanel");
            this.colorPanel.Name = "colorPanel";
            // 
            // colorButton
            // 
            resources.ApplyResources(this.colorButton, "colorButton");
            this.colorButton.Name = "colorButton";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // colorBox
            // 
            this.colorBox.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.colorBox, "colorBox");
            this.colorBox.Name = "colorBox";
            this.colorBox.ReadOnly = true;
            // 
            // ColorSelector
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.colorBox);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.colorPanel);
            this.Name = "ColorSelector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

         System.Windows.Forms.Panel colorPanel;
         System.Windows.Forms.Button colorButton;
         System.Windows.Forms.TextBox colorBox;
    }
}
