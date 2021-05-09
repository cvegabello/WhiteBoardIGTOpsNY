-- MySQL dump 10.13  Distrib 5.7.11, for Win64 (x86_64)
--
-- Host: localhost    Database: boardinfony
-- ------------------------------------------------------
-- Server version	5.7.11-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `history_draw`
--

DROP TABLE IF EXISTS `history_draw`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `history_draw` (
  `numDraw` int(11) NOT NULL,
  `numCDC` int(11) NOT NULL,
  `nomProduct` varchar(45) DEFAULT NULL,
  `Jackpot` double NOT NULL,
  `Winners` varchar(45) DEFAULT NULL,
  `timeDraw` varchar(45) DEFAULT NULL,
  `codProduct` int(11) NOT NULL,
  `dayWeekName` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`numDraw`,`numCDC`,`codProduct`,`Jackpot`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `history_draw`
--

LOCK TABLES `history_draw` WRITE;
/*!40000 ALTER TABLE `history_draw` DISABLE KEYS */;
INSERT INTO `history_draw` VALUES (154,10929,'LIFE',0,'0 | 0','0',5,'Thursday'),(155,10933,'LIFE',0,'0 | 0','0',5,'Monday'),(156,10936,'LIFE',0,'0 | 0','0',5,'Thursday'),(157,10940,'LIFE',0,'0 | 0','0',5,'Monday'),(199,11087,'LIFE',0,'0 | 0',NULL,5,'Monday'),(200,11090,'LIFE',0,'0 | 0',NULL,5,'Thursday'),(201,11094,'LIFE',0,'0 | 0',NULL,5,'Monday'),(202,11097,'LIFE',0,'0 | 0',NULL,5,'Thursday'),(203,11101,'LIFE',0,'0 | 0',NULL,5,'Monday'),(204,11104,'LIFE',0,'1 | 0',NULL,5,'Thursday'),(205,11108,'LIFE',0,'0 | 0',NULL,5,'Monday'),(206,11111,'LIFE',0,'0 | 0',NULL,5,'Thursday'),(207,11115,'LIFE',0,'0 | 0',NULL,5,'Monday'),(208,11118,'LIFE',0,'0 | 0',NULL,5,'Thursday'),(209,11122,'LIFE',0,'0 | 0',NULL,5,'Monday'),(210,11125,'LIFE',0,'0 | 0',NULL,5,'Thursday'),(211,11129,'LIFE',0,'0 | 0',NULL,5,'Monday'),(610,10931,'PWRB',0,'0','0',10,'Saturday'),(611,10935,'PWRB',0,'0','0',10,'Wednesday'),(612,10938,'PWRB',164000000,'0','0',10,'Saturday'),(654,11085,'PWRB',40000000,'0',NULL,10,'Saturday'),(654,11085,'PWRB',282000000,'0',NULL,10,'Saturday'),(655,11089,'PWRB',60000000,'0',NULL,10,'Wednesday'),(656,11092,'PWRB',40000000,'0',NULL,10,'Saturday'),(657,11096,'PWRB',60000000,'0',NULL,10,'Wednesday'),(658,11099,'PWRB',70000000,'0',NULL,10,'Saturday'),(659,11103,'PWRB',80000000,'0',NULL,10,'Wednesday'),(660,11106,'PWRB',90000000,'0',NULL,10,'Saturday'),(661,11110,'PWRB',100000000,'0',NULL,10,'Wednesday'),(662,11113,'PWRB',110000000,'0',NULL,10,'Saturday'),(663,11117,'PWRB',123000000,'0',NULL,10,'Wednesday'),(664,11120,'PWRB',153000000,'0',NULL,10,'Saturday'),(665,11124,'PWRB',153000000,'0',NULL,10,'Wednesday'),(666,11127,'PWRB',169000000,'0',NULL,10,'Saturday'),(667,11131,'PWRB',184000000,'0',NULL,10,'Wednesday'),(1415,10930,'BIGG',0,'0','0',1,'Friday'),(1416,10934,'BIGG',0,'0','0',1,'Tuesday'),(1417,10937,'BIGG',66000000,'0','0',1,'Friday'),(1460,11088,'BIGG',74000000,'0',NULL,1,'Tuesday'),(1460,11088,'BIGG',174000000,'0',NULL,1,'Tuesday'),(1461,11091,'BIGG',161000000,'0',NULL,1,'Friday'),(1462,11095,'BIGG',203000000,'0',NULL,1,'Tuesday'),(1463,11098,'BIGG',174000000,'0',NULL,1,'Friday'),(1464,11102,'BIGG',203000000,'0',NULL,1,'Tuesday'),(1465,11105,'BIGG',235000000,'0',NULL,1,'Friday'),(1466,11109,'BIGG',235000000,'0',NULL,1,'Tuesday'),(1467,11112,'BIGG',251000000,'0',NULL,1,'Friday'),(1468,11116,'BIGG',260000000,'0',NULL,1,'Tuesday'),(1469,11119,'BIGG',280000000,'0',NULL,1,'Friday'),(1470,11123,'BIGG',293000000,'0',NULL,1,'Tuesday'),(1471,11126,'BIGG',310000000,'0',NULL,1,'Friday'),(1472,11130,'BIGG',333000000,'0',NULL,1,'Tuesday'),(2967,10931,'LOTO',0,'0','0',6,'Saturday'),(2968,10935,'LOTO',0,'0','0',6,'Wednesday'),(2969,10938,'LOTO',6500000,'0','0',6,'Saturday'),(3011,11085,'LOTO',20900000,'0',NULL,6,'Saturday'),(3011,11085,'LOTO',22500000,'0',NULL,6,'Saturday'),(3012,11089,'LOTO',23300000,'0',NULL,6,'Wednesday'),(3013,11092,'LOTO',22500000,'0',NULL,6,'Saturday'),(3014,11096,'LOTO',23300000,'0',NULL,6,'Wednesday'),(3015,11099,'LOTO',23700000,'0',NULL,6,'Saturday'),(3016,11103,'LOTO',24100000,'1',NULL,6,'Wednesday'),(3017,11106,'LOTO',2000000,'0',NULL,6,'Saturday'),(3018,11110,'LOTO',2300000,'0',NULL,6,'Wednesday'),(3019,11113,'LOTO',2600000,'0',NULL,6,'Saturday'),(3020,11117,'LOTO',2900000,'0',NULL,6,'Wednesday'),(3021,11120,'LOTO',3500000,'0',NULL,6,'Saturday'),(3022,11124,'LOTO',3500000,'0',NULL,6,'Wednesday'),(3023,11127,'LOTO',3800000,'0',NULL,6,'Saturday'),(3024,11131,'LOTO',4100000,'0',NULL,6,'Wednesday'),(6816,10929,'CSH5',0,'1','0',2,'Thursday'),(6817,10930,'CSH5',0,'1','0',2,'Friday'),(6818,10931,'CSH5',0,'1','0',2,'Saturday'),(6819,10932,'CSH5',0,'2','0',2,'Sunday'),(6820,10933,'CSH5',0,'1','0',2,'Monday'),(6821,10934,'CSH5',0,'0','0',2,'Tuesday'),(6822,10935,'CSH5',0,'2','0',2,'Wednesday'),(6823,10936,'CSH5',0,'1','0',2,'Thursday'),(6824,10937,'CSH5',0,'0','0',2,'Friday'),(6825,10938,'CSH5',0,'1','0',2,'Saturday'),(6826,10939,'CSH5',0,'0','0',2,'Sunday'),(6827,10940,'CSH5',0,'2','0',2,'Monday'),(6972,11085,'CSH5',0,'2',NULL,2,'Saturday'),(6973,11086,'CSH5',0,'1',NULL,2,'Sunday'),(6974,11087,'CSH5',0,'0',NULL,2,'Monday'),(6975,11088,'CSH5',0,'1',NULL,2,'Tuesday'),(6976,11089,'CSH5',0,'3',NULL,2,'Wednesday'),(6977,11090,'CSH5',0,'1',NULL,2,'Thursday'),(6978,11091,'CSH5',0,'0',NULL,2,'Friday'),(6979,11092,'CSH5',0,'0',NULL,2,'Saturday'),(6980,11093,'CSH5',0,'0',NULL,2,'Sunday'),(6981,11094,'CSH5',0,'1',NULL,2,'Monday'),(6982,11095,'CSH5',0,'2',NULL,2,'Tuesday'),(6983,11096,'CSH5',0,'0',NULL,2,'Wednesday'),(6984,11097,'CSH5',0,'1',NULL,2,'Thursday'),(6985,11098,'CSH5',0,'1',NULL,2,'Friday'),(6986,11099,'CSH5',0,'0',NULL,2,'Saturday'),(6987,11100,'CSH5',0,'2',NULL,2,'Sunday'),(6988,11101,'CSH5',0,'0',NULL,2,'Monday'),(6989,11102,'CSH5',0,'2',NULL,2,'Tuesday'),(6990,11103,'CSH5',0,'1',NULL,2,'Wednesday'),(6991,11104,'CSH5',0,'1',NULL,2,'Thursday'),(6992,11105,'CSH5',0,'0',NULL,2,'Friday'),(6993,11106,'CSH5',0,'0',NULL,2,'Saturday'),(6994,11107,'CSH5',0,'1',NULL,2,'Sunday'),(6995,11108,'CSH5',0,'2',NULL,2,'Monday'),(6996,11109,'CSH5',0,'3',NULL,2,'Tuesday'),(6997,11110,'CSH5',0,'2',NULL,2,'Wednesday'),(6998,11111,'CSH5',0,'0',NULL,2,'Thursday'),(6999,11112,'CSH5',0,'1',NULL,2,'Friday'),(7000,11113,'CSH5',0,'2',NULL,2,'Saturday'),(7001,11114,'CSH5',0,'2',NULL,2,'Sunday'),(7002,11115,'CSH5',0,'3',NULL,2,'Monday'),(7003,11116,'CSH5',0,'0',NULL,2,'Tuesday'),(7004,11117,'CSH5',0,'0',NULL,2,'Wednesday'),(7005,11118,'CSH5',0,'1',NULL,2,'Thursday'),(7006,11119,'CSH5',0,'1',NULL,2,'Friday'),(7007,11120,'CSH5',0,'1',NULL,2,'Saturday'),(7008,11121,'CSH5',0,'1',NULL,2,'Sunday'),(7009,11122,'CSH5',0,'3',NULL,2,'Monday'),(7010,11123,'CSH5',0,'3',NULL,2,'Tuesday'),(7011,11124,'CSH5',0,'1',NULL,2,'Wednesday'),(7012,11125,'CSH5',0,'0',NULL,2,'Thursday'),(7013,11126,'CSH5',0,'4',NULL,2,'Friday'),(7014,11127,'CSH5',0,'4',NULL,2,'Saturday'),(7015,11128,'CSH5',0,'1',NULL,2,'Sunday'),(7016,11129,'CSH5',0,'1',NULL,2,'Monday'),(7017,11130,'CSH5',0,'3',NULL,2,'Tuesday'),(7018,11131,'CSH5',0,'2',NULL,2,'Wednesday');
/*!40000 ALTER TABLE `history_draw` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hostsystemstbl`
--

DROP TABLE IF EXISTS `hostsystemstbl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `hostsystemstbl` (
  `idHostSystemsTbl` smallint(6) unsigned NOT NULL AUTO_INCREMENT,
  `primaryHost` int(11) DEFAULT NULL,
  `secondaryHost` int(11) DEFAULT NULL,
  `spare1` int(11) DEFAULT NULL,
  `spare2` int(11) DEFAULT NULL,
  `spare3` int(11) DEFAULT NULL,
  `dateday` date DEFAULT NULL,
  `updateDate` datetime DEFAULT NULL,
  `updateUser` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idHostSystemsTbl`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hostsystemstbl`
--

LOCK TABLES `hostsystemstbl` WRITE;
/*!40000 ALTER TABLE `hostsystemstbl` DISABLE KEYS */;
INSERT INTO `hostsystemstbl` VALUES (1,2,1,3,4,5,'2016-06-17','2016-06-17 14:00:00',NULL),(2,2,3,1,4,5,'2016-06-17','2016-06-17 11:00:00',NULL),(3,3,1,2,4,5,'2016-06-17','2016-06-17 09:00:00',NULL),(4,5,5,5,5,5,'2016-06-17','2016-06-17 17:45:36','cvegabello'),(5,4,4,4,4,4,'2016-06-17','2016-06-17 17:53:11','cvegabello'),(6,4,3,3,3,3,'2016-06-18','2016-06-18 08:30:13','cvegabello'),(7,1,3,2,4,5,'2016-06-18','2016-06-18 08:35:24','cvegabello'),(8,1,3,2,4,5,'2016-06-18','2016-06-18 16:39:14','cvegabello'),(9,1,2,3,4,5,'2016-06-18','2016-06-18 16:48:29','cvegabello'),(10,1,2,3,4,5,'2016-06-18','2016-06-18 16:50:02','cvegabello'),(11,1,2,3,4,5,'2016-06-18','2016-06-18 16:51:33','cvegabello'),(12,1,2,3,5,4,'2016-06-18','2016-06-18 16:55:37','cvegabello'),(13,2,1,3,5,4,'2016-06-18','2016-06-18 16:56:54','cvegabello'),(14,1,2,3,5,4,'2016-06-18','2016-06-18 17:21:01','cvegabello'),(15,3,1,2,5,4,'2016-06-18','2016-06-18 17:32:43','cvegabello'),(16,2,3,1,5,4,'2016-06-18','2016-06-18 17:43:20','cvegabello'),(17,2,3,1,4,5,'2016-06-18','2016-06-18 17:43:32','cvegabello'),(18,2,1,3,4,5,'2016-06-18','2016-06-18 17:44:11','cvegabello'),(19,2,1,3,4,5,'2016-06-18','2016-06-18 18:04:20','cvegabello'),(20,2,3,1,4,5,'2016-06-22','2016-06-22 10:37:18','cvegabello'),(21,3,1,2,4,5,'2016-06-23','2016-06-23 07:56:28','cvegabello');
/*!40000 ALTER TABLE `hostsystemstbl` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product` (
  `IdProduct` smallint(6) unsigned NOT NULL AUTO_INCREMENT,
  `productSysCode` int(11) DEFAULT NULL,
  `productName` varchar(255) DEFAULT NULL,
  `productSysName` varchar(255) DEFAULT NULL,
  `Status` bit(1) DEFAULT NULL,
  `orderBoard` int(11) DEFAULT NULL,
  `nameFileWinSummary` varchar(255) DEFAULT NULL,
  `printWinners` bit(1) DEFAULT NULL,
  `currentJackpot` double DEFAULT NULL,
  `drawDay` varchar(10) DEFAULT NULL,
  `drawDateCurrent` datetime DEFAULT NULL,
  PRIMARY KEY (`IdProduct`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES (1,12,'MEGA MILLIONS','BIGG','',4,NULL,'',363000000,'2|5','2016-06-24 22:45:00'),(2,10,'TAKE 5','CSH5','',6,NULL,'',0,'0','2016-06-23 23:00:00'),(3,27,'PICK 10','DKNO','',3,NULL,'\0',NULL,'0','2016-06-23 19:30:00'),(4,22,'QUICK DRAW','KENO','',9,NULL,'\0',NULL,NULL,NULL),(5,13,'CASH 4 LIFE','LIFE','',7,NULL,'',0,'1|4','2016-06-23 20:45:00'),(6,8,'LOTTO','LOTO','',5,NULL,'',4400000,'3|6','2016-06-25 23:00:00'),(7,16,'MONOPOLY','MPLY','\0',NULL,NULL,'\0',NULL,NULL,NULL),(8,9,'NUMBERS','PCK3','',1,NULL,'\0',NULL,'10','2016-06-23 19:30:00'),(9,14,'WIN 4','PCK4','',2,NULL,'\0',NULL,'10','2016-06-23 19:30:00'),(10,15,'POWERBALL','PWRB','',8,NULL,'',203000000,'3|6','2016-06-25 22:00:00'),(11,11,'SWEET MILLION','SMIL','\0',NULL,NULL,'\0',NULL,NULL,NULL);
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_daysdraw`
--

DROP TABLE IF EXISTS `product_daysdraw`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product_daysdraw` (
  `CodProduct` int(11) NOT NULL,
  `CodDayWeekDraw` int(11) NOT NULL,
  PRIMARY KEY (`CodProduct`,`CodDayWeekDraw`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_daysdraw`
--

LOCK TABLES `product_daysdraw` WRITE;
/*!40000 ALTER TABLE `product_daysdraw` DISABLE KEYS */;
INSERT INTO `product_daysdraw` VALUES (1,3),(1,6),(2,1),(2,2),(2,3),(2,4),(2,5),(2,6),(2,7),(3,1),(3,2),(3,3),(3,4),(3,5),(3,6),(3,7),(5,2),(5,5),(6,4),(6,7),(8,1),(8,2),(8,3),(8,4),(8,5),(8,6),(8,7),(9,1),(9,2),(9,3),(9,4),(9,5),(9,6),(9,7),(10,4),(10,7);
/*!40000 ALTER TABLE `product_daysdraw` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `qhostsystems`
--

DROP TABLE IF EXISTS `qhostsystems`;
/*!50001 DROP VIEW IF EXISTS `qhostsystems`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `qhostsystems` AS SELECT 
 1 AS `primaryHost`,
 1 AS `secondaryHost`,
 1 AS `spare1`,
 1 AS `spare2`,
 1 AS `spare3`,
 1 AS `updateDate`,
 1 AS `updateUser`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `qproducts`
--

DROP TABLE IF EXISTS `qproducts`;
/*!50001 DROP VIEW IF EXISTS `qproducts`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `qproducts` AS SELECT 
 1 AS `productSysCode`,
 1 AS `productSysName`,
 1 AS `Idproduct`,
 1 AS `drawDay`,
 1 AS `drawDateCurrent`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `qproductswinners`
--

DROP TABLE IF EXISTS `qproductswinners`;
/*!50001 DROP VIEW IF EXISTS `qproductswinners`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `qproductswinners` AS SELECT 
 1 AS `productSysCode`,
 1 AS `productSysName`,
 1 AS `Idproduct`,
 1 AS `currentJackpot`*/;
SET character_set_client = @saved_cs_client;

--
-- Final view structure for view `qhostsystems`
--

/*!50001 DROP VIEW IF EXISTS `qhostsystems`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `qhostsystems` AS select `hostsystemstbl`.`primaryHost` AS `primaryHost`,`hostsystemstbl`.`secondaryHost` AS `secondaryHost`,`hostsystemstbl`.`spare1` AS `spare1`,`hostsystemstbl`.`spare2` AS `spare2`,`hostsystemstbl`.`spare3` AS `spare3`,`hostsystemstbl`.`updateDate` AS `updateDate`,`hostsystemstbl`.`updateUser` AS `updateUser` from `hostsystemstbl` order by `hostsystemstbl`.`updateDate` desc limit 1 */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `qproducts`
--

/*!50001 DROP VIEW IF EXISTS `qproducts`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `qproducts` AS select `product`.`productSysCode` AS `productSysCode`,`product`.`productSysName` AS `productSysName`,`product`.`IdProduct` AS `Idproduct`,`product`.`drawDay` AS `drawDay`,`product`.`drawDateCurrent` AS `drawDateCurrent` from `product` where (`product`.`Status` = TRUE) order by `product`.`orderBoard` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `qproductswinners`
--

/*!50001 DROP VIEW IF EXISTS `qproductswinners`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `qproductswinners` AS select `product`.`productSysCode` AS `productSysCode`,`product`.`productSysName` AS `productSysName`,`product`.`IdProduct` AS `Idproduct`,`product`.`currentJackpot` AS `currentJackpot` from `product` where ((`product`.`Status` = TRUE) and (`product`.`printWinners` = TRUE)) order by `product`.`productSysCode` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-06-26 12:10:13
