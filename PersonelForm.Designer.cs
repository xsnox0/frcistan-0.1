namespace Frcistan
{
    partial class PersonelForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblHosgeldin = new Label();
            lblArama = new Label();
            txtArama = new TextBox();
            chkAzalan = new CheckBox();
            dgvUrunler = new DataGridView();
            lblOzet = new Label();
            btnCikis = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUrunler).BeginInit();
            SuspendLayout();
            //
            // lblHosgeldin
            //
            lblHosgeldin.AutoSize = true;
            lblHosgeldin.Location = new Point(12, 15);
            lblHosgeldin.Name = "lblHosgeldin";
            lblHosgeldin.Size = new Size(64, 15);
            lblHosgeldin.TabIndex = 0;
            lblHosgeldin.Text = "Hoş geldin";
            //
            // lblArama
            //
            lblArama.AutoSize = true;
            lblArama.Location = new Point(12, 48);
            lblArama.Name = "lblArama";
            lblArama.Size = new Size(28, 15);
            lblArama.TabIndex = 1;
            lblArama.Text = "Ara:";
            //
            // txtArama
            //
            txtArama.Location = new Point(47, 45);
            txtArama.Name = "txtArama";
            txtArama.PlaceholderText = "Id, kategori, marka veya ürün adı";
            txtArama.Size = new Size(250, 23);
            txtArama.TabIndex = 2;
            txtArama.TextChanged += txtArama_TextChanged;
            //
            // chkAzalan
            //
            chkAzalan.AutoSize = true;
            chkAzalan.Location = new Point(315, 47);
            chkAzalan.Name = "chkAzalan";
            chkAzalan.Size = new Size(201, 19);
            chkAzalan.TabIndex = 3;
            chkAzalan.Text = "Sadece stoğu azalanlar (5 ve altı)";
            chkAzalan.UseVisualStyleBackColor = true;
            chkAzalan.CheckedChanged += chkAzalan_CheckedChanged;
            //
            // dgvUrunler
            //
            dgvUrunler.AllowUserToAddRows = false;
            dgvUrunler.AllowUserToDeleteRows = false;
            dgvUrunler.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUrunler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUrunler.Location = new Point(12, 78);
            dgvUrunler.MultiSelect = false;
            dgvUrunler.Name = "dgvUrunler";
            dgvUrunler.ReadOnly = true;
            dgvUrunler.RowHeadersVisible = false;
            dgvUrunler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUrunler.Size = new Size(870, 265);
            dgvUrunler.TabIndex = 4;
            dgvUrunler.DataBindingComplete += dgvUrunler_DataBindingComplete;
            //
            // lblOzet
            //
            lblOzet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblOzet.AutoSize = true;
            lblOzet.Location = new Point(12, 355);
            lblOzet.Name = "lblOzet";
            lblOzet.Size = new Size(84, 15);
            lblOzet.TabIndex = 5;
            lblOzet.Text = "Toplam ürün: 0";
            //
            // btnCikis
            //
            btnCikis.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCikis.Location = new Point(792, 351);
            btnCikis.Name = "btnCikis";
            btnCikis.Size = new Size(90, 27);
            btnCikis.TabIndex = 6;
            btnCikis.Text = "Çıkış Yap";
            btnCikis.UseVisualStyleBackColor = true;
            btnCikis.Click += btnCikis_Click;
            //
            // PersonelForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(894, 381);
            Controls.Add(btnCikis);
            Controls.Add(lblOzet);
            Controls.Add(dgvUrunler);
            Controls.Add(chkAzalan);
            Controls.Add(txtArama);
            Controls.Add(lblArama);
            Controls.Add(lblHosgeldin);
            MinimumSize = new Size(910, 420);
            Name = "PersonelForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Frcistan 0.1 - Stok Listesi";
            WindowState = FormWindowState.Maximized;
            Load += PersonelForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUrunler).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHosgeldin;
        private Label lblArama;
        private TextBox txtArama;
        private CheckBox chkAzalan;
        private DataGridView dgvUrunler;
        private Label lblOzet;
        private Button btnCikis;
    }
}
