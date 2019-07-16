using ExtensionMethods;
using System;
using System.Windows.Forms;

namespace AtelierAngelinaApps.Auxs
{
    public partial class FShowData : Form
    {
        public FShowData()
        {
            InitializeComponent();
            this.SetControlFrom();
            this.KeyDown += F_KeyDown;
            this.Load += FListProduk_Load;
        }

        private void FListProduk_Load(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(A.GetQueri()))
            {
                Dg.Columns.Clear();
                Dg.DataSource = A.GetQueri().GetData();
            }
        }

        private void F_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
            }
            else if (e.KeyCode == Keys.F2)
            {
            }
            else if (e.KeyCode == Keys.F3)
            {
            }
            else if (e.KeyCode == Keys.F4)
            {
            }
            else if (e.KeyCode == Keys.F5)
            {
            }
            else if (e.KeyCode == Keys.F6)
            {
            }
            else if (e.KeyCode == Keys.F7)
            {
            }
            else if (e.KeyCode == Keys.F8)
            {
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
