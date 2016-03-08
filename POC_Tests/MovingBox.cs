﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POC_Tests
{
    public partial class MovingBox : Form
    {
        Image foreImage ;
        float zoomFactor = 1f;
        int baseWidth = 0;
        int baseHeight = 0;

        public MovingBox()
        {
            InitializeComponent();
            foreImage = new Bitmap(this.pictureBox.Width, this.pictureBox.Height);
            this.pictureBox.Image = foreImage;
            this.xTrackBar.Maximum = this.pictureBox.Width-50;
            pictureBox.MouseWheel += pictureBox_MouseWheel;

            baseWidth = pictureBox.Width;
            baseHeight = pictureBox.Height;

        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            

            using(Graphics g = Graphics.FromImage(foreImage))
            {
                using (Brush blackBrush = new SolidBrush(Color.FromArgb(70, 0, 0, 0)))
                {
                    g.Clear(Color.Transparent);
                    g.FillRectangle(blackBrush, (float)xTrackBar.Value, 0, 15, 15);
                    
                  

                }
            }

            pictureBox.Update();
            pictureBox.Refresh();
            
        }



        protected void pictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                zoomFactor = zoomFactor+0.1f;
            }
            else
            {
                zoomFactor = zoomFactor - 0.1f;

            }

            int width = this.pictureBox.Size.Width;
            int height = this.pictureBox.Size.Height;
            this.pictureBox.Size = new Size((int)(baseWidth * zoomFactor), (int)(baseHeight * zoomFactor));
            
        }


    }
}
