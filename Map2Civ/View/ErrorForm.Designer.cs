using System.CodeDom.Compiler;

namespace Map2CivilizationView
{
    partial class ErrorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorForm));
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.closeButton = new System.Windows.Forms.Button();
            this.descriptionPanel = new System.Windows.Forms.Panel();
            this.messagePanel = new System.Windows.Forms.Panel();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.iconPanel = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.ExceptionInfoPanel = new System.Windows.Forms.Panel();
            this.exceptionBox = new System.Windows.Forms.TextBox();
            this.buttonPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.descriptionPanel.SuspendLayout();
            this.messagePanel.SuspendLayout();
            this.iconPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.ExceptionInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.buttonPanel, "buttonPanel");
            this.buttonPanel.Name = "buttonPanel";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.closeButton, 1, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // closeButton
            // 
            resources.ApplyResources(this.closeButton, "closeButton");
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Name = "closeButton";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // descriptionPanel
            // 
            this.descriptionPanel.Controls.Add(this.messagePanel);
            this.descriptionPanel.Controls.Add(this.iconPanel);
            resources.ApplyResources(this.descriptionPanel, "descriptionPanel");
            this.descriptionPanel.Name = "descriptionPanel";
            // 
            // messagePanel
            // 
            this.messagePanel.Controls.Add(this.messageBox);
            resources.ApplyResources(this.messagePanel, "messagePanel");
            this.messagePanel.Name = "messagePanel";
            // 
            // messageBox
            // 
            this.messageBox.BackColor = System.Drawing.SystemColors.Control;
            this.messageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.messageBox, "messageBox");
            this.messageBox.ForeColor = System.Drawing.Color.Maroon;
            this.messageBox.Name = "messageBox";
            this.messageBox.TabStop = false;
            this.messageBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.messageBox_KeyPress);
            // 
            // iconPanel
            // 
            this.iconPanel.Controls.Add(this.pictureBox);
            resources.ApplyResources(this.iconPanel, "iconPanel");
            this.iconPanel.Name = "iconPanel";
            // 
            // pictureBox
            // 
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.Image = global::Map2Civilization.Properties.Resources.BugLarge_Image;
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            // 
            // ExceptionInfoPanel
            // 
            this.ExceptionInfoPanel.Controls.Add(this.exceptionBox);
            resources.ApplyResources(this.ExceptionInfoPanel, "ExceptionInfoPanel");
            this.ExceptionInfoPanel.Name = "ExceptionInfoPanel";
            // 
            // exceptionBox
            // 
            resources.ApplyResources(this.exceptionBox, "exceptionBox");
            this.exceptionBox.Name = "exceptionBox";
            this.exceptionBox.ReadOnly = true;
            // 
            // ErrorForm
            // 
            this.AcceptButton = this.closeButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ControlBox = false;
            this.Controls.Add(this.ExceptionInfoPanel);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.descriptionPanel);
            this.Name = "ErrorForm";
            this.TopMost = true;
            this.buttonPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.descriptionPanel.ResumeLayout(false);
            this.messagePanel.ResumeLayout(false);
            this.messagePanel.PerformLayout();
            this.iconPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ExceptionInfoPanel.ResumeLayout(false);
            this.ExceptionInfoPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
         System.Windows.Forms.Panel buttonPanel;
         System.Windows.Forms.Button closeButton;
         System.Windows.Forms.Panel descriptionPanel;
         System.Windows.Forms.Panel ExceptionInfoPanel;
         System.Windows.Forms.TextBox exceptionBox;
         System.Windows.Forms.Panel messagePanel;
         System.Windows.Forms.Panel iconPanel;
         System.Windows.Forms.PictureBox pictureBox;
         System.Windows.Forms.TextBox messageBox;
         System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}