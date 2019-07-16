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

namespace AtelierAngelinaApps.Applications
{
    public partial class FOpenOrder : Form
    {
        public FOpenOrder()
        {
            InitializeComponent();
            this.SetControlFrom();
        }

        private void FOpenOrder_Load(object sender, EventArgs e)
        {
            CbOPenOrder.LoadOpenOrder();
        }
        private void Loaddb()
        {
            int jumlah = 0;
            if (CbOPenOrder.Text == "AHD")
            {
                jumlah = 2325;
                label1.Text = "PO Daily Wear Juli";
            }
            else
            {
                A.SetQueri("SELECT * FROM `f_order` `O` WHERE `expireorder`='N' AND `openorder`='" + CbOPenOrder.Text + "' ");
                if (Dtp1.Checked)
                    A.SetQueri(A.GetQueri() + "AND `tglorder`>='" + Dtp1.ToStringDate() + " 00:00:00' ");
                jumlah = A.GetQueri().JumlahData();
                label1.Text = CbOPenOrder.Text;
            }

            Timer t = new Timer();
            t.Interval = 10;
            int temp=0;
            t.Tick += (sender, e) =>
            {
                LOpenOrderJumlah.Text = (temp).ToString();
                temp += 10;
                if (temp >= jumlah)
                {
                    t.Stop();
                    LOpenOrderJumlah.Text = jumlah.ToString();
                }
            };
            t.Start();
        }

        private void CbOPenOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            Loaddb();
        }
    }
}
