-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1:3306
-- Üretim Zamanı: 02 Oca 2023, 21:20:08
-- Sunucu sürümü: 5.7.36
-- PHP Sürümü: 7.4.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `manav`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kullanici`
--

DROP TABLE IF EXISTS `kullanici`;
CREATE TABLE IF NOT EXISTS `kullanici` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `isim` varchar(70) COLLATE utf8mb4_unicode_ci NOT NULL,
  `sifre` varchar(70) COLLATE utf8mb4_unicode_ci NOT NULL,
  `kayit-tarih` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `kullanici`
--

INSERT INTO `kullanici` (`id`, `isim`, `sifre`, `kayit-tarih`) VALUES
(1, 'admin', '123', '2023-01-02 18:59:55'),
(9, 'kadir', '123qwe', '2023-01-03 00:11:43');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `urun`
--

DROP TABLE IF EXISTS `urun`;
CREATE TABLE IF NOT EXISTS `urun` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `isim` varchar(70) COLLATE utf8mb4_unicode_ci NOT NULL,
  `barkod` varchar(250) COLLATE utf8mb4_unicode_ci NOT NULL,
  `fiyat` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `stok` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=62 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `urun`
--

INSERT INTO `urun` (`id`, `isim`, `barkod`, `fiyat`, `stok`) VALUES
(54, 'ANANAS', '7', '34.99', '10'),
(49, 'ELMA', '2', '14.99', '111'),
(46, 'ITHAL NAR', '5', '25.99', '999'),
(45, 'ÜZÜM', '3', '15.75', '1'),
(51, 'KARPUZ', '4', '66.99', '2'),
(52, 'PIRASA', '6', '7.98', '1500'),
(47, 'MUZ', '1', '19.99', '123'),
(56, 'PORTAKAL', '8', '15.75', '960');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
