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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Map2CivilizationView
{
    public partial class ImageProcessingForm : Form
    {
        Bitmap _imageToChange;

        public ImageProcessingForm(Bitmap imageToChange)
        {
            InitializeComponent();

            _imageToChange = imageToChange;
            previewImageBox.Image = imageToChange;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        private void trackBars_MouseUp(object sender, MouseEventArgs e)
        {
            PerformImageAdjustments();
        }


        private void trackBars_KeyUp(object sender, KeyEventArgs e)
        {
            PerformImageAdjustments();
        }


        private void PerformImageAdjustments()
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                if (previewCheckBox.Checked)
                {
                    Bitmap toDisplay = BitmapOperationsCtrl.PerfromImageAdjustments(_imageToChange, brightnessTrackBar.Value,
                       contrastTrackBar.Value/100f, 1);

                    previewImageBox.Image = toDisplay;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                previewImageBox.Update();
                previewImageBox.Refresh();
                Cursor.Current = Cursors.Default;

            }
        }

        
    }
}
