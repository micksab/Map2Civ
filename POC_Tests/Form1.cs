using System;
using System.Drawing.Imaging;
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

        private void button4_Click(object sender, EventArgs e)
        {
             
            Console.WriteLine("Format1bppIndexed : {0} ", Convert.ToInt32(PixelFormat.Format1bppIndexed));
            Console.WriteLine("Format4bppIndexed : {0} ", Convert.ToInt32(PixelFormat.Format4bppIndexed));
            Console.WriteLine("Format8bppIndexed : {0}", Convert.ToInt32(PixelFormat.Format8bppIndexed));
            Console.WriteLine("Format16bppRgb555 : {0}", Convert.ToInt32(PixelFormat.Format16bppRgb555));
            Console.WriteLine("Format24bppRgb : {0}", Convert.ToInt32(PixelFormat.Format24bppRgb));
            Console.WriteLine("Format32bppRgb : {0}", Convert.ToInt32(PixelFormat.Format32bppRgb));
            Console.WriteLine("Format48bppRgb : {0}", Convert.ToInt32(PixelFormat.Format48bppRgb));
            Console.WriteLine("Format64bppArgb : {0}", Convert.ToInt32(PixelFormat.Format64bppArgb));
        }
    }
}