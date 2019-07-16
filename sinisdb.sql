/*
SQLyog Ultimate v12.4.3 (64 bit)
MySQL - 10.1.28-MariaDB : Database - db_sins
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`db_sins` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `db_sins`;

/*Table structure for table `tm_guru` */

DROP TABLE IF EXISTS `tm_guru`;

CREATE TABLE `tm_guru` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `gr_nik` varchar(40) DEFAULT NULL,
  `gr_nama` varchar(200) DEFAULT NULL,
  `gr_alamat` text,
  `gr_ket` text,
  `gr_masuk` date DEFAULT NULL,
  `gr_create` datetime DEFAULT CURRENT_TIMESTAMP,
  `gr_update` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `gr_status` varchar(10) DEFAULT NULL,
  `gr_del` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tm_guru` */

/*Table structure for table `tm_matapelajaran` */

DROP TABLE IF EXISTS `tm_matapelajaran`;

CREATE TABLE `tm_matapelajaran` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `mp_kode` varchar(30) DEFAULT NULL,
  `mp_nama` varchar(200) DEFAULT NULL,
  `mp_ket` text,
  `mp_status` varchar(30) DEFAULT NULL,
  `mp_del` tinyint(4) DEFAULT NULL,
  `mp_create` datetime DEFAULT CURRENT_TIMESTAMP,
  `mp_update` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tm_matapelajaran` */

/*Table structure for table `tm_siswa` */

DROP TABLE IF EXISTS `tm_siswa`;

CREATE TABLE `tm_siswa` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `sw_nis` varchar(50) DEFAULT NULL,
  `sw_nama` varchar(200) DEFAULT NULL,
  `sw_alamat` text,
  `sw_ayah` varchar(200) DEFAULT NULL,
  `sw_ibu` varchar(200) DEFAULT NULL,
  `sw_kontak` varchar(20) DEFAULT NULL,
  `sw_create` datetime DEFAULT CURRENT_TIMESTAMP,
  `sw_update` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `sw_status` varchar(20) DEFAULT NULL,
  `sw_del` tinyint(4) DEFAULT NULL,
  `sw_ket` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tm_siswa` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
