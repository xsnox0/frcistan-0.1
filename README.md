# Frcistan 0.1

Robot parçası (FRC/FTC) satan bir bayi için basit stok takip programı.
C# Windows Forms (.NET 8) + Entity Framework Core + MySQL (XAMPP).

## Özellikler
- Kullanıcı girişi (kullanıcılar veritabanındaki `Kullanicilar` tablosunda), iki rol:
  - **Admin**: ana ekran, ürün ekler/günceller/siler
  - **Personel**: ayrı ekran, ürünleri sadece görür; stoğu azalanları (5 ve altı) listeleyebilir,
    altta toplam stok ve stok değeri
- "Çıkış Yap" ile program baştan açılır, başka kullanıcıyla girilebilir
- Fiyatlar dolar ($) cinsinden
- Ürün ekleme, güncelleme, silme
- Kategori seçimi: kategoriler veritabanındaki `Kategoriler` tablosundan listeye gelir, elle yazılamaz
- Arama (Id, kategori, marka veya ürün adına göre)
- Sıralama (tablodaki sütun başlığına tıklayarak)
- Aynı marka + ürün adı tekrar girilirse uyarı ve "stoğa eklensin mi?" sorusu

## Çalıştırma
1. XAMPP Kontrol Paneli'nden **MySQL**'i başlatın.
2. `Frcistan.slnx` dosyasına çift tıklayıp Visual Studio'da açın ve F5'e basın.
   Veritabanı (`frcistan01`) ve tablolar yoksa program kendisi oluşturur.
3. Giriş ekranında **admin / 1234** (yönetici) veya **personel / 1234** (personel) ile girin.
4. İsterseniz veritabanını `veritabani.sql` dosyasıyla da (örnek ürünlerle birlikte) oluşturabilirsiniz.

Bağlantı ayarı `FrcistanContext.cs` dosyasının başında. Bu bilgisayarda MySQL 3307 portunda çalışıyor;
çoğu XAMPP kurulumunda port 3306'dır.

## Kullanıcı ve kategori ekleme
Program içinden kullanıcı veya kategori eklenmez; phpMyAdmin > `frcistan01` > SQL sekmesinden eklenir.
Rol `Admin` ya da `Personel` olur:

```sql
INSERT INTO Kullanicilar (KullaniciAdi, Sifre, Rol) VALUES ('ali', 'sifre123', 'Admin');
INSERT INTO Kullanicilar (KullaniciAdi, Sifre, Rol) VALUES ('ayse', 'sifre456', 'Personel');
INSERT INTO Kategoriler (Ad) VALUES ('Pnömatik');
```

## Kullanılan paketler (NuGet)
- `Microsoft.EntityFrameworkCore` 8.0.33
- `Microsoft.EntityFrameworkCore.Tools` 8.0.33 (Package Manager Console komutları için)
- `Pomelo.EntityFrameworkCore.MySql` 8.0.3 (MySQL/MariaDB sağlayıcısı)

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
| `Program.cs` | Programın başladığı yer (önce giriş ekranı, sonra role göre admin ya da personel ekranı) |
| `GirisForm.cs` | Kullanıcı giriş ekranı |
| `GirisForm.Designer.cs` | Giriş ekranının tasarımı |
| `Form1.cs` | Admin ekranı (ürün yönetimi) ve butonların kodu |
| `Form1.Designer.cs` | Admin ekranının tasarımı (Visual Studio tasarımcısı) |
| `PersonelForm.cs` | Personel ekranı (sadece görüntüleme) |
| `PersonelForm.Designer.cs` | Personel ekranının tasarımı |
| `Form1.resx` | Formun kaynak dosyası |
| `FrcistanContext.cs` | Entity Framework bağlamı (DbContext) ve bağlantı ayarı |
| `Urun.cs`, `Kategori.cs`, `Kullanici.cs` | Tablo sınıfları (modeller) |
| `Veritabani.cs` | Veritabanı işlemleri (ekle, güncelle, sil, giriş kontrolü) |
| `Properties\PublishProfiles\FolderProfile.pubxml` | Yayımlama ayarları (tek parça exe + otomatik kurulum) |
| `kurulum\Frcistan-0.1.iss` | Inno Setup kurulum betiği |
| `frcistan.ico` | Program ve kurulum simgesi (logo) |
| `kurulum\sihirbaz-*.bmp` | Kurulum sihirbazındaki logo resimleri |
| `kurulum\logo.png` | Logonun orijinal resmi |
| `veritabani.sql` | Veritabanı, kategoriler, admin kullanıcısı ve örnek veriler |
| `Frcistan-0.1-Tanitim.pdf` | Programın tanıtım broşürü |
