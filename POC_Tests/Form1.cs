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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

         void button1_Click(object sender, EventArgs e)
        {
            MovingBox test = new MovingBox();
            test.ShowDialog();
            test.Dispose();
        }

         void button2_Click(object sender, EventArgs e)
        {
            using(ColorCounterForm form = new ColorCounterForm())
            {
                form.ShowDialog();
            }
        }
    }
}
