namespace Frcistan
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            try
            {
                Veritabani.Hazirla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına bağlanılamadı. XAMPP'ta MySQL açık mı?\n\n" + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GirisForm giris = new GirisForm();
            if (giris.ShowDialog() != DialogResult.OK)
                return;

            // admin urunleri yonetir, personel sadece listeyi gorur
            if (giris.GirisYapan.Rol == "Admin")
                Application.Run(new Form1(giris.GirisYapan));
            else
                Application.Run(new PersonelForm(giris.GirisYapan));
        }
    }
}
