using ExtensionMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SINIS.TU
{
    public partial class FKelolaPengajaran : Form
    {
        public FKelolaPengajaran(string tahunajaran, string kodepelajaran, string kodeguru)
        {
            InitializeComponent();
            this.SetControlFrom();

        }

        public FKelolaPengajaran(object kodejadwal)
        {
            InitializeComponent();
            this.SetControlFrom();
        }
    }
}
