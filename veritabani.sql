-- Frcistan 0.1 veritabanı
-- phpMyAdmin > SQL sekmesine yapıştırıp çalıştırılabilir.
-- (Program açılırken veritabanı yoksa kendisi de oluşturur.)

CREATE DATABASE IF NOT EXISTS frcistan01 CHARACTER SET utf8mb4;
USE frcistan01;

CREATE TABLE IF NOT EXISTS Kategoriler (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Ad VARCHAR(50) NOT NULL
);

CREATE TABLE IF NOT EXISTS Kullanicilar (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    KullaniciAdi VARCHAR(50) NOT NULL,
    Sifre VARCHAR(64) NOT NULL,
    Rol VARCHAR(20) NOT NULL
);

CREATE TABLE IF NOT EXISTS Urunler (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    KategoriId INT NOT NULL,
    Marka VARCHAR(50) NOT NULL,
    UrunAdi VARCHAR(100) NOT NULL,
    Adet INT NOT NULL,
    Fiyat DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (KategoriId) REFERENCES Kategoriler (Id)
);

INSERT INTO Kategoriler (Ad) VALUES
('Motor'), ('Motor Sürücü'), ('Swerve Modülü'), ('Sensör'), ('Elektronik'), ('Mekanik Parça'), ('Diğer');

-- Rol: Admin (ürün ekler/siler) veya Personel (sadece görür)
INSERT INTO Kullanicilar (KullaniciAdi, Sifre, Rol) VALUES
('admin', '1234', 'Admin'),
('personel', '1234', 'Personel');

-- Örnek ürünler (fiyatlar dolar)
INSERT INTO Urunler (KategoriId, Marka, UrunAdi, Adet, Fiyat) VALUES
(1, 'REV Robotics', 'NEO Brushless Motor V1.1', 8, 0),
(2, 'REV Robotics', 'SPARK MAX Motor Controller', 10, 0),
(3, 'REV Robotics', 'MAXSwerve Module', 4, 0),
(1, 'AndyMark', 'CIM Motor', 6, 0),
(1, 'WCP', 'Kraken X60 Brushless Motor', 8, 0),
(3, 'Swerve Drive Specialties', 'MK4i Swerve Module L2', 4, 0);
