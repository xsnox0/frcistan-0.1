using System.Data;

namespace Frcistan
{
    // personel sadece urunleri gorebilir, ekleme silme yok
    public partial class PersonelForm : Form
    {
        public PersonelForm(Kullanici kullanici)
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            Text += " - Kullanıcı: " + kullanici.KullaniciAdi;
            lblHosgeldin.Text = "Hoş geldin, " + kullanici.KullaniciAdi + ". Bu ekranda ürünleri sadece görüntüleyebilirsiniz.";
        }

        private void PersonelForm_Load(object sender, EventArgs e)
        {
            UrunleriYukle();
        }

        void UrunleriYukle()
        {
            DataTable dt;
            try
            {
                dt = Veritabani.UrunleriGetir(txtArama.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünler yüklenemedi.\n\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (chkAzalan.Checked)
                dt.DefaultView.RowFilter = "Adet <= 5";

            dgvUrunler.DataSource = dt;
            dgvUrunler.Columns["KategoriId"].Visible = false;
            dgvUrunler.Columns["Id"].FillWeight = 40;
            dgvUrunler.Columns["UrunAdi"].HeaderText = "Ürün Adı";
            dgvUrunler.Columns["UrunAdi"].FillWeight = 200;
            dgvUrunler.Columns["Fiyat"].HeaderText = "Fiyat ($)";
            dgvUrunler.Columns["Fiyat"].DefaultCellStyle.Format = "N2";

            int toplamAdet = 0;
            decimal toplamDeger = 0;
            foreach (DataRowView satir in dt.DefaultView)
            {
                toplamAdet += (int)satir["Adet"];
                toplamDeger += (int)satir["Adet"] * (decimal)satir["Fiyat"];
            }

            lblOzet.Text = "Toplam ürün: " + dt.DefaultView.Count + "     Toplam stok: " + toplamAdet + " adet" +
                           "     Stok değeri: " + toplamDeger.ToString("N2") + " $";
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            UrunleriYukle();
        }

        private void chkAzalan_CheckedChanged(object sender, EventArgs e)
        {
            UrunleriYukle();
        }

        private void dgvUrunler_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvUrunler.ClearSelection();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
