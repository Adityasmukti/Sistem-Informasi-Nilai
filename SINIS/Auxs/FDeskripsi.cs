using ExtensionMethods;
using System.Windows.Forms;

namespace SINIS.Auxs
{
    /// بسم الله الرحمن الرحيم
    /// Bismi-llāhi ar-raḥmāni ar-raḥīmi
    /// "Dengan menyebut nama Allah Yang Maha Pemurah lagi Maha Penyayang"
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
