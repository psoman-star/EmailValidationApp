using Krypton.Toolkit;
using System;
using System.Diagnostics;

namespace EmailValidationApp
{
    public partial class FrmAbout : KryptonForm
    {
        public FrmAbout()
        {
            InitializeComponent();
            this.labVersion.Text ="3.0.1";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonLinkLabel1_LinkClicked(object sender, EventArgs e)
        {

            var psi = new ProcessStartInfo
            {
                FileName = "https://t.me/emailhelpv2",
                UseShellExecute = true
            };
            System.Diagnostics.Process.Start(psi);
        }
    }
}
