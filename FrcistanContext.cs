using Microsoft.EntityFrameworkCore;

namespace Frcistan
{
    public class FrcistanContext : DbContext
    {
        // XAMPP bende 3307 portunda calisiyor. baska pc'de genelde 3306
        const string Baglanti = "Server=localhost;Port=3307;Database=frcistan01;Uid=root;Pwd=;";

        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Baglanti, ServerVersion.AutoDetect(Baglanti));
        }
    }
}
