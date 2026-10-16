using System.Data;
using MySql.Data.MySqlClient;

namespace Frcistan;

// Veritabanı ile ilgili bütün işlemler bu sınıfta.
internal static class Database
{
    // Bu bilgisayardaki XAMPP MySQL'i 3307 portunda çalışıyor; kullanıcı root, parola yok.
    // Başka bir bilgisayarda port genelde 3306'dır, burayı değiştirmek yeterli.
    private const string ServerConnection = "Server=localhost;Port=3307;Uid=root;Pwd=;";
    private const string ConnectionString = ServerConnection + "Database=frcistan01;";

    // Veritabanı ve tablo yoksa oluşturur.
    public static void CreateIfNotExists()
    {
        using (var connection = new MySqlConnection(ServerConnection))
        {
            connection.Open();
            var command = new MySqlCommand("CREATE DATABASE IF NOT EXISTS frcistan01 CHARACTER SET utf8mb4", connection);
            command.ExecuteNonQuery();
        }

        using (var connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            string sql = @"CREATE TABLE IF NOT EXISTS Products (
                               Id INT AUTO_INCREMENT PRIMARY KEY,
                               Brand VARCHAR(50) NOT NULL,
                               Sku VARCHAR(50) NOT NULL UNIQUE,
                               Name VARCHAR(100) NOT NULL,
                               Quantity INT NOT NULL DEFAULT 0,
                               Price DECIMAL(10,2) NOT NULL DEFAULT 0
                           )";
            var command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }
    }

    // Ürünleri getirir. Arama kutusu boşsa hepsi gelir.
    public static DataTable GetProducts(string search)
    {
        using (var connection = new MySqlConnection(ConnectionString))
        {
            string sql = "SELECT Id, Brand, Sku, Name, Quantity, Price FROM Products " +
                         "WHERE Brand LIKE @search OR Sku LIKE @search OR Name LIKE @search " +
                         "ORDER BY Brand, Sku";
            var adapter = new MySqlDataAdapter(sql, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@search", "%" + search + "%");

            var table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }

    // Aynı SKU'lu ürün varsa Id'sini, yoksa -1 döndürür.
    public static int FindIdBySku(string sku)
    {
        using (var connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            var command = new MySqlCommand("SELECT Id FROM Products WHERE Sku = @sku", connection);
            command.Parameters.AddWithValue("@sku", sku);

            object result = command.ExecuteScalar();
            if (result == null)
                return -1;
            return Convert.ToInt32(result);
        }
    }

    public static void Add(string brand, string sku, string name, int quantity, decimal price)
    {
        using (var connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            var command = new MySqlCommand(
                "INSERT INTO Products (Brand, Sku, Name, Quantity, Price) VALUES (@brand, @sku, @name, @quantity, @price)",
                connection);
            command.Parameters.AddWithValue("@brand", brand);
            command.Parameters.AddWithValue("@sku", sku);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@quantity", quantity);
            command.Parameters.AddWithValue("@price", price);
            command.ExecuteNonQuery();
        }
    }

    public static void Update(int id, string brand, string sku, string name, int quantity, decimal price)
    {
        using (var connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            var command = new MySqlCommand(
                "UPDATE Products SET Brand = @brand, Sku = @sku, Name = @name, Quantity = @quantity, Price = @price WHERE Id = @id",
                connection);
            command.Parameters.AddWithValue("@brand", brand);
            command.Parameters.AddWithValue("@sku", sku);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@quantity", quantity);
            command.Parameters.AddWithValue("@price", price);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
    }

    public static void Delete(int id)
    {
        using (var connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            var command = new MySqlCommand("DELETE FROM Products WHERE Id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
    }

    // Aynı ürün tekrar girilince yeni kayıt açmak yerine stoğu artırır.
    public static void AddStock(int id, int quantity)
    {
        using (var connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            var command = new MySqlCommand("UPDATE Products SET Quantity = Quantity + @quantity WHERE Id = @id", connection);
            command.Parameters.AddWithValue("@quantity", quantity);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
    }
}
