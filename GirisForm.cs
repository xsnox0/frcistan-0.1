namespace Frcistan
{
    public partial class GirisForm : Form
    {
        public Kullanici GirisYapan;

        public GirisForm()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text.Trim() == "" || txtSifre.Text == "")
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş bırakılamaz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                GirisYapan = Veritabani.GirisYap(txtKullaniciAdi.Text.Trim(), txtSifre.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giriş yapılamadı.\n\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (GirisYapan == null)
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSifre.Clear();
                txtSifre.Focus();
                return;
            }

            DialogResult = DialogResult.OK;
        }
    }
}
