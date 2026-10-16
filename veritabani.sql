-- Frcistan 0.1 veritabanı
-- phpMyAdmin > SQL sekmesine yapıştırıp çalıştırılabilir.
-- (Program açılırken veritabanı ve tablo yoksa kendisi de oluşturur.)

CREATE DATABASE IF NOT EXISTS frcistan01 CHARACTER SET utf8mb4;
USE frcistan01;

CREATE TABLE IF NOT EXISTS Products (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Brand VARCHAR(50) NOT NULL,
    Sku VARCHAR(50) NOT NULL UNIQUE,
    Name VARCHAR(100) NOT NULL,
    Quantity INT NOT NULL DEFAULT 0,
    Price DECIMAL(10,2) NOT NULL DEFAULT 0
);

-- Örnek ürünler (fiyatlar örnektir)
INSERT IGNORE INTO Products (Brand, Sku, Name, Quantity, Price) VALUES
('REV Robotics', 'REV-21-1650', 'NEO Brushless Motor V1.1', 8, 0),
('REV Robotics', 'REV-11-2158', 'SPARK MAX Motor Controller', 10, 0),
('REV Robotics', 'REV-21-3005', 'MAXSwerve Module', 4, 0),
('AndyMark', 'AM-0255', 'CIM Motor', 6, 0),
('WCP', 'WCP-0940', 'Kraken X60 Brushless Motor', 8, 0),
('Swerve Drive Specialties', 'SDS-MK4I-L2', 'MK4i Swerve Module L2', 4, 0);
