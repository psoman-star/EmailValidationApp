using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailValidationApp.CustomControls
{
    public partial class ValidationControl : UserControl
    {
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private ParallelOptions options = new ParallelOptions();
        public ValidationControl()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "Text File|*.txt";
            if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            var fileName = this.openFileDialog1.FileName;
            var list = new DataText().ImportData(fileName);
            this.dgvEmail.DataSource = list;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            new FrmExport().ShowDialog(this);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var cancellationToken = this._cts.Token;
            if (this.dgvEmail.Rows.Count == 0)
            {
                KryptonMessageBox.Show(this, "No Data!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.btnStart.Text == "Start")
            {
                this.btnStart.Text = "Stop";
                var list = this.dgvEmail.DataSource as List<EmailModel>;
                var validator = new EmailValidator.EmailValidator();
                Task.Run(() =>
                {
                    options.CancellationToken = cancellationToken;
                    try
                    {
                        Parallel.ForEach(list, options, (item, state, index) =>
                        {
                            if (item.Status != "Complete")
                            {
                                var result = validator.Validate(item.Email);
                                item.IsValid = result.IsValid ? "Valid" : "Invalid";
                                item.Result = result.Msg;
                                item.Status = "Complete";
                                this.options.CancellationToken.ThrowIfCancellationRequested();
                            }

                        });
                    }
                    catch (OperationCanceledException ex)
                    {

                    }



                }, cancellationToken).ContinueWith(o =>
                {
                    if (o.IsCompleted)
                    {

                        this.Invoke(new Action(() =>
                        {
                            this.btnStart.Text = "Start";
                            this.btnStart.Enabled = true;
                            KryptonMessageBox.Show(this, " Verification completed!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }));
                    }
                });

            }
            else
            {
                this.btnStart.Text = "Stoping";
                this.btnStart.Enabled = false;
                this._cts.Cancel();
                this._cts = new CancellationTokenSource();

            }
        }
    }
}
