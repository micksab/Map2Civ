using System.CodeDom.Compiler;

namespace Map2CivilizationView.UserControls
{
    partial class DetectedColorsGrid
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        [GeneratedCodeAttribute("Winform Designer GeneratedCode", "VS2015")]
         void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetectedColorsGrid));
            this.gridView = new System.Windows.Forms.DataGridView();
            this.colorDisplayColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.idColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.massAssignMenuEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.settingColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colorIsAssignedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridView
            // 
            this.gridView.AllowUserToAddRows = false;
            this.gridView.AllowUserToDeleteRows = false;
            this.gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colorDisplayColumn,
            this.idColumn,
            this.settingColumn,
            this.colorIsAssignedColumn});
            resources.ApplyResources(this.gridView, "gridView");
            this.gridView.Name = "gridView";
            this.gridView.RowHeadersVisible = false;
            this.gridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView_CellValueChanged);
            this.gridView.SelectionChanged += new System.EventHandler(this.gridView_SelectionChanged);
            // 
            // colorDisplayColumn
            // 
            this.colorDisplayColumn.FillWeight = 10F;
            resources.ApplyResources(this.colorDisplayColumn, "colorDisplayColumn");
            this.colorDisplayColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.colorDisplayColumn.Name = "colorDisplayColumn";
            this.colorDisplayColumn.ReadOnly = true;
            this.colorDisplayColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // idColumn
            // 
            this.idColumn.ContextMenuStrip = this.contextMenu;
            this.idColumn.FillWeight = 30F;
            resources.ApplyResources(this.idColumn, "idColumn");
            this.idColumn.Name = "idColumn";
            this.idColumn.ReadOnly = true;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.massAssignMenuEntry});
            this.contextMenu.Name = "contextMenu";
            resources.ApplyResources(this.contextMenu, "contextMenu");
            // 
            // massAssignMenuEntry
            // 
            this.massAssignMenuEntry.Image = global::Map2Civilization.Properties.Resources.Terrain_Image;
            this.massAssignMenuEntry.Name = "massAssignMenuEntry";
            resources.ApplyResources(this.massAssignMenuEntry, "massAssignMenuEntry");
            this.massAssignMenuEntry.Click += new System.EventHandler(this.massAssignMenuEntry_Click);
            // 
            // settingColumn
            // 
            this.settingColumn.FillWeight = 60F;
            resources.ApplyResources(this.settingColumn, "settingColumn");
            this.settingColumn.Name = "settingColumn";
            this.settingColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colorIsAssignedColumn
            // 
            resources.ApplyResources(this.colorIsAssignedColumn, "colorIsAssignedColumn");
            this.colorIsAssignedColumn.Name = "colorIsAssignedColumn";
            this.colorIsAssignedColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DetectedColorsGrid
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridView);
            this.Name = "DetectedColorsGrid";
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

         System.Windows.Forms.DataGridView gridView;
         System.Windows.Forms.ContextMenuStrip contextMenu;
         System.Windows.Forms.ToolStripMenuItem massAssignMenuEntry;
        private System.Windows.Forms.DataGridViewImageColumn colorDisplayColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn settingColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colorIsAssignedColumn;
    }
}
