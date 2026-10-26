namespace Frcistan
{
    partial class GirisForm
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
            lblKullaniciAdi = new Label();
            txtKullaniciAdi = new TextBox();
            lblSifre = new Label();
            txtSifre = new TextBox();
            btnGiris = new Button();
            btnIptal = new Button();
            SuspendLayout();
            //
            // lblKullaniciAdi
            //
            lblKullaniciAdi.AutoSize = true;
            lblKullaniciAdi.Location = new Point(20, 25);
            lblKullaniciAdi.Name = "lblKullaniciAdi";
            lblKullaniciAdi.Size = new Size(79, 15);
            lblKullaniciAdi.TabIndex = 0;
            lblKullaniciAdi.Text = "Kullanıcı Adı:";
            //
            // txtKullaniciAdi
            //
            txtKullaniciAdi.Location = new Point(115, 22);
            txtKullaniciAdi.MaxLength = 50;
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(180, 23);
            txtKullaniciAdi.TabIndex = 1;
            //
            // lblSifre
            //
            lblSifre.AutoSize = true;
            lblSifre.Location = new Point(20, 60);
            lblSifre.Name = "lblSifre";
            lblSifre.Size = new Size(33, 15);
            lblSifre.TabIndex = 2;
            lblSifre.Text = "Şifre:";
            //
            // txtSifre
            //
            txtSifre.Location = new Point(115, 57);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(180, 23);
            txtSifre.TabIndex = 3;
            txtSifre.UseSystemPasswordChar = true;
            //
            // btnGiris
            //
            btnGiris.Location = new Point(115, 100);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new Size(85, 30);
            btnGiris.TabIndex = 4;
            btnGiris.Text = "Giriş";
            btnGiris.UseVisualStyleBackColor = true;
            btnGiris.Click += btnGiris_Click;
            //
            // btnIptal
            //
            btnIptal.DialogResult = DialogResult.Cancel;
            btnIptal.Location = new Point(210, 100);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(85, 30);
            btnIptal.TabIndex = 5;
            btnIptal.Text = "Çıkış";
            btnIptal.UseVisualStyleBackColor = true;
            //
            // GirisForm
            //
            AcceptButton = btnGiris;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnIptal;
            ClientSize = new Size(320, 150);
            Controls.Add(btnIptal);
            Controls.Add(btnGiris);
            Controls.Add(txtSifre);
            Controls.Add(lblSifre);
            Controls.Add(txtKullaniciAdi);
            Controls.Add(lblKullaniciAdi);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GirisForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Frcistan 0.1 - Giriş";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblKullaniciAdi;
        private TextBox txtKullaniciAdi;
        private Label lblSifre;
        private TextBox txtSifre;
        private Button btnGiris;
        private Button btnIptal;
    }
}
