-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Anamakine: localhost
-- Üretim Zamanı: 18 Haz 2020, 14:41:37
-- Sunucu sürümü: 8.0.17
-- PHP Sürümü: 7.3.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `sosgame`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `davet`
--

CREATE TABLE `davet` (
  `id` int(11) NOT NULL,
  `sahipID` int(11) NOT NULL,
  `misafirID` int(11) NOT NULL,
  `result` int(11) NOT NULL DEFAULT '0' COMMENT '0- Beklemede 1-Kabul 2-Red'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kullanici`
--

CREATE TABLE `kullanici` (
  `id` int(10) NOT NULL,
  `username` varchar(254) NOT NULL,
  `password` varchar(254) NOT NULL,
  `online` int(1) NOT NULL DEFAULT '0',
  `galibiyet` int(11) NOT NULL DEFAULT '0',
  `malubiyet` int(11) NOT NULL DEFAULT '0',
  `avaraj` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `oyun`
--

CREATE TABLE `oyun` (
  `id` int(11) NOT NULL,
  `SahipID` int(11) NOT NULL,
  `MisafirID` int(11) NOT NULL,
  `SahipPuan` int(11) NOT NULL,
  `MisafirPuan` int(11) NOT NULL,
  `OyunHaritasi` text CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OyunDurumu` int(11) NOT NULL,
  `sira` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `sohbet`
--

CREATE TABLE `sohbet` (
  `id` int(11) NOT NULL,
  `oyunID` int(11) NOT NULL,
  `sahipID` int(11) NOT NULL,
  `misafirID` int(11) NOT NULL,
  `mesaj` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `davet`
--
ALTER TABLE `davet`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `kullanici`
--
ALTER TABLE `kullanici`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `oyun`
--
ALTER TABLE `oyun`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `sohbet`
--
ALTER TABLE `sohbet`
  ADD PRIMARY KEY (`id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `davet`
--
ALTER TABLE `davet`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=120;

--
-- Tablo için AUTO_INCREMENT değeri `kullanici`
--
ALTER TABLE `kullanici`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- Tablo için AUTO_INCREMENT değeri `oyun`
--
ALTER TABLE `oyun`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=116;

--
-- Tablo için AUTO_INCREMENT değeri `sohbet`
--
ALTER TABLE `sohbet`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
