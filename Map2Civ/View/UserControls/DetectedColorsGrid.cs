using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Map2CivilizationCtrl;
using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationCtrl.Listener;

namespace Map2CivilizationView.UserControls
{
    public partial class DetectedColorsGrid : UserControl, IUiListenerDetectedColorsGrid
    {

        string[] detectedColors;
        bool discardCellChangeEvent = false;

        public DetectedColorsGrid()
        {
            InitializeComponent();


            RegisteredListenersCtrl.ColorGridListeners.RegisterObserver(this);
            ((DataGridViewComboBoxColumn)gridView.Columns["settingColumn"]).ValueType = typeof(TerrainType.Enumeration);
            ((DataGridViewComboBoxColumn)gridView.Columns["settingColumn"]).DataSource =
               Enum.GetValues(typeof(TerrainType.Enumeration));

            Disposed += GridControl_Disposed;



        }


        public void UpdateColorsGrid()
        {

            discardCellChangeEvent = true;

            foreach (DataGridViewRow tempRow in gridView.Rows)
            {
                

                string id = (string)tempRow.Cells["idColumn"].Value;
                TerrainType.Enumeration displayedValue = (TerrainType.Enumeration)tempRow.Cells["settingColumn"].Value;

                TerrainType.Enumeration storedValue = 
                    DetectedColorCollectionCtrl.getCombinedDescriptorByColorID(id);

                if (displayedValue != storedValue)
                {
                    tempRow.Cells["settingColumn"].Value = storedValue;
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
                
                Bitmap bmpToAdd  = BitmapOperationsCtrl.CreateSolidColorBitmap(colorID);
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

         void gridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex > (-1) && discardCellChangeEvent==false && e.ColumnIndex!=gridView.Columns["ColorAssigned"].Index)
            {
                string colorId = (string)gridView.Rows[e.RowIndex].Cells["idColumn"].Value;
                TerrainType.Enumeration newValue = 
                    (TerrainType.Enumeration)gridView.Rows[e.RowIndex].Cells["settingColumn"].Value;


                DetectedColorCollectionCtrl.UpdateDetectedColorsAndRefreshProcessedMap(new string[] { colorId }, newValue);

                evaluateCompleteness(e.RowIndex);

                
            }
            
        

        }

       


         void evaluateCompleteness(int rownum)
        {
            string id = (string)gridView.Rows[rownum].Cells["idColumn"].Value;

            TerrainType.Enumeration  descriptor = 
            DetectedColorCollectionCtrl.getCombinedDescriptorByColorID(id);

            if (descriptor == TerrainType.Enumeration.NotDefined)
            {
                gridView.Rows[rownum].Cells["idColumn"].Style.ForeColor = Color.Red;
                gridView.Rows[rownum].Cells["ColorAssigned"].Value = false;
            }
            else
            {
                gridView.Rows[rownum].Cells["idColumn"].Style.ForeColor = Color.Teal;
                gridView.Rows[rownum].Cells["ColorAssigned"].Value = true;                
            }
        }



         void gridView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedCol = gridView.SelectedRows;
            List<PlotId> plotIdList = new List<PlotId>();

            if (selectedCol.Count > 0)
            {
                
                foreach (DataGridViewRow tempRow in selectedCol)
                {
                    
                    List<PlotId> toAdd = 
                        DetectedColorCollectionCtrl.getDetectedColorPlotCoordinates((string)tempRow.Cells["idColumn"].Value);

                    plotIdList.AddRange(toAdd);
                }

                RegisteredListenersCtrl.ProcessedMapShowSelectedColorsPlots(plotIdList);

            }
    

        }

         void massAssignMenuEntry_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedCol = gridView.SelectedRows;
            ArrayList toEdit = new ArrayList();

            if (selectedCol.Count > 0)
            {

                foreach (DataGridViewRow tempRow in selectedCol)
                {
                    string toAdd = (string)tempRow.Cells["idColumn"].Value;
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



         void GridControl_Disposed(object sender, EventArgs e)
        {
            RegisteredListenersCtrl.ColorGridListeners.DeregisterObserver(this);
        }







    }
}
