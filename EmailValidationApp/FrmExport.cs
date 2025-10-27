using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EmailValidationApp
{
    public partial class FrmExport : KryptonForm
    {
        private ExportUtils exportUtils = new ExportUtils();
        public List<EmailModel> List { get; set; }
        public FrmExport()
        {
            InitializeComponent();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            this.Export(this.List);
        }

        private void Export(List<EmailModel> list)
        {
            if (list.Count == 0)
            {
                KryptonMessageBox.Show("No Data!", "Info",
             MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var result = this.exportUtils.ExportToCsv(list);
            var msg = result.Item1 ? "Export Success!" : result.Item2;
            KryptonMessageBox.Show(msg, "Info",
           MessageBoxButtons.OK, MessageBoxIcon.Information);

        }




        private void btnValid_Click(object sender, EventArgs e)
        {
            var list = this.List.Where(e => e.IsValid == "Valid").ToList();
            this.Export(list);
        }

        private void btnIncomplete_Click(object sender, EventArgs e)
        {
            var list = this.List.Where(e => e.Status == "Incomplete").ToList();
            this.Export(list);
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {

            var list = this.List.Where(e => e.Status == "Incomplete").ToList();
            this.Export(list);
        }
    }
}
