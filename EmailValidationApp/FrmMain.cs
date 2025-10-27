using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailValidationApp
{
    public partial class FrmMain : KryptonForm
    {
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private ParallelOptions options = new ParallelOptions();
        public FrmMain()
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
            this.labTotal.Text = "Total:" + list.Count.ToString();
            this.kryptonDataGridView1.DataSource = list;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var cancellationToken = this._cts.Token;
            if (this.kryptonDataGridView1.Rows.Count == 0)
            {
                KryptonMessageBox.Show(this, "No Data!", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.btnStart.Text == "Start")
            {
                this.progressBar1.Maximum = this.kryptonDataGridView1.RowCount;
                this.progressBar1.Value = 0;
                this.progressBar1.Visible = true;
                this.btnStart.Text = "Stop";
                var list = this.kryptonDataGridView1.DataSource as List<EmailModel>;
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
                            this.progressBar1.Visible = false;
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.kryptonDataGridView1.Rows.Count > 0)
            {
                var frm = new FrmExport();
                frm.List = this.kryptonDataGridView1.DataSource as List<EmailModel>;
                frm.ShowDialog();
            }
            else
            {
                KryptonMessageBox.Show(this, "No Data!", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            new FrmAbout().ShowDialog();
        }

        private void kryptonDataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.kryptonDataGridView1.Columns[e.ColumnIndex].Name == "ColumnIsValid")
            {
                if (e.Value != null)
                {
                    if (e.Value.ToString() == "Valid")
                    {
                        e.Value = imageList1.Images[0];
                    }
                    else
                    {
                        e.Value = imageList1.Images[1];

                    }
                    this.Invoke(new Action(() =>
                    {
                        this.progressBar1.PerformStep();
                    }));


                }
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (KryptonMessageBox.Show("Are you sure Exit?", "Info",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (this.btnStart.Text == "Stop")
                {
                    this._cts.Cancel();
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
