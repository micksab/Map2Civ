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