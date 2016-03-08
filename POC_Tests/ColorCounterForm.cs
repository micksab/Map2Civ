using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POC_Tests
{
    public partial class ColorCounterForm : Form
    {
        public ColorCounterForm()
        {
            InitializeComponent();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            try
            {

                //this.fileBox_TextChanged(this, new EventArgs());
                Cursor = Cursors.WaitCursor;
                Bitmap image = (Bitmap)Image.FromFile(fileBox.Text);
                this.pictureBox.Image = image;

                Dictionary<Color, int> colorList = new Dictionary<Color, int>();

                for (int x = 0; x < image.Width; x++)
                {

                    for (int y = 0; y < image.Height; y++)
                    {

                        Color tempColor = image.GetPixel(x, y);

                        if (tempColor != Color.Transparent)
                        {
                            if (colorList.ContainsKey(tempColor))
                            {
                                colorList[tempColor] += 1;
                            }
                            else
                            {
                                colorList.Add(tempColor, 1);
                            }
                        }


                    }

                }

                this.colorsDetectedLabel.Text = "Colors Detected: " + colorList.Count;


            }
           catch(Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Error while loading image file:" + ex.Message, "Error!", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void fileBox_TextChanged(object sender, EventArgs e)
        {
            fileBox.Text = fileBox.Text.Replace("\"", String.Empty);
        }
    }
}
