using System.Data;
using MySql.Data.MySqlClient;

namespace Frcistan
{
    // veritabanı işlemleri
    internal static class Veritabani
    {
        // XAMPP bende 3307 portunda calisiyor. baska pc'de genelde 3306
        private const string SunucuBaglantisi = "Server=localhost;Port=3307;Uid=root;Pwd=;";
        private const string BaglantiCumlesi = SunucuBaglantisi + "Database=frcistan01;";

        // veritabani ve tablo yoksa olusturur
        public static void Hazirla()
        {
            // once veritabani
            using (var conn = new MySqlConnection(SunucuBaglantisi))
            {
                conn.Open();
                var cmd = new MySqlCommand("CREATE DATABASE IF NOT EXISTS frcistan01 CHARACTER SET utf8mb4", conn);
                cmd.ExecuteNonQuery();
            }

            using (var conn = new MySqlConnection(BaglantiCumlesi))
            {
                conn.Open();

                // eski surumde tablo ingilizceydi (Products), varsa adlarini turkce yapiyoruz
                if (Say(conn, "TABLES", "Products", null) > 0 && Say(conn, "TABLES", "Urunler", null) == 0)
                {
                    if (Say(conn, "COLUMNS", "Products", "Sku") > 0)
                        new MySqlCommand("ALTER TABLE Products DROP COLUMN Sku", conn).ExecuteNonQuery();

                    new MySqlCommand("ALTER TABLE Products RENAME TO Urunler", conn).ExecuteNonQuery();
                    new MySqlCommand("ALTER TABLE Urunler " +
                        "CHANGE Brand Marka VARCHAR(50) NOT NULL, " +
                        "CHANGE Name UrunAdi VARCHAR(100) NOT NULL, " +
                        "CHANGE Quantity Adet INT NOT NULL DEFAULT 0, " +
                        "CHANGE Price Fiyat DECIMAL(10,2) NOT NULL DEFAULT 0", conn).ExecuteNonQuery();
                }

                string sql = @"CREATE TABLE IF NOT EXISTS Urunler (
                    Id INT AUTO_INCREMENT PRIMARY KEY,
                    Marka VARCHAR(50) NOT NULL,
                    UrunAdi VARCHAR(100) NOT NULL,
                    Adet INT NOT NULL DEFAULT 0,
                    Fiyat DECIMAL(10,2) NOT NULL DEFAULT 0
                )";
                var cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }

        // information_schema'da tablo (ya da sutun) var mi diye bakar
        private static int Say(MySqlConnection conn, string neresi, string tablo, string sutun)
        {
            string sql = "SELECT COUNT(*) FROM information_schema." + neresi +
                         " WHERE TABLE_SCHEMA = 'frcistan01' AND TABLE_NAME = @tablo";
            if (sutun != null)
                sql += " AND COLUMN_NAME = @sutun";

            var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@tablo", tablo);
            cmd.Parameters.AddWithValue("@sutun", sutun);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static DataTable UrunleriGetir(string arama)
        {
            using (var conn = new MySqlConnection(BaglantiCumlesi))
            {
                string sql = "SELECT Id, Marka, UrunAdi, Adet, Fiyat FROM Urunler " +
                             "WHERE Marka LIKE @arama OR UrunAdi LIKE @arama OR Id LIKE @arama " +
                             "ORDER BY Id";
                var da = new MySqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@arama", "%" + arama + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // yeni urun eklenince verilecek id (AUTO_INCREMENT degeri)
        // MAX(Id)+1 ile karsilastiriyoruz, AUTO_INCREMENT bazen eski deger donebiliyor
        public static int SiradakiId()
        {
            using (var conn = new MySqlConnection(BaglantiCumlesi))
            {
                conn.Open();
                string sql = "SELECT GREATEST(IFNULL((SELECT AUTO_INCREMENT FROM information_schema.TABLES " +
                             "WHERE TABLE_SCHEMA = 'frcistan01' AND TABLE_NAME = 'Urunler'), 1), " +
                             "(SELECT IFNULL(MAX(Id), 0) + 1 FROM Urunler))";
                var cmd = new MySqlCommand(sql, conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // ayni marka + isimde urun varsa id'yi dondurur yoksa -1
        public static int IdBul(string marka, string urunAdi)
        {
            using (var conn = new MySqlConnection(BaglantiCumlesi))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT Id FROM Urunler WHERE Marka = @marka AND UrunAdi = @urunAdi", conn);
                cmd.Parameters.AddWithValue("@marka", marka);
                cmd.Parameters.AddWithValue("@urunAdi", urunAdi);

                object sonuc = cmd.ExecuteScalar();
                if (sonuc == null)
                    return -1;

                return Convert.ToInt32(sonuc);
            }
        }

        public static void Ekle(string marka, string urunAdi, int adet, decimal fiyat)
        {
            using (var conn = new MySqlConnection(BaglantiCumlesi))
            {
                conn.Open();
                string sql = "INSERT INTO Urunler (Marka, UrunAdi, Adet, Fiyat) " +
                             "VALUES (@marka, @urunAdi, @adet, @fiyat)";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@marka", marka);
                cmd.Parameters.AddWithValue("@urunAdi", urunAdi);
                cmd.Parameters.AddWithValue("@adet", adet);
                cmd.Parameters.AddWithValue("@fiyat", fiyat);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Guncelle(int id, string marka, string urunAdi, int adet, decimal fiyat)
        {
            using (var conn = new MySqlConnection(BaglantiCumlesi))
            {
                conn.Open();
                string sql = "UPDATE Urunler SET Marka=@marka, UrunAdi=@urunAdi, " +
                             "Adet=@adet, Fiyat=@fiyat WHERE Id=@id";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@marka", marka);
                cmd.Parameters.AddWithValue("@urunAdi", urunAdi);
                cmd.Parameters.AddWithValue("@adet", adet);
                cmd.Parameters.AddWithValue("@fiyat", fiyat);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Sil(int id)
        {
            using (var conn = new MySqlConnection(BaglantiCumlesi))
            {
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM Urunler WHERE Id=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        // ayni urun tekrar girilirse yeni satir acmiyoruz, adedi ustune ekliyoruz
        public static void StokEkle(int id, int adet)
        {
            using (var conn = new MySqlConnection(BaglantiCumlesi))
            {
                conn.Open();
                var cmd = new MySqlCommand("UPDATE Urunler SET Adet = Adet + @adet WHERE Id=@id", conn);
                cmd.Parameters.AddWithValue("@adet", adet);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
