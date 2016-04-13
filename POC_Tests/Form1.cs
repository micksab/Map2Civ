using System;
using System.Windows.Forms;

namespace POC_Tests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MovingBox test = new MovingBox();
            test.ShowDialog();
            test.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (ColorCounterForm form = new ColorCounterForm())
            {
                form.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string originalString = System.IO.File.ReadAllText(@"C:\MyDocuments\GeoMap2Civ5Map\Map2Civ\POC_Tests\StringTest.txt");

            string compressedString = StringCompression.Compress(originalString);

            int originalStringLength = originalString.Length;
            int compressedStringLength = compressedString.Length;

            return;
        }
    }
}