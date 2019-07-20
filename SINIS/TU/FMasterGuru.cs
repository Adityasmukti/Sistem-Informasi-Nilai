using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExtensionMethods;

namespace SINIS.TU
{
    public partial class FMasterGuru : Form
    {
        public FMasterGuru()
        {
            InitializeComponent();
            this.SetControlFrom();
        }

        private void BTambah_Click(object sender, EventArgs e)
        {
            FInputGuru f = new FInputGuru();
            f.ShowDialog();
            Loaddb();
        }

        private bool Loaddb()
        {
        }

        private void BOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FMasterGuru_Load(object sender, EventArgs e)
        {

        }
    }
}
