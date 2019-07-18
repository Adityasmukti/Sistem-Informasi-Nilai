/*
SQLyog Ultimate v12.4.3 (64 bit)
MySQL - 10.1.40-MariaDB : Database - sindb
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`sindb` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `sindb`;

/*Table structure for table `m_akses` */

DROP TABLE IF EXISTS `m_akses`;

CREATE TABLE `m_akses` (
  `id_akses` int(11) NOT NULL AUTO_INCREMENT,
  `nama_akses` varchar(20) CHARACTER SET utf8 DEFAULT NULL,
  `ket_akses` mediumtext CHARACTER SET utf8,
  PRIMARY KEY (`id_akses`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4;

/*Data for the table `m_akses` */

insert  into `m_akses`(`id_akses`,`nama_akses`,`ket_akses`) values 
(1,'TATA USAHA','All Grandted Acces'),
(2,'WALI KELAS','Wali kelas'),
(3,'GURU','Guru'),
(4,'SISWA','Siswa');

/*Table structure for table `m_guru` */

DROP TABLE IF EXISTS `m_guru`;

CREATE TABLE `m_guru` (
  `kode_guru` varchar(15) NOT NULL,
  `nidn` varchar(40) DEFAULT NULL,
  `nik` varchar(50) DEFAULT NULL,
  `nosk` varchar(50) DEFAULT NULL,
  `namaguru` varchar(200) DEFAULT NULL,
  `nohp` varchar(100) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `alamat` text,
  `masuk` date DEFAULT NULL,
  `status` varchar(50) DEFAULT NULL,
  `jeniskelamin` enum('L','P') DEFAULT NULL,
  `gelardepan` varchar(50) DEFAULT NULL,
  `gelarbelakang` varchar(50) DEFAULT NULL,
  `tempatlahir` varchar(50) DEFAULT NULL,
  `tgllahir` date DEFAULT NULL,
  `jabatanstruktural` varchar(50) DEFAULT NULL,
  `jabatanfungsional` varchar(50) DEFAULT NULL,
  `golongan` varchar(10) DEFAULT NULL,
  `hapus` enum('N','Y') NOT NULL DEFAULT 'N',
  PRIMARY KEY (`kode_guru`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `m_guru` */

/*Table structure for table `m_siswa` */

DROP TABLE IF EXISTS `m_siswa`;

CREATE TABLE `m_siswa` (
  `kode_siswa` varchar(15) NOT NULL,
  `nis` varchar(50) DEFAULT NULL,
  `namasiswa` varchar(200) DEFAULT NULL,
  `alamat` text,
  `ayah` varchar(200) DEFAULT NULL,
  `ibu` varchar(200) DEFAULT NULL,
  `kontak` varchar(20) DEFAULT NULL,
  `status` varchar(20) DEFAULT NULL,
  `keterangan` text,
  `angkatan` varchar(5) DEFAULT NULL,
  `jeniskelamin` enum('L','P') DEFAULT NULL,
  `tempatlahir` varchar(100) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `hapus` enum('Y','N') NOT NULL DEFAULT 'N',
  PRIMARY KEY (`kode_siswa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `m_siswa` */

/*Table structure for table `m_user` */

DROP TABLE IF EXISTS `m_user`;

CREATE TABLE `m_user` (
  `id_user` int(11) NOT NULL AUTO_INCREMENT,
  `id_akses` int(11) DEFAULT NULL,
  `kode_ref` varchar(15) CHARACTER SET utf8 DEFAULT NULL,
  `username` varchar(30) CHARACTER SET latin1 DEFAULT NULL,
  `password` varchar(100) CHARACTER SET latin1 DEFAULT NULL,
  `device` varchar(20) CHARACTER SET latin1 DEFAULT NULL,
  `ppic` int(11) DEFAULT NULL,
  `hapus` enum('Y','N') CHARACTER SET latin1 DEFAULT 'N',
  PRIMARY KEY (`id_user`),
  KEY `id_akses` (`id_akses`),
  CONSTRAINT `m_user_ibfk_1` FOREIGN KEY (`id_akses`) REFERENCES `m_akses` (`id_akses`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;

/*Data for the table `m_user` */

insert  into `m_user`(`id_user`,`id_akses`,`kode_ref`,`username`,`password`,`device`,`ppic`,`hapus`) values 
(1,1,'1','admin','c5a4e7e6882845ea7bb4d9462868219b',NULL,1,'N');

/*Table structure for table `r_matapelajaran` */

DROP TABLE IF EXISTS `r_matapelajaran`;

CREATE TABLE `r_matapelajaran` (
  `kodepelajaran` varchar(30) NOT NULL,
  `namapelajaran` varchar(200) DEFAULT NULL,
  `status` varchar(25) DEFAULT NULL,
  `hapus` enum('Y','N') DEFAULT 'N',
  PRIMARY KEY (`kodepelajaran`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `r_matapelajaran` */

/*Table structure for table `r_settings` */

DROP TABLE IF EXISTS `r_settings`;

CREATE TABLE `r_settings` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nama_pangaturan` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin DEFAULT NULL,
  `pengaturan` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin DEFAULT NULL,
  `nilai` text CHARACTER SET utf8mb4 COLLATE utf8mb4_bin,
  `type` enum('string','int','DateTime','Color','long') CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL DEFAULT 'string',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=utf8mb4;

/*Data for the table `r_settings` */

insert  into `r_settings`(`id`,`nama_pangaturan`,`pengaturan`,`nilai`,`type`) values 
(2,'Warna Panel Judul','colorpaneljudul','FF8080','Color'),
(3,'Pesan Status Strip','statusstripmessage','QVRFTElFUiBBTkdFTElOQSBCT1VUSVFVRQ==','string'),
(4,'Warna Utama Status Strip','statusstripmaincolor','FF8080','Color'),
(5,'Warna Aksen Status Strip','statusstripaksencolor','FFFFFF','Color'),
(6,'Warna Label Judul','colorlabeljudul','FFFFFF','Color'),
(8,'Warna Aksen Data Grid','datagridviewaksencolor','69C7FA','Color'),
(9,'Warna Utama Tombol','buttonmaincolor','FF8080','Color'),
(10,'Warna Aksen Tombol','buttonaksencolor','FFFFFF','Color'),
(13,'Warna Foreground','forecolor','000000','Color'),
(14,'Warna Background','backcolor','FFFFFF','Color'),
(15,'Batas Waktu Order','expiretime','100','int'),
(16,'Warna Cetak','printcolor','000000','Color'),
(17,'Jawaban Admin Total','replaymessage','QWZ3YW4sIG9yZGVyIG1iYSBhdGFzIG5hbWEgW05BTUFdIHRlbGFoIGthbWkgcHJvc2VzOgpkZW5nYW4ga29kZSBwZXNhbiBbQkFSQ09ERV0gcGFkYSBbVEdMXSBvbGVoIGFkbWluIFtBRE1JTl0sCltSSU5DSUFOXQoKZGVuZ2FuIHJpbmNpYW4gcHJvZHVrIDoKW0lURU1TXQoKZGFuIGJlcmF0IFtCRVJBVF0sIG9uZ2tpciBbT05HS0lSXS4KVG90YWwgW0lOVk9JQ0VdIChtb2hvbiBkaWxlYmloa2FuIGFuZ2thIFtOT10gYWdhciBtdWRhaCBjZWsgdHJhbnNmZXJhbm55YSB5YSkg8J+YigpTaWxhaGthbiB0YXJuc2ZlciBrZSByZWsgQkNBIDM0ODk4OTgxMTEgYW4gQW5nZWxpbmEsIChub21vciByZWtlbmluZyBpbmkga2h1c3VzIHVudHVrIHRyYW5zYWtzaSB2aWEgTElORSB5YSwgYmVyYmVkYSBkYXJpIG5vbW9yIHJla2VuaW5nIG9yZGVyIHZpYSBXRUJTSVRFKSAKTWFrc2ltYWwgdHJhbnNmZXIgMXgxMiBqYW0sIGppa2EgbGViaWggZGljYW5jZWwgb3RvbWF0aXMg8J+Zj/CfmY8KSmlrYSBzdWRhaCB0cmYgdGFucGEgcGVybHUga29uZmlybWFzaSBrYW1pIHN1ZGFoIGJpc2EgY2VrIG1lbGFsdWkgbm9tb3Igb3JkZXJhbiBkaSBibGtnIHRvdGFsYW4sIHNlY2FyYSBvdG9tYXRpcyBiYXJhbmcgc2VnZXJhIGthbWkgcHJvc2VzJmtpcmltLCBzeXVrcmFuIPCfmY/wn5mPCg==','string'),
(18,'Jawaban Admin Detail','detailmessage','bWJhIGRhcGF0IApbSVRFTVNdIApkZW5nYW4gYmVyYXQgW0JFUkFUXSBvbmdraXIgW09OR0tJUl0=','string'),
(19,'Keterangan Kode Keep','kodekeep','S2VlcCBUZWxhaCBkaWd1bmFrYW4gZGVuZ2FuIGtvZGUgW2tvZGVrZWVwXQ==','string'),
(20,'Default Kurir','defaultkurir','JNE','string'),
(21,'Default Service','defaultservice','REG','string'),
(22,'Api Key Raja Ongkir','apikeyrajaongkir','cbb0fa7a1340837829607b5fabbd8924','string'),
(23,'ID Kecamatan Asal','originsubdistrict','1423','int'),
(24,'ID Kota Asal','origincity','104','int'),
(25,'Type Asal','origintype','subdistrict','string'),
(33,'Persentase Harga Penjualan','persentaseharga','','int'),
(34,'Jumlah Baris per halaman','divs','25','int'),
(35,'Link Ceking Order','cekorder','aHR0cDovL2F0ZWxpZXJhbmdlbGluYS5lc3kuZXMvc28/aWQ9','string'),
(36,'Batas Waktu Pembatalan Order','canceltime','14','string'),
(37,'Pengaturan Switch Ukurang','switchproduk','1','int'),
(38,'Batas Waktu Selesai','selesaitime','100','int'),
(39,'Get Stock','getstock','0','int');

/*Table structure for table `r_tahunajaran` */

DROP TABLE IF EXISTS `r_tahunajaran`;

CREATE TABLE `r_tahunajaran` (
  `id_tahun` int(11) NOT NULL AUTO_INCREMENT,
  `nama_tahunajaran` varchar(25) CHARACTER SET latin1 DEFAULT NULL,
  PRIMARY KEY (`id_tahun`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `r_tahunajaran` */

/*Table structure for table `tb_jadwal` */

DROP TABLE IF EXISTS `tb_jadwal`;

CREATE TABLE `tb_jadwal` (
  `kode_jadwal` varchar(15) NOT NULL,
  `kode_guru` varchar(15) DEFAULT NULL,
  `kode_kelas` varchar(15) DEFAULT NULL,
  `tahunajaran` varchar(5) DEFAULT NULL,
  `keterangan` text,
  `tanggal` date DEFAULT NULL,
  PRIMARY KEY (`kode_jadwal`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tb_jadwal` */

/*Table structure for table `tb_ruangan` */

DROP TABLE IF EXISTS `tb_ruangan`;

CREATE TABLE `tb_ruangan` (
  `kode_ruangan` varchar(15) NOT NULL,
  `kode_kelas` varchar(15) DEFAULT NULL,
  `kode_siswa` varchar(15) DEFAULT NULL,
  `kode_guru` varchar(15) DEFAULT NULL,
  `tahunajaran` varchar(20) DEFAULT NULL,
  `keterangan` text,
  `tanggal` datetime DEFAULT NULL,
  PRIMARY KEY (`kode_ruangan`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tb_ruangan` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
