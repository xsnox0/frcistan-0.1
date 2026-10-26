namespace Frcistan
{
    partial class Form1
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
            grpUrun = new GroupBox();
            btnTemizle = new Button();
            btnSil = new Button();
            btnGuncelle = new Button();
            btnEkle = new Button();
            numFiyat = new NumericUpDown();
            lblFiyat = new Label();
            numAdet = new NumericUpDown();
            lblAdet = new Label();
            txtUrunAdi = new TextBox();
            lblUrunAdi = new Label();
            txtId = new TextBox();
            lblId = new Label();
            cmbMarka = new ComboBox();
            lblKategori = new Label();
            cmbKategori = new ComboBox();
            lblMarka = new Label();
            lblArama = new Label();
            txtArama = new TextBox();
            dgvUrunler = new DataGridView();
            lblSiralamaBilgi = new Label();
            lblToplam = new Label();
            btnCikis = new Button();
            grpUrun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numFiyat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numAdet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvUrunler).BeginInit();
            SuspendLayout();
            // 
            // grpUrun
            // 
            grpUrun.Controls.Add(btnTemizle);
            grpUrun.Controls.Add(btnSil);
            grpUrun.Controls.Add(btnGuncelle);
            grpUrun.Controls.Add(btnEkle);
            grpUrun.Controls.Add(numFiyat);
            grpUrun.Controls.Add(lblFiyat);
            grpUrun.Controls.Add(numAdet);
            grpUrun.Controls.Add(lblAdet);
            grpUrun.Controls.Add(txtUrunAdi);
            grpUrun.Controls.Add(lblUrunAdi);
            grpUrun.Controls.Add(txtId);
            grpUrun.Controls.Add(lblId);
            grpUrun.Controls.Add(cmbMarka);
            grpUrun.Controls.Add(lblMarka);
            grpUrun.Controls.Add(cmbKategori);
            grpUrun.Controls.Add(lblKategori);
            grpUrun.Location = new Point(12, 12);
            grpUrun.Name = "grpUrun";
            grpUrun.Size = new Size(290, 335);
            grpUrun.TabIndex = 0;
            grpUrun.TabStop = false;
            grpUrun.Text = "Ürün Bilgileri";
            // 
            // lblKategori
            // 
            lblKategori.AutoSize = true;
            lblKategori.Location = new Point(15, 32);
            lblKategori.Name = "lblKategori";
            lblKategori.Size = new Size(54, 15);
            lblKategori.TabIndex = 0;
            lblKategori.Text = "Kategori:";
            // 
            // cmbKategori
            // 
            cmbKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKategori.FormattingEnabled = true;
            cmbKategori.Location = new Point(95, 29);
            cmbKategori.Name = "cmbKategori";
            cmbKategori.Size = new Size(180, 23);
            cmbKategori.TabIndex = 1;
            // 
            // lblMarka
            // 
            lblMarka.AutoSize = true;
            lblMarka.Location = new Point(15, 67);
            lblMarka.Name = "lblMarka";
            lblMarka.Size = new Size(43, 15);
            lblMarka.TabIndex = 2;
            lblMarka.Text = "Marka:";
            // 
            // cmbMarka
            // 
            cmbMarka.FormattingEnabled = true;
            cmbMarka.Items.AddRange(new object[] { "AndyMark", "CTR Electronics", "goBILDA", "Kauai Labs", "Limelight", "Playing With Fusion", "Redux Robotics", "REV Robotics", "Studica", "Swerve Drive Specialties", "ThriftyBot", "VEX Robotics", "WCP" });
            cmbMarka.Location = new Point(95, 64);
            cmbMarka.Name = "cmbMarka";
            cmbMarka.Size = new Size(180, 23);
            cmbMarka.TabIndex = 3;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(15, 102);
            lblId.Name = "lblId";
            lblId.Size = new Size(20, 15);
            lblId.TabIndex = 4;
            lblId.Text = "Id:";
            // 
            // txtId
            // 
            txtId.Location = new Point(95, 99);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 5;
            txtId.TabStop = false;
            // 
            // lblUrunAdi
            // 
            lblUrunAdi.AutoSize = true;
            lblUrunAdi.Location = new Point(15, 137);
            lblUrunAdi.Name = "lblUrunAdi";
            lblUrunAdi.Size = new Size(57, 15);
            lblUrunAdi.TabIndex = 6;
            lblUrunAdi.Text = "Ürün Adı:";
            // 
            // txtUrunAdi
            // 
            txtUrunAdi.Location = new Point(95, 134);
            txtUrunAdi.MaxLength = 100;
            txtUrunAdi.Name = "txtUrunAdi";
            txtUrunAdi.Size = new Size(180, 23);
            txtUrunAdi.TabIndex = 7;
            // 
            // lblAdet
            // 
            lblAdet.AutoSize = true;
            lblAdet.Location = new Point(15, 172);
            lblAdet.Name = "lblAdet";
            lblAdet.Size = new Size(34, 15);
            lblAdet.TabIndex = 8;
            lblAdet.Text = "Adet:";
            // 
            // numAdet
            // 
            numAdet.Location = new Point(95, 170);
            numAdet.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numAdet.Name = "numAdet";
            numAdet.Size = new Size(100, 23);
            numAdet.TabIndex = 9;
            // 
            // lblFiyat
            // 
            lblFiyat.AutoSize = true;
            lblFiyat.Location = new Point(15, 207);
            lblFiyat.Name = "lblFiyat";
            lblFiyat.Size = new Size(55, 15);
            lblFiyat.TabIndex = 10;
            lblFiyat.Text = "Fiyat ($):";
            // 
            // numFiyat
            // 
            numFiyat.DecimalPlaces = 2;
            numFiyat.Location = new Point(95, 205);
            numFiyat.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numFiyat.Name = "numFiyat";
            numFiyat.Size = new Size(100, 23);
            numFiyat.TabIndex = 11;
            numFiyat.ThousandsSeparator = true;
            // 
            // btnEkle
            // 
            btnEkle.Location = new Point(15, 250);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(125, 30);
            btnEkle.TabIndex = 12;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.Location = new Point(150, 250);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(125, 30);
            btnGuncelle.TabIndex = 13;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = true;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // btnSil
            // 
            btnSil.Location = new Point(15, 290);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(125, 30);
            btnSil.TabIndex = 14;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // btnTemizle
            // 
            btnTemizle.Location = new Point(150, 290);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(125, 30);
            btnTemizle.TabIndex = 15;
            btnTemizle.Text = "Temizle";
            btnTemizle.UseVisualStyleBackColor = true;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // lblArama
            // 
            lblArama.AutoSize = true;
            lblArama.Location = new Point(320, 20);
            lblArama.Name = "lblArama";
            lblArama.Size = new Size(28, 15);
            lblArama.TabIndex = 1;
            lblArama.Text = "Ara:";
            // 
            // txtArama
            // 
            txtArama.Location = new Point(355, 17);
            txtArama.Name = "txtArama";
            txtArama.PlaceholderText = "Id, kategori, marka veya ürün adı";
            txtArama.Size = new Size(250, 23);
            txtArama.TabIndex = 2;
            txtArama.TextChanged += txtArama_TextChanged;
            // 
            // lblSiralamaBilgi
            // 
            lblSiralamaBilgi.AutoSize = true;
            lblSiralamaBilgi.Location = new Point(620, 20);
            lblSiralamaBilgi.Name = "lblSiralamaBilgi";
            lblSiralamaBilgi.Size = new Size(226, 15);
            lblSiralamaBilgi.TabIndex = 3;
            lblSiralamaBilgi.Text = "Sıralamak için sütun başlığına tıklayın.";
            // 
            // dgvUrunler
            // 
            dgvUrunler.AllowUserToAddRows = false;
            dgvUrunler.AllowUserToDeleteRows = false;
            dgvUrunler.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUrunler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUrunler.Location = new Point(320, 50);
            dgvUrunler.MultiSelect = false;
            dgvUrunler.Name = "dgvUrunler";
            dgvUrunler.ReadOnly = true;
            dgvUrunler.RowHeadersVisible = false;
            dgvUrunler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUrunler.Size = new Size(560, 297);
            dgvUrunler.TabIndex = 4;
            dgvUrunler.CellClick += dgvUrunler_CellClick;
            dgvUrunler.DataBindingComplete += dgvUrunler_DataBindingComplete;
            // 
            // lblToplam
            // 
            lblToplam.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblToplam.AutoSize = true;
            lblToplam.Location = new Point(320, 355);
            lblToplam.Name = "lblToplam";
            lblToplam.Size = new Size(84, 15);
            lblToplam.TabIndex = 5;
            lblToplam.Text = "Toplam ürün: 0";
            // 
            // btnCikis
            // 
            btnCikis.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCikis.Location = new Point(790, 351);
            btnCikis.Name = "btnCikis";
            btnCikis.Size = new Size(90, 27);
            btnCikis.TabIndex = 6;
            btnCikis.Text = "Çıkış Yap";
            btnCikis.UseVisualStyleBackColor = true;
            btnCikis.Click += btnCikis_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(894, 381);
            Controls.Add(btnCikis);
            Controls.Add(lblToplam);
            Controls.Add(dgvUrunler);
            Controls.Add(lblSiralamaBilgi);
            Controls.Add(txtArama);
            Controls.Add(lblArama);
            Controls.Add(grpUrun);
            MinimumSize = new Size(910, 420);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Frcistan 0.1 - Robot Parçası Stok Takibi";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            grpUrun.ResumeLayout(false);
            grpUrun.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numFiyat).EndInit();
            ((System.ComponentModel.ISupportInitialize)numAdet).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvUrunler).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpUrun;
        private Label lblKategori;
        private ComboBox cmbKategori;
        private Label lblMarka;
        private ComboBox cmbMarka;
        private Label lblId;
        private TextBox txtId;
        private Label lblUrunAdi;
        private TextBox txtUrunAdi;
        private Label lblAdet;
        private NumericUpDown numAdet;
        private Label lblFiyat;
        private NumericUpDown numFiyat;
        private Button btnEkle;
        private Button btnGuncelle;
        private Button btnSil;
        private Button btnTemizle;
        private Label lblArama;
        private TextBox txtArama;
        private DataGridView dgvUrunler;
        private Label lblSiralamaBilgi;
        private Label lblToplam;
        private Button btnCikis;
    }
}
