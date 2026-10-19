# Frcistan 0.1

Robot parçası (FRC/FTC) satan bir bayi için basit stok takip programı.
C# Windows Forms + MySQL (XAMPP).

## Özellikler
- Ürün ekleme, güncelleme, silme
- Arama (Id, marka veya ürün adına göre)
- Sıralama (tablodaki sütun başlığına tıklayarak)
- Aynı marka + ürün adı tekrar girilirse uyarı ve "stoğa eklensin mi?" sorusu

## Çalıştırma
1. XAMPP Kontrol Paneli'nden **MySQL**'i başlatın.
2. `Frcistan.slnx` dosyasına çift tıklayıp Visual Studio'da açın ve F5'e basın.
   Veritabanı (`frcistan01`) ve `Urunler` tablosu yoksa program kendisi oluşturur.
3. İsterseniz `veritabani.sql` dosyasını phpMyAdmin'de çalıştırıp örnek ürünleri ekleyin.

Bağlantı ayarı `Veritabani.cs` dosyasının başında. Bu bilgisayarda MySQL 3307 portunda çalışıyor;
çoğu XAMPP kurulumunda port 3306'dır.

## Kurulum dosyası (setup)
`kurulum-cikti\Frcistan-0.1-Kurulum.exe` programı başka bir bilgisayara kurar.
.NET kurulu olması gerekmez; sadece XAMPP'ta MySQL'in açık olması yeterli.

Kurulum dosyasını yeniden üretmek için Visual Studio'da Solution Explorer'da projeye sağ tıklayın →
**Yayımla** → `FolderProfile` → **Yayımla**. Önce program `publish\Frcistan.exe` olarak yayımlanır,
hemen ardından Inno Setup otomatik çalışıp `kurulum-cikti\Frcistan-0.1-Kurulum.exe` dosyasını üretir.
(Komut satırından: `dotnet publish Frcistan.csproj -p:PublishProfile=FolderProfile`)
Bunun için bilgisayarda Inno Setup 6 kurulu olmalı.

## Dosyalar
| Dosya | İçerik |
| --- | --- |
| `Frcistan.slnx` | Visual Studio çözüm dosyası (bunu açın) |
| `Program.cs` | Programın başladığı yer |
| `Form1.cs` | Ana ekran ve butonların kodu |
| `Form1.Designer.cs` | Ekran tasarımı (Visual Studio tasarımcısı) |
| `Form1.resx` | Formun kaynak dosyası |
| `Veritabani.cs` | Veritabanı işlemleri (SQL komutları) |
| `Properties\PublishProfiles\FolderProfile.pubxml` | Yayımlama ayarları (tek parça exe + otomatik kurulum) |
| `kurulum\Frcistan-0.1.iss` | Inno Setup kurulum betiği |
| `frcistan.ico` | Program ve kurulum simgesi (logo) |
| `kurulum\sihirbaz-*.bmp` | Kurulum sihirbazındaki logo resimleri |
| `kurulum\logo.png` | Logonun orijinal resmi |
| `veritabani.sql` | Veritabanı ve örnek veriler |
| `Frcistan-0.1-Tanitim.pdf` | Programın tanıtım broşürü |
