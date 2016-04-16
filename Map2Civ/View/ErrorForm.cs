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


using Map2Civilization.Properties;
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Map2CivilizationView
{
    public partial class ErrorForm : Form
    {
        private Boolean isUnhandled;

        public ErrorForm(Boolean unhandled, string message, Exception ex)
        {
            InitializeComponent();
            isUnhandled = unhandled;

            if (ex != null)
            {
                messageBox.Text = string.Concat(message, Resources.Str_SingleColonWithSpace, ex.Message);

                if (isUnhandled)
                {
                    pictureBox.Image = Map2Civilization.Properties.Resources.BugLarge_Image;
                    ExceptionInfoPanel.Visible = true;
                    setExceptionBoxContents(ex);
                }
                else
                {
                    pictureBox.Image = Map2Civilization.Properties.Resources.WarningLarge_Image;
                    ExceptionInfoPanel.Dock = DockStyle.None;
                    ExceptionInfoPanel.Size = new Size(0, 0);
                    int width = messagePanel.Width;
                    int height = messagePanel.Height + buttonPanel.Height;
                    Size = new Size(width, height);
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(ex));
            }
        }

        private void setExceptionBoxContents(Exception ex)
        {
            ArrayList exLines = new ArrayList();

            exLines.Add(ex.StackTrace);

            int counter = 0;

            while (ex.InnerException != null)
            {
                exLines.Add(string.Concat("Inner Exception ", counter));
                exLines.Add(ex.InnerException.Message);
                exLines.Add(ex.StackTrace);

                counter++;
                ex = ex.InnerException;
            }

            string toShow = string.Empty;
            foreach (string batch in exLines)
            {
                toShow = toShow + "\r\n" + batch;
            }

            exceptionBox.Text = toShow;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void messageBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; //Just do nothing, so that the user may not be able to change the contents of the textbox..
        }
    }
}