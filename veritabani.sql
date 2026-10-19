-- Frcistan 0.1 veritabanı
-- phpMyAdmin > SQL sekmesine yapıştırıp çalıştırılabilir.
-- (Program açılırken veritabanı ve tablo yoksa kendisi de oluşturur.)

CREATE DATABASE IF NOT EXISTS frcistan01 CHARACTER SET utf8mb4;
USE frcistan01;

CREATE TABLE IF NOT EXISTS Urunler (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Marka VARCHAR(50) NOT NULL,
    UrunAdi VARCHAR(100) NOT NULL,
    Adet INT NOT NULL DEFAULT 0,
    Fiyat DECIMAL(10,2) NOT NULL DEFAULT 0
);

-- Örnek ürünler (fiyatlar örnektir). Bir kere çalıştırın, ikinci kez çalışırsa ürünler tekrar eklenir.
INSERT INTO Urunler (Marka, UrunAdi, Adet, Fiyat) VALUES
('REV Robotics', 'NEO Brushless Motor V1.1', 8, 0),
('REV Robotics', 'SPARK MAX Motor Controller', 10, 0),
('REV Robotics', 'MAXSwerve Module', 4, 0),
('AndyMark', 'CIM Motor', 6, 0),
('WCP', 'Kraken X60 Brushless Motor', 8, 0),
('Swerve Drive Specialties', 'MK4i Swerve Module L2', 4, 0);
