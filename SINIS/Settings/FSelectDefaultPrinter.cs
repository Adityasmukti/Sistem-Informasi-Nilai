using System;
using System.Management;
using System.Windows.Forms;
using ExtensionMethods;

namespace SINIS.Settings
{
    public partial class FSelectDefaultPrinter : Form
    {
        public FSelectDefaultPrinter()
        {
            InitializeComponent();
            this.SetControlFrom();
        }

        private void BSimpan_Click(object sender, EventArgs e)
        {
            if (CbPrinter.SelectedIndex < 0)
                MessageBox.Show("Pilih Printer", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                MyPrinters.SetDefaultPrinter(CbPrinter.Text);
                MessageBox.Show("Tersimpan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void FSelectDefaultPrinter_Load(object sender, EventArgs e)
        {
            CbPrinter.Items.Clear();
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                if (!string.IsNullOrEmpty(printer))
                    CbPrinter.Items.Add(printer);
            }

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");
            foreach (ManagementObject printer in searcher.Get())
            {
                if (((bool?)printer["Default"]) ?? false)
                {
                    CbPrinter.Text = printer["Name"].ToString();
                }
            }
        }
    }
}