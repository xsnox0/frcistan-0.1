# Frcistan 0.1

Robot parçası (FRC/FTC) satan bir bayi için basit stok takip programı.
C# Windows Forms + MySQL (XAMPP).

## Özellikler
- Ürün ekleme, güncelleme, silme
- Arama (marka, SKU veya ürün adına göre)
- Sıralama (tablodaki sütun başlığına tıklayarak)
- Aynı SKU tekrar girilirse uyarı ve "stoğa eklensin mi?" sorusu

## Çalıştırma
1. XAMPP Kontrol Paneli'nden **MySQL**'i başlatın.
2. Programı açın (`dotnet run` veya Visual Studio'da F5).
   Veritabanı (`frcistan01`) ve tablo yoksa program kendisi oluşturur.
3. İsterseniz `veritabani.sql` dosyasını phpMyAdmin'de çalıştırıp örnek ürünleri ekleyin.

Bağlantı ayarı `Database.cs` dosyasının başında. Bu bilgisayarda MySQL 3307 portunda çalışıyor;
çoğu XAMPP kurulumunda port 3306'dır.

## Dosyalar
| Dosya | İçerik |
| --- | --- |
| `Form1.cs` | Ana ekran ve butonların kodu |
| `Form1.Designer.cs` | Ekran tasarımı |
| `Database.cs` | Veritabanı işlemleri (SQL komutları) |
| `veritabani.sql` | Veritabanı ve örnek veriler |
