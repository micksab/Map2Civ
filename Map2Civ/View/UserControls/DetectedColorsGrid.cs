using Map2CivilizationCtrl;
using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationCtrl.Listener;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Map2CivilizationView.UserControls
{
    public partial class DetectedColorsGrid : UserControl, IUiListenerDetectedColorsGrid
    {
        private string[] detectedColors;
        private bool discardCellChangeEvent = false;

        public DetectedColorsGrid()
        {
            InitializeComponent();

            RegisteredListenersCtrl.ColorGridListeners.RegisterObserver(this);
            ((DataGridViewComboBoxColumn)gridView.Columns[settingColumn.Name]).ValueType = typeof(TerrainType.Enumeration);
            ((DataGridViewComboBoxColumn)gridView.Columns[settingColumn.Name]).DataSource =
               Enum.GetValues(typeof(TerrainType.Enumeration));

            Disposed += GridControl_Disposed;
        }

        public void UpdateColorsGrid()
        {
            discardCellChangeEvent = true;

            foreach (DataGridViewRow tempRow in gridView.Rows)
            {
                string id = (string)tempRow.Cells[idColumn.Name].Value;
                TerrainType.Enumeration displayedValue = (TerrainType.Enumeration)tempRow.Cells[settingColumn.Name].Value;

                TerrainType.Enumeration storedValue =
                    DetectedColorCollectionCtrl.getCombinedDescriptorByColorID(id);

                if (displayedValue != storedValue)
                {
                    tempRow.Cells[settingColumn.Name].Value = storedValue;
                    evaluateCompleteness(tempRow.Index);
                }
            }

            discardCellChangeEvent = false;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public void FillColorGrid()
        {
            gridView.Rows.Clear();
            gridView.Update();
            gridView.Refresh();

            detectedColors = DetectedColorCollectionCtrl.getDetectedColorIDsArray();

            foreach (string colorID in detectedColors)
            {
                Bitmap bmpToAdd = BitmapOperationsCtrl.CreateSolidColorBitmap(colorID);
                string idToAdd = colorID;

                TerrainType.Enumeration selectedSettingToAdd =
                    DetectedColorCollectionCtrl.getCombinedDescriptorByColorID(idToAdd);

                int newRowIndex = gridView.Rows.Add(bmpToAdd, idToAdd, selectedSettingToAdd);

                evaluateCompleteness(newRowIndex);
            }

            gridView.CurrentCell = null;
            gridView.Sort(gridView.Columns[idColumn.Name], ListSortDirection.Ascending);

            RegisteredListenersCtrl.DetectedColorsCounterUpdate(gridView.Rows.Count);
            gridView.Update();
            gridView.Refresh();
        }

        private void gridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > (-1) && discardCellChangeEvent == false && e.ColumnIndex != gridView.Columns[colorIsAssignedColumn.Name].Index)
            {
                string colorId = (string)gridView.Rows[e.RowIndex].Cells[idColumn.Name].Value;
                TerrainType.Enumeration newValue =
                    (TerrainType.Enumeration)gridView.Rows[e.RowIndex].Cells[settingColumn.Name].Value;

                DetectedColorCollectionCtrl.UpdateDetectedColorsAndRefreshProcessedMap(new string[] { colorId }, newValue);

                evaluateCompleteness(e.RowIndex);
            }
        }

        private void evaluateCompleteness(int rownum)
        {
            string id = (string)gridView.Rows[rownum].Cells[idColumn.Name].Value;

            TerrainType.Enumeration descriptor =
            DetectedColorCollectionCtrl.getCombinedDescriptorByColorID(id);

            if (descriptor == TerrainType.Enumeration.NotDefined)
            {
                gridView.Rows[rownum].Cells[idColumn.Name].Style.ForeColor = Color.Red;
                gridView.Rows[rownum].Cells[colorIsAssignedColumn.Name].Value = false;
            }
            else
            {
                gridView.Rows[rownum].Cells[idColumn.Name].Style.ForeColor = Color.Teal;
                gridView.Rows[rownum].Cells[colorIsAssignedColumn.Name].Value = true;
            }
        }

        private void gridView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = gridView.SelectedRows;

            //if (selectedRows.Count == 1)
            //{
            //    gridView.CurrentCell = selectedRows[0].Cells[settingColumn.Name];
            //    gridView.BeginEdit(true);
            //}

            List<PlotId> plotIdList = new List<PlotId>();

            if (selectedRows.Count > 0)
            {
                foreach (DataGridViewRow tempRow in selectedRows)
                {
                    List<PlotId> toAdd =
                        DetectedColorCollectionCtrl.getDetectedColorPlotCoordinates((string)tempRow.Cells[idColumn.Name].Value);

                    plotIdList.AddRange(toAdd);
                }

                RegisteredListenersCtrl.ProcessedMapShowSelectedColorsPlots(plotIdList);
            }
        }

        private void massAssignMenuEntry_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedCol = gridView.SelectedRows;
            ArrayList toEdit = new ArrayList();

            if (selectedCol.Count > 0)
            {
                foreach (DataGridViewRow tempRow in selectedCol)
                {
                    string toAdd = (string)tempRow.Cells[idColumn.Name].Value;
                    toEdit.Add(toAdd);
                }
            }

            string[] toEditArray = (string[])toEdit.ToArray(typeof(string));
            using (MassColorEditForm massForm = new MassColorEditForm(toEditArray))
            {
                DialogResult result = massForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    UpdateColorsGrid();
                }
            }
        }

        public void SetSelectedColor(string colorId)
        {
            DataGridViewRowCollection rowCol = gridView.Rows;
            gridView.ClearSelection();

            foreach (DataGridViewRow tempRow in rowCol)
            {
                if (((string)tempRow.Cells[idColumn.Name].Value).Equals(colorId))
                {
                    tempRow.Selected = true;
                    DataGridViewCell cell = tempRow.Cells[colorDisplayColumn.Name];

                    gridView.FirstDisplayedScrollingRowIndex = tempRow.Index;
                    gridView.CurrentCell = cell;
                    gridView.BeginEdit(true);
                    break;
                }
            }
        }

        private void GridControl_Disposed(object sender, EventArgs e)
        {
            RegisteredListenersCtrl.ColorGridListeners.DeregisterObserver(this);
        }
    }
}