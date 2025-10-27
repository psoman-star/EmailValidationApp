
namespace EmailValidationApp
{
    partial class FrmExport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.btnAll = new Krypton.Toolkit.KryptonButton();
            this.btnValid = new Krypton.Toolkit.KryptonButton();
            this.btnIncomplete = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton4 = new Krypton.Toolkit.KryptonButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonButton4);
            this.kryptonPanel1.Controls.Add(this.btnIncomplete);
            this.kryptonPanel1.Controls.Add(this.btnValid);
            this.kryptonPanel1.Controls.Add(this.btnAll);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(757, 439);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(125, 88);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(221, 78);
            this.btnAll.TabIndex = 0;
            this.btnAll.Values.Text = "Export All";
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnValid
            // 
            this.btnValid.Location = new System.Drawing.Point(399, 88);
            this.btnValid.Name = "btnValid";
            this.btnValid.Size = new System.Drawing.Size(234, 78);
            this.btnValid.TabIndex = 1;
            this.btnValid.Values.Text = "Export Valid";
            this.btnValid.Click += new System.EventHandler(this.btnValid_Click);
            // 
            // btnIncomplete
            // 
            this.btnIncomplete.Location = new System.Drawing.Point(125, 205);
            this.btnIncomplete.Name = "btnIncomplete";
            this.btnIncomplete.Size = new System.Drawing.Size(221, 78);
            this.btnIncomplete.TabIndex = 2;
            this.btnIncomplete.Values.Text = "Export Incomplete";
            this.btnIncomplete.Click += new System.EventHandler(this.btnIncomplete_Click);
            // 
            // kryptonButton4
            // 
            this.kryptonButton4.Location = new System.Drawing.Point(399, 205);
            this.kryptonButton4.Name = "kryptonButton4";
            this.kryptonButton4.Size = new System.Drawing.Size(234, 78);
            this.kryptonButton4.TabIndex = 3;
            this.kryptonButton4.Values.Text = "Export Complete";
            this.kryptonButton4.Click += new System.EventHandler(this.kryptonButton4_Click);
            // 
            // FrmExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 439);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmExport";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonButton btnAll;
        private Krypton.Toolkit.KryptonButton kryptonButton4;
        private Krypton.Toolkit.KryptonButton btnIncomplete;
        private Krypton.Toolkit.KryptonButton btnValid;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}