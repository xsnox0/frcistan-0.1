using System.Data;
using Microsoft.EntityFrameworkCore;

namespace Frcistan
{
    internal static class Veritabani
    {
        // veritabani yoksa olusturur, bos tablolara ilk kayitlari ekler
        public static void Hazirla()
        {
            using (var db = new FrcistanContext())
            {
                db.Database.EnsureCreated();

                if (!db.Kategoriler.Any())
                {
                    string[] kategoriler = { "Motor", "Motor Sürücü", "Swerve Modülü", "Sensör", "Elektronik", "Mekanik Parça", "Diğer" };
                    foreach (string ad in kategoriler)
                        db.Kategoriler.Add(new Kategori { Ad = ad });
                }

                if (!db.Kullanicilar.Any())
                {
                    db.Kullanicilar.Add(new Kullanici { KullaniciAdi = "admin", Sifre = "1234", Rol = "Admin" });
                    db.Kullanicilar.Add(new Kullanici { KullaniciAdi = "personel", Sifre = "1234", Rol = "Personel" });
                }

                db.SaveChanges();
            }
        }

        public static Kullanici GirisYap(string kullaniciAdi, string sifre)
        {
            using (var db = new FrcistanContext())
            {
                var kullanici = db.Kullanicilar.FirstOrDefault(k => k.KullaniciAdi == kullaniciAdi);

                // sifreyi burada kontrol ediyoruz, MySQL'de abc ile ABC ayni sayiliyor
                if (kullanici == null || kullanici.Sifre != sifre)
                    return null;

                return kullanici;
            }
        }

        public static List<Kategori> KategorileriGetir()
        {
            using (var db = new FrcistanContext())
            {
                return db.Kategoriler.OrderBy(k => k.Ad).ToList();
            }
        }

        // DataTable donduruyoruz cunku tablo basligina tiklayinca siralama List ile calismiyor
        public static DataTable UrunleriGetir(string arama)
        {
            using (var db = new FrcistanContext())
            {
                var urunler = db.Urunler.Include(u => u.Kategori)
                    .Where(u => u.Marka.Contains(arama) || u.UrunAdi.Contains(arama) ||
                                u.Kategori.Ad.Contains(arama) || u.Id.ToString().Contains(arama))
                    .OrderBy(u => u.Id)
                    .ToList();

                DataTable dt = new DataTable();
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("KategoriId", typeof(int));
                dt.Columns.Add("Kategori", typeof(string));
                dt.Columns.Add("Marka", typeof(string));
                dt.Columns.Add("UrunAdi", typeof(string));
                dt.Columns.Add("Adet", typeof(int));
                dt.Columns.Add("Fiyat", typeof(decimal));

                foreach (var u in urunler)
                    dt.Rows.Add(u.Id, u.KategoriId, u.Kategori.Ad, u.Marka, u.UrunAdi, u.Adet, u.Fiyat);

                return dt;
            }
        }

        // yeni urun eklenince verilecek id
        public static int SiradakiId()
        {
            using (var db = new FrcistanContext())
            {
                string sql = "SELECT CAST(AUTO_INCREMENT AS SIGNED) AS Value FROM information_schema.TABLES " +
                             "WHERE TABLE_SCHEMA = 'frcistan01' AND TABLE_NAME = 'Urunler'";
                return (int)db.Database.SqlQueryRaw<long>(sql).AsEnumerable().First();
            }
        }

        // ayni marka + isimde urun varsa id'yi dondurur yoksa -1
        public static int IdBul(string marka, string urunAdi)
        {
            using (var db = new FrcistanContext())
            {
                var urun = db.Urunler.FirstOrDefault(u => u.Marka == marka && u.UrunAdi == urunAdi);
                if (urun == null)
                    return -1;

                return urun.Id;
            }
        }

        public static void Ekle(int kategoriId, string marka, string urunAdi, int adet, decimal fiyat)
        {
            using (var db = new FrcistanContext())
            {
                Urun urun = new Urun();
                urun.KategoriId = kategoriId;
                urun.Marka = marka;
                urun.UrunAdi = urunAdi;
                urun.Adet = adet;
                urun.Fiyat = fiyat;

                db.Urunler.Add(urun);
                db.SaveChanges();
            }
        }

        public static void Guncelle(int id, int kategoriId, string marka, string urunAdi, int adet, decimal fiyat)
        {
            using (var db = new FrcistanContext())
            {
                Urun urun = db.Urunler.Find(id);
                urun.KategoriId = kategoriId;
                urun.Marka = marka;
                urun.UrunAdi = urunAdi;
                urun.Adet = adet;
                urun.Fiyat = fiyat;
                db.SaveChanges();
            }
        }

        public static void Sil(int id)
        {
            using (var db = new FrcistanContext())
            {
                Urun urun = db.Urunler.Find(id);
                db.Urunler.Remove(urun);
                db.SaveChanges();
            }
        }

        // ayni urun tekrar girilirse yeni satir acmiyoruz, adedi ustune ekliyoruz
        public static void StokEkle(int id, int adet)
        {
            using (var db = new FrcistanContext())
            {
                Urun urun = db.Urunler.Find(id);
                urun.Adet += adet;
                db.SaveChanges();
            }
        }
    }
}
