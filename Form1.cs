using MySql.Data.MySqlClient;

namespace Frcistan
{
    public partial class Form1 : Form
    {
        int seciliId = -1; // secili urun yoksa -1

        public Form1()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath); // pencerede de exe'nin logosu gozuksun
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Veritabani.Hazirla();
                UrunleriYukle();
                FormuTemizle();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Veritabanına bağlanılamadı. XAMPP'ta MySQL açık mı?\n\n" + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void UrunleriYukle()
        {
            dgvUrunler.DataSource = Veritabani.UrunleriGetir(txtArama.Text.Trim());

            // Id, Marka, Adet sutun adlari zaten duzgun, digerlerine baslik veriyoruz
            dgvUrunler.Columns["Id"].FillWeight = 40;
            dgvUrunler.Columns["UrunAdi"].HeaderText = "Ürün Adı";
            dgvUrunler.Columns["Fiyat"].HeaderText = "Fiyat (TL)";
            dgvUrunler.Columns["Fiyat"].DefaultCellStyle.Format = "N2";
            dgvUrunler.Columns["UrunAdi"].FillWeight = 200;

            lblToplam.Text = "Toplam ürün: " + dgvUrunler.Rows.Count;
        }

        bool AlanlariKontrolEt()
        {
            if (cmbMarka.Text.Trim() == "" || txtUrunAdi.Text.Trim() == "")
            {
                MessageBox.Show("Marka ve ürün adı boş bırakılamaz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (!AlanlariKontrolEt())
                return;

            string marka = cmbMarka.Text.Trim();
            string urunAdi = txtUrunAdi.Text.Trim();

            try
            {
                // ayni marka ve isimde urun varsa yeni kayit acmak yerine stoga ekleyelim mi diye soruyoruz
                int varOlanId = Veritabani.IdBul(marka, urunAdi);
                if (varOlanId != -1)
                {
                    var cevap = MessageBox.Show("Bu ürün zaten kayıtlı (Id: " + varOlanId + ").\nGirdiğiniz adet mevcut stoğa eklensin mi?",
                        "Aynı ürün var", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (cevap == DialogResult.Yes)
                    {
                        Veritabani.StokEkle(varOlanId, (int)numAdet.Value);
                        UrunleriYukle();
                        FormuTemizle();
                    }
                    return;
                }

                Veritabani.Ekle(marka, urunAdi, (int)numAdet.Value, numFiyat.Value);
                UrunleriYukle();
                FormuTemizle();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Kayıt eklenemedi.\n\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (seciliId == -1)
            {
                MessageBox.Show("Önce listeden bir ürün seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!AlanlariKontrolEt())
                return;

            string marka = cmbMarka.Text.Trim();
            string urunAdi = txtUrunAdi.Text.Trim();

            try
            {
                // baska bir urunu ayni marka/isme cevirmesin
                int digerId = Veritabani.IdBul(marka, urunAdi);
                if (digerId != -1 && digerId != seciliId)
                {
                    MessageBox.Show("Bu marka ve isimde başka bir ürün var (Id: " + digerId + ").", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Veritabani.Guncelle(seciliId, marka, urunAdi, (int)numAdet.Value, numFiyat.Value);
                UrunleriYukle();
                FormuTemizle();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Kayıt güncellenemedi.\n\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (seciliId == -1)
            {
                MessageBox.Show("Önce listeden bir ürün seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(txtUrunAdi.Text + " silinsin mi?", "Silme Onayı",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                Veritabani.Sil(seciliId);
                UrunleriYukle();
                FormuTemizle();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Kayıt silinemedi.\n\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            FormuTemizle();
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            try
            {
                UrunleriYukle();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Arama yapılamadı.\n\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUrunler_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvUrunler.ClearSelection(); // ilk satir kendiliginden secili gelmesin
        }

        // tablodan satira tiklaninca bilgileri kutulara yaz
        private void dgvUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // basliga tiklandi

            var satir = dgvUrunler.Rows[e.RowIndex];
            seciliId = Convert.ToInt32(satir.Cells["Id"].Value);
            txtId.Text = seciliId.ToString();
            cmbMarka.Text = satir.Cells["Marka"].Value.ToString();
            txtUrunAdi.Text = satir.Cells["UrunAdi"].Value.ToString();
            numAdet.Value = Convert.ToInt32(satir.Cells["Adet"].Value);
            numFiyat.Value = Convert.ToDecimal(satir.Cells["Fiyat"].Value);
        }

        void FormuTemizle()
        {
            seciliId = -1;
            cmbMarka.Text = "";
            txtUrunAdi.Clear();
            numAdet.Value = 0;
            numFiyat.Value = 0;
            dgvUrunler.ClearSelection();
            cmbMarka.Focus();

            // yeni urune verilecek id'yi veritabanindan cekip gosteriyoruz
            try
            {
                txtId.Text = Veritabani.SiradakiId().ToString();
            }
            catch (MySqlException)
            {
                txtId.Clear();
            }
        }
    }
}
