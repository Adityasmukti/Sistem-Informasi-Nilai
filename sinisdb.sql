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
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4;

/*Data for the table `m_akses` */

insert  into `m_akses`(`id_akses`,`nama_akses`,`ket_akses`) values 
(1,'SUPER ADMIN','All Grandted Acces'),
(2,'ADMIN CHAT','Admin Iphone'),
(3,'ADMIN KOMPUTER','Admin Komputer'),
(4,'PACKER','Packer'),
(5,'CS','Costumer Service'),
(6,'MANAGER','manager'),
(7,'FINANCIAL','Bagian untuk mengurus keuangan yang masuk dan keluar');

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
) ENGINE=InnoDB AUTO_INCREMENT=70 DEFAULT CHARSET=utf8mb4;

/*Data for the table `m_user` */

insert  into `m_user`(`id_user`,`id_akses`,`kode_ref`,`username`,`password`,`device`,`ppic`,`hapus`) values 
(1,1,NULL,'adityasmukti','c5a4e7e6882845ea7bb4d9462868219b','D8CB8A149BDC',1,'N'),
(12,2,NULL,'Firda','35daca8af4e1b0f9afa3f28243f2eabb','D8CB8A149BDC',1,'Y'),
(13,2,NULL,'admin6','18088d7b2a8eb8075fd4c12d9fb7e787','D8CB8A149BDC',1,'N'),
(14,2,NULL,'devi','b0baf0313cc1f4e46c9ff6472c5c0995','D8CB8A149BDC',1,'N'),
(15,3,NULL,'ceker','94636d1e282358814470eb9859f95f68','D8CB8A149BDC',1,'N'),
(16,2,NULL,'Dia','3354045a397621cd92406f1f98cde292','D8CB8A149BDC',1,'N'),
(17,2,NULL,'admin5','0147e10fc29898717aca0293cb822237','D8CB8A149BDC',1,'Y'),
(18,4,NULL,'rendinj','0692949239af02b0660510e2de473269','D8CB8A149BDC',1,'N'),
(19,4,NULL,'angelinastok','bc3596198e49c49eccd7abe633c19c48','D8CB8A149BDC',1,'N'),
(20,4,NULL,'angelinastok2','cc652f48badc16dee00155356d05a4fa','D8CB8A149BDC',1,'Y'),
(21,4,NULL,'angelinastok3','82905317b1753a965d521c51e1b9f809','D8CB8A149BDC',1,'Y'),
(22,4,NULL,'angelinastok4','a65fb99ac96e56e36821218dfb23eeb1','D8CB8A149BDC',1,'Y'),
(23,4,NULL,'angelinapacker5','7acf473c6932c5ccaf71acccc7ab5c1d','D8CB8A149BDC',1,'Y'),
(24,4,NULL,'angelinapacker6','1a46e0d450e2eb4939184dec535326c4','D8CB8A149BDC',1,'Y'),
(25,4,NULL,'angelinastock7','bd414715816f60a0a1d317f949649428','D8CB8A149BDC',1,'Y'),
(26,4,NULL,'angelinastok8','64df9fe506966348bd8ebcd23168e8d0','D8CB8A149BDC',1,'Y'),
(27,4,NULL,'angelinastok6','1a46e0d450e2eb4939184dec535326c4','D8CB8A149BDC',1,'N'),
(28,2,NULL,'admin6','827ccb0eea8a706c4c34a16891f84e7b','D8CB8A149BDC',1,'Y'),
(29,2,NULL,'finasa','bc3596198e49c49eccd7abe633c19c48','D8CB8A149BDC',1,'N'),
(30,2,NULL,'admin8','d42326110ade36815dcff10ee83c805a','D8CB8A149BDC',1,'N'),
(31,2,NULL,'heniluciana','f263ee1462d516d8099e8ea34972f834','D8CB8A149BDC',1,'N'),
(32,2,NULL,'ben10','d60b7655ab07b4b03dcf2ecc1af14e7f','D8CB8A149BDC',1,'N'),
(33,5,NULL,'cs3','4e3d821e1e6207e6acd0e02bc3099e5a','D8CB8A149BDC',1,'N'),
(34,7,NULL,'finance','d60b7655ab07b4b03dcf2ecc1af14e7f','D8CB8A149BDC',1,'N'),
(35,5,NULL,'cs2','d42326110ade36815dcff10ee83c805a','18D6C7A3DA3F',1,'N'),
(36,5,NULL,'cs1','b0baf0313cc1f4e46c9ff6472c5c0995','18D6C7A3DA3F',1,'N'),
(37,3,NULL,'untukline','bc3596198e49c49eccd7abe633c19c48','00155D203C65',1,'N'),
(38,4,NULL,'packerhandie','0b0f137f17ac10944716020b018f8126','76E5F9530A02',1,'N'),
(39,2,NULL,'admin11','4e3d821e1e6207e6acd0e02bc3099e5a','18D6C7A3DA3F',1,'Y'),
(40,2,NULL,'sheila','e2b71642392a4910f1b5cb63bb447203','00155D203C65',1,'N'),
(41,2,NULL,'risha','7acf473c6932c5ccaf71acccc7ab5c1d','00155D203C65',1,'N'),
(42,2,NULL,'anis','e040e72da4f36299fd61bc464a7c6b43','1831BF72B8CA',1,'Y'),
(43,1,NULL,'Dinams','b3f40bcc5914eb52fd9e3e8175ad755f','2CFDA1ADB5CD',1,'Y'),
(44,2,NULL,'miahilmi','3fec27b731e7b14e537fecce168e48ca','1831BF72B905',1,'Y'),
(45,1,NULL,'Handie.k','2659b9711239c8de7bc896de8a6a9293','76E5F9530A02',1,'N'),
(46,2,NULL,'rendinurjaman','0692949239af02b0660510e2de473269','4CEDFB03F62C',1,'N'),
(47,2,NULL,'nendenrivana','b85f5b6a8944edb4fbf18d82b95ab517','1831BF712336',1,'Y'),
(48,1,NULL,'santipratiwi','c78abd1f736b426a926cb366c3bb40dc','1831BF72B8CA',1,'N'),
(49,2,NULL,'sitiwulanpurnamasari','a87bcf310c4fdf2a80f2f3d97f1f9424','4CEDFB03F62C',48,'Y'),
(50,2,NULL,'dewinuzanah','62b476e462e5b87cb2423b7b5e4e511e','ACE2D35402D0',1,'Y'),
(51,2,NULL,'SITIROBIAH','1947d89a7ed2ed8be6044b1f855205b6','1831BF72B905',1,'N'),
(52,2,NULL,'OKTAVIYANTINH','27fe9fb66aee4f940cf31334d4a477c6','1831BF72B8B6',1,'Y'),
(53,2,NULL,'amandamaulida ','8fb551604a1ca71f8ff76928512ef08b','ACE2D35402D0',48,'Y'),
(54,2,NULL,'tiaramardiana','a567d67ce9b4136ac5e4899ef913c362','4CEDFB03F62C',48,'N'),
(55,2,NULL,'sariyulianti','bbad4114af19f6c94499a6c4820e13b3','1831BF72B918',48,'Y'),
(56,2,NULL,'anisafauziaharifin','a8e404443f4edea9337a04fa3bf192b1','1831BF712336',48,'Y'),
(57,2,NULL,'ninanirmala','7b0153a9fc30217641c2c0c7574d6e1e','1831BF72B8B6',48,'N'),
(58,5,NULL,'sitipupusapuroh','716dcc93b69df6c6d547a17ccafb790a','4CEDFB03F62C',48,'N'),
(59,2,NULL,'santi1739','c78abd1f736b426a926cb366c3bb40dc','4CEDFB03F614',48,'Y'),
(60,5,NULL,'maja','4e3d821e1e6207e6acd0e02bc3099e5a','503EAA9FE7A5',1,'N'),
(61,2,NULL,'fitriyaninurawalia','13a08bc67d814cc8c4eb246ff60c4784','503EAA9FE7A5',1,'N'),
(62,1,NULL,'septinasalsabila','5ec829debe54b19a5f78d9a65b900a39','76E5F9530A02',48,'N'),
(63,3,NULL,'santip','c78abd1f736b426a926cb366c3bb40dc','ACE2D35402D0',48,'N'),
(64,4,NULL,'santi','c78abd1f736b426a926cb366c3bb40dc','502B73D05BE8',48,'Y'),
(65,2,NULL,'santipratiwi39','c78abd1f736b426a926cb366c3bb40dc','502B73D05BE8',48,'N'),
(66,2,NULL,'sariyulianti','bc3596198e49c49eccd7abe633c19c48','503EAA9FE7A5',1,'N'),
(67,2,NULL,'agista','bc3596198e49c49eccd7abe633c19c48','40B076488671',1,'N'),
(68,2,NULL,'mira','bc3596198e49c49eccd7abe633c19c48','40B076488671',1,'N'),
(69,2,NULL,'azmi','bc3596198e49c49eccd7abe633c19c48','40B076488671',1,'N');

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
