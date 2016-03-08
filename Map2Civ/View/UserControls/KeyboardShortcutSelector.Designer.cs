namespace Map2CivilizationView.UserControls
{
    partial class KeyboardShortcutSelector
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyboardShortcutSelector));
            this.newShortcutButton = new System.Windows.Forms.Button();
            this.shortcutBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // newShortcutButton
            // 
            resources.ApplyResources(this.newShortcutButton, "newShortcutButton");
            this.newShortcutButton.Name = "newShortcutButton";
            this.newShortcutButton.UseVisualStyleBackColor = true;
            this.newShortcutButton.Click += new System.EventHandler(this.newShortcutButton_Click);
            // 
            // shortcutBox
            // 
            this.shortcutBox.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.shortcutBox, "shortcutBox");
            this.shortcutBox.Name = "shortcutBox";
            this.shortcutBox.ReadOnly = true;
            // 
            // KeyboardShortcutSelector
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.shortcutBox);
            this.Controls.Add(this.newShortcutButton);
            this.Name = "KeyboardShortcutSelector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button newShortcutButton;
        private System.Windows.Forms.TextBox shortcutBox;
    }
}
