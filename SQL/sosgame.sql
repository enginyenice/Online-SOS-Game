-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Anamakine: localhost
-- Üretim Zamanı: 18 Haz 2020, 10:34:37
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

--
-- Tablo döküm verisi `davet`
--

INSERT INTO `davet` (`id`, `sahipID`, `misafirID`, `result`) VALUES
(38, 1, 2, 1),
(39, 1, 2, 1),
(40, 1, 2, 1),
(41, 1, 2, 1),
(42, 1, 2, 1),
(43, 1, 2, 1),
(44, 1, 2, 1),
(45, 2, 1, 1),
(46, 2, 1, 1),
(47, 2, 1, 1),
(48, 1, 2, 1),
(49, 1, 2, 1),
(50, 1, 2, 1),
(51, 1, 2, 1),
(52, 1, 2, 1),
(53, 1, 2, 1),
(54, 1, 2, 1),
(55, 2, 1, 1),
(56, 1, 2, 1),
(57, 1, 2, 1),
(58, 1, 2, 1),
(59, 2, 1, 1),
(60, 2, 1, 1),
(61, 1, 2, 1),
(62, 1, 2, 1),
(63, 1, 2, 1),
(64, 2, 1, 1),
(65, 1, 2, 1),
(66, 2, 1, 1),
(67, 1, 2, 1),
(68, 1, 2, 1),
(69, 1, 2, 1),
(70, 1, 2, 1),
(71, 1, 2, 1),
(72, 2, 1, 1),
(73, 2, 1, 1),
(74, 2, 1, 1),
(75, 2, 1, 1),
(76, 1, 2, 1),
(77, 1, 2, 1),
(78, 1, 2, 1),
(79, 1, 2, 1),
(80, 1, 2, 1),
(81, 1, 2, 1),
(82, 1, 2, 1),
(83, 1, 2, 1),
(84, 1, 2, 1),
(85, 1, 2, 1),
(86, 1, 2, 1),
(87, 1, 2, 1),
(88, 1, 2, 1),
(89, 1, 2, 1),
(90, 1, 2, 1),
(91, 1, 2, 1),
(92, 2, 1, 1),
(93, 1, 2, 1),
(94, 1, 2, 1),
(95, 1, 2, 1),
(96, 6, 7, 1),
(97, 6, 7, 1),
(98, 6, 7, 1),
(99, 6, 7, 1),
(100, 6, 7, 1),
(101, 6, 7, 1),
(102, 6, 7, 1),
(103, 6, 7, 1),
(104, 6, 7, 1),
(105, 6, 7, 1),
(106, 7, 6, 1),
(107, 6, 7, 1),
(108, 6, 7, 1),
(109, 6, 7, 1),
(110, 7, 6, 1),
(111, 6, 7, 1);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kullanici`
--

CREATE TABLE `kullanici` (
  `id` int(10) NOT NULL,
  `username` varchar(254) NOT NULL,
  `password` varchar(254) NOT NULL,
  `online` int(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `kullanici`
--

INSERT INTO `kullanici` (`id`, `username`, `password`, `online`) VALUES
(6, 'engin', '123456', 0),
(7, 'talha', '123456', 0);

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

--
-- Tablo döküm verisi `oyun`
--

INSERT INTO `oyun` (`id`, `SahipID`, `MisafirID`, `SahipPuan`, `MisafirPuan`, `OyunHaritasi`, `OyunDurumu`, `sira`) VALUES
(89, 1, 2, 1, 1, '[[1,1,1,0,0,0,0,0],[1,2,1,0,0,0,0,0],[0,1,1,0,0,0,0,0],[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0]]', 0, 1),
(90, 2, 1, 2, 0, '[[1,0,0,0,0,0,0,1],[0,2,0,0,0,0,2,0],[0,0,1,0,0,1,0,0],[0,0,0,0,2,0,0,0],[0,0,0,0,0,0,0,0],[0,0,1,0,0,1,0,0],[0,2,0,0,0,0,2,0],[1,0,0,0,0,0,0,1]]', 0, 2),
(91, 1, 2, 0, 0, '[[1,2,1,0,0,0,0,0],[0,0,2,0,0,0,0,0],[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0]]', 0, 1),
(92, 1, 2, 4, 1, '[[1,0,1,0,0,0,0,0],[0,2,0,0,0,0,0,0],[1,0,1,0,0,0,0,0],[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,1],[0,0,0,0,0,1,1,1],[0,0,0,0,0,1,2,1],[0,0,0,0,0,1,1,1]]', 0, 1),
(93, 1, 2, 2, 3, '[[0,0,0,0,0,1,1,1],[0,0,0,0,0,1,2,1],[0,0,0,0,0,1,1,1],[0,0,0,0,0,0,0,0],[2,0,0,0,0,0,0,0],[2,0,0,0,0,0,0,0],[2,0,0,0,0,0,0,0],[1,1,1,1,1,1,2,1]]', 0, 2),
(94, 6, 7, 1, 0, '[[1,2,1,0,0,0,0,0],[0,1,0,0,0,0,0,0],[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0]]', 0, 7),
(95, 6, 7, 17, 24, '[[1,1,1,1,1,1,2,1],[1,2,1,2,1,2,1,1],[1,2,1,1,2,1,1,1],[1,2,1,2,1,2,1,1],[1,2,1,1,1,2,1,1],[1,1,1,2,2,2,2,1],[1,2,1,1,2,1,1,2],[1,1,1,2,1,1,2,1]]', 0, 7),
(96, 6, 7, 18, 16, '[[1,1,2,1,2,1,2,1],[2,2,2,2,1,2,1,2],[1,1,2,1,2,1,2,1],[2,2,2,2,2,2,2,2],[1,1,1,1,1,1,2,1],[1,1,1,1,1,1,1,1],[1,1,1,1,1,2,2,2],[1,1,1,1,1,1,1,1]]', 0, 6),
(97, 6, 7, 0, 2, '[[1,1,1,1,1,1,1,1],[1,1,1,1,1,1,1,1],[1,1,1,1,1,1,1,1],[1,1,1,1,1,1,1,1],[1,1,1,1,1,1,1,1],[1,1,1,1,1,1,1,1],[2,1,1,1,1,1,1,1],[1,1,1,1,1,1,1,1]]', 0, 7),
(98, 6, 7, 50, 0, '[[1,1,1,1,1,1,1,1],[1,1,1,1,1,1,1,2],[2,2,2,2,2,2,2,1],[1,1,1,1,1,1,1,1],[2,2,2,2,2,2,2,2],[1,1,1,1,1,1,1,1],[1,1,2,1,2,1,2,1],[1,1,1,1,1,1,1,2]]', 0, 7),
(99, 6, 7, 0, 0, '', 0, 0),
(100, 6, 7, 52, 0, '[[1,1,1,1,1,1,1,1],[1,2,2,2,2,2,2,1],[1,2,1,1,1,1,2,1],[1,2,1,2,2,1,2,1],[1,2,1,2,2,1,2,1],[1,2,1,1,1,1,2,1],[1,2,2,2,2,2,2,1],[1,1,1,1,1,1,1,1]]', 0, 7),
(101, 6, 7, 52, 0, '[[1,1,1,1,1,1,1,1],[1,2,2,2,2,2,2,1],[1,2,1,1,1,1,2,1],[1,2,1,2,2,1,2,1],[1,2,1,2,2,1,2,1],[1,2,1,1,1,1,2,1],[1,2,2,2,2,2,2,1],[1,1,1,1,1,1,1,1]]', 0, 7),
(102, 6, 7, 0, 0, '', 0, 0),
(103, 6, 7, 0, 0, '', 0, 0),
(104, 7, 6, 0, 0, '', 0, 0),
(105, 6, 7, 0, 0, '', 0, 0),
(106, 6, 7, 0, 0, '', 0, 0),
(107, 6, 7, 0, 0, '', 0, 0),
(108, 7, 6, 0, 0, '', 0, 0),
(109, 6, 7, 0, 0, '', 0, 0);

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
-- Tablo döküm verisi `sohbet`
--

INSERT INTO `sohbet` (`id`, `oyunID`, `sahipID`, `misafirID`, `mesaj`) VALUES
(1, 102, 6, 6, ''),
(2, 0, 0, 7, 'engin :123123\n'),
(3, 0, 6, 0, 'engin :123123\n'),
(4, 103, 6, 6, 'engin :123\nengin :123\nengin :321\n'),
(5, 104, 7, 6, 'talha :Birinci\nengin :İkinci\n'),
(6, 105, 6, 7, 'talha :Selam\nengin :Naber\n'),
(7, 106, 6, 7, 'talha :Naber Hacı\nengin :İyidir senden naber\ntalha :Bende iyiyim\nengin :İyidir senden naber\nengin :İyidir senden naber\nengin :İyidir senden naber\nengin :İyidir senden naber\nengin :İyidir senden naber\nengin :İyidir senden naber\nengin :İyidir senden naber\nengin :İyidir senden naber\nengin :İyidir senden naber\nengin :İyidir senden naber\nengin :İyidir senden naber\nengin :İyidir senden naber\nengin :İyidir senden naber\nengin :İyidir senden naber\nengin :İyidir senden naber\nengin :İyidir senden naber\nengin :İyidir senden naber\n'),
(8, 107, 6, 7, 'engin :astalha :sa\n'),
(9, 108, 7, 6, 'talha :xxx\ntalha :iyi\ntalha :as\nengin :sa\nengin :asd\nengin :as\nengin :Naber\nengin :Naber\nengin :çokiyi\nengin :ttt\n'),
(10, 109, 6, 7, 'engin :asdasd\nengin :asdasd\nengin :321\nengin :123\nengin :heyy\n');

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=112;

--
-- Tablo için AUTO_INCREMENT değeri `kullanici`
--
ALTER TABLE `kullanici`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- Tablo için AUTO_INCREMENT değeri `oyun`
--
ALTER TABLE `oyun`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=110;

--
-- Tablo için AUTO_INCREMENT değeri `sohbet`
--
ALTER TABLE `sohbet`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
