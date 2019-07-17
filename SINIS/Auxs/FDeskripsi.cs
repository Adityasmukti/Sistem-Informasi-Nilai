using ExtensionMethods;
using System.Windows.Forms;

namespace SINIS.Auxs
{
    public partial class FDeskripsi : Form
    {
        public FDeskripsi(string text, string caption="DESKRIPSI")
        {
            InitializeComponent();
            this.SetControlFrom();
            Text = caption.ToUpper();
            TbText.Text = text;
        }
    }
}
