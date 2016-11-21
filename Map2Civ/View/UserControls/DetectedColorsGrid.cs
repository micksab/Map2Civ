/************************************************************************************/
//
//      This file is part of Map2Civilization.
//      Map2Civilization is free software: you can redistribute it and/or modify
//      it under the terms of the GNU General Public License as published by
//      the Free Software Foundation, either version 3 of the License, or
//      (at your option) any later version.
//
//      Map2Civilization is distributed in the hope that it will be useful,
//      but WITHOUT ANY WARRANTY; without even the implied warranty of
//      MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//      GNU General Public License for more details.
//
//      You should have received a copy of the GNU General Public License
//      along with Map2Civilization.  If not, see http://www.gnu.org/licenses/.
//
/************************************************************************************/


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
        private List<string> detectedColors;
        private bool discardCellChangeEvent = false;

        public DetectedColorsGrid()
        {
            InitializeComponent();

            RegisteredListenersCtrl.ColorGridListeners.RegisterObserver(this);
            ((DataGridViewComboBoxColumn)gridView.Columns[settingColumn.Name]).ValueType = typeof(TerrainTypeEnumWrapper.TerrainType);
            ((DataGridViewComboBoxColumn)gridView.Columns[settingColumn.Name]).DataSource =
               Enum.GetValues(typeof(TerrainTypeEnumWrapper.TerrainType));

            Disposed += GridControl_Disposed;
        }

        public void UpdateColorsGrid()
        {
            discardCellChangeEvent = true;

            foreach (DataGridViewRow tempRow in gridView.Rows)
            {
                string id = (string)tempRow.Cells[idColumn.Name].Value;
                TerrainTypeEnumWrapper.TerrainType displayedValue = (TerrainTypeEnumWrapper.TerrainType)tempRow.Cells[settingColumn.Name].Value;

                TerrainTypeEnumWrapper.TerrainType storedValue =
                    DetectedColorListCtrl.GetCombinedDescriptorByColorID(id);

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

            detectedColors = DetectedColorListCtrl.GetDetectedColorIDsArray();

            foreach (string colorID in detectedColors)
            {
                Bitmap bmpToAdd = BitmapOperationsCtrl.CreateSolidColorBitmap(colorID);
                string idToAdd = colorID;

                TerrainTypeEnumWrapper.TerrainType selectedSettingToAdd =
                    DetectedColorListCtrl.GetCombinedDescriptorByColorID(idToAdd);

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
                TerrainTypeEnumWrapper.TerrainType newValue =
                    (TerrainTypeEnumWrapper.TerrainType)gridView.Rows[e.RowIndex].Cells[settingColumn.Name].Value;

                DetectedColorListCtrl.UpdateDetectedColorsAndRefreshProcessedMap(new string[] { colorId }, newValue);

                evaluateCompleteness(e.RowIndex);
            }
        }

        private void evaluateCompleteness(int rownum)
        {
            string id = (string)gridView.Rows[rownum].Cells[idColumn.Name].Value;

            TerrainTypeEnumWrapper.TerrainType descriptor =
            DetectedColorListCtrl.GetCombinedDescriptorByColorID(id);

            if (descriptor == TerrainTypeEnumWrapper.TerrainType.NotDefined)
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

            

            List<PlotId> plotIdList = new List<PlotId>();

            if (selectedRows.Count > 0)
            {
                foreach (DataGridViewRow tempRow in selectedRows)
                {
                    List<PlotId> toAdd =
                        DetectedColorListCtrl.GetDetectedColorPlotCoordinates((string)tempRow.Cells[idColumn.Name].Value);

                    plotIdList.AddRange(toAdd);
                }

                RegisteredListenersCtrl.ProcessedMapShowSelectedColorsPlots(plotIdList);
            }


            if (selectedRows.Count == 1)
            {
                gridView.CurrentCell = selectedRows[0].Cells[settingColumn.Name];
                gridView.BeginEdit(true);
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
                    //DataGridViewCell cell = tempRow.Cells[settingColumn.Name];

                    //gridView.FirstDisplayedScrollingRowIndex = tempRow.Index;
                    //gridView.CurrentCell = cell;
                    //gridView.BeginEdit(true);
                    //break;
                }
            }
        }

        private void GridControl_Disposed(object sender, EventArgs e)
        {
            RegisteredListenersCtrl.ColorGridListeners.DeregisterObserver(this);
        }
    }
}