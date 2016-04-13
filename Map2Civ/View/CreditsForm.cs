using System;
using System.Windows.Forms;

namespace Map2CivilizationView
{
    public partial class CreditsForm : Form
    {
        public CreditsForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}