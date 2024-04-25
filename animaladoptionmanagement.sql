CREATE DATABASE  IF NOT EXISTS `animaladoptionmanagement` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `animaladoptionmanagement`;
-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: animaladoptionmanagement
-- ------------------------------------------------------
-- Server version	8.0.36

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Temporary view structure for view `adopted_animals`
--

DROP TABLE IF EXISTS `adopted_animals`;
/*!50001 DROP VIEW IF EXISTS `adopted_animals`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `adopted_animals` AS SELECT 
 1 AS `animal_id`,
 1 AS `animal_kind`,
 1 AS `name`,
 1 AS `breed`,
 1 AS `age`,
 1 AS `size`,
 1 AS `sex`,
 1 AS `coat_length`,
 1 AS `color`,
 1 AS `health_status`,
 1 AS `adoption_status`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `adopter`
--

DROP TABLE IF EXISTS `adopter`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `adopter` (
  `adopter_id` int NOT NULL AUTO_INCREMENT,
  `adopter_name` varchar(100) DEFAULT NULL,
  `phone_number` varchar(20) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`adopter_id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `adopter`
--

LOCK TABLES `adopter` WRITE;
/*!40000 ALTER TABLE `adopter` DISABLE KEYS */;
INSERT INTO `adopter` VALUES (1,'Maloi','(555) 234-5678','Cavite'),(2,'Aiah','(555) 987-6543','Cebu'),(3,'Stacey','(555) 555-5555','Nueva Viscaya'),(4,'Jhoanna','(555) 555-1234','Calamba, Laguna'),(5,'Gwen','(555) 555-9999','Albay'),(11,'Sheena','09111111111','Isabela'),(12,'test2','test2','test'),(13,'Maureen','09123456789','Tabaco City');
/*!40000 ALTER TABLE `adopter` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `adoption`
--

DROP TABLE IF EXISTS `adoption`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `adoption` (
  `adoption_id` int NOT NULL AUTO_INCREMENT,
  `animal_id` int DEFAULT NULL,
  `adopter_id` int DEFAULT NULL,
  `adoption_date` date DEFAULT NULL,
  `adoption_fee` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`adoption_id`),
  KEY `animal_id` (`animal_id`),
  KEY `adopter_id` (`adopter_id`),
  CONSTRAINT `adoption_ibfk_1` FOREIGN KEY (`animal_id`) REFERENCES `animal` (`animal_id`),
  CONSTRAINT `adoption_ibfk_2` FOREIGN KEY (`adopter_id`) REFERENCES `adopter` (`adopter_id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `adoption`
--

LOCK TABLES `adoption` WRITE;
/*!40000 ALTER TABLE `adoption` DISABLE KEYS */;
INSERT INTO `adoption` VALUES (1,1,1,'2024-01-31',350.00),(2,3,2,'2024-02-29',270.00),(3,8,3,'2024-03-15',500.00),(4,6,4,'2024-03-21',420.00),(5,2,5,'2023-04-03',580.00),(6,5,11,'2024-04-14',400.00),(7,4,13,'2024-04-15',500.00);
/*!40000 ALTER TABLE `adoption` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `adoption_report`
--

DROP TABLE IF EXISTS `adoption_report`;
/*!50001 DROP VIEW IF EXISTS `adoption_report`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `adoption_report` AS SELECT 
 1 AS `adoption_id`,
 1 AS `animal_id`,
 1 AS `animal_name`,
 1 AS `adopter_id`,
 1 AS `adopter_name`,
 1 AS `adoption_date`,
 1 AS `adoption_fee`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `adoption_status`
--

DROP TABLE IF EXISTS `adoption_status`;
/*!50001 DROP VIEW IF EXISTS `adoption_status`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `adoption_status` AS SELECT 
 1 AS `adoption_status`,
 1 AS `Count`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `adoption_summary`
--

DROP TABLE IF EXISTS `adoption_summary`;
/*!50001 DROP VIEW IF EXISTS `adoption_summary`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `adoption_summary` AS SELECT 
 1 AS `total_adoptions`,
 1 AS `total_adoption_fee`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `age_distribution`
--

DROP TABLE IF EXISTS `age_distribution`;
/*!50001 DROP VIEW IF EXISTS `age_distribution`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `age_distribution` AS SELECT 
 1 AS `AgeGroup`,
 1 AS `Count`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `animal`
--

DROP TABLE IF EXISTS `animal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `animal` (
  `animal_id` int NOT NULL AUTO_INCREMENT,
  `animal_kind` varchar(50) DEFAULT NULL,
  `name` varchar(100) DEFAULT NULL,
  `breed` varchar(100) DEFAULT NULL,
  `age` int DEFAULT NULL,
  `size` varchar(20) DEFAULT NULL,
  `sex` varchar(10) DEFAULT NULL,
  `coat_length` varchar(20) DEFAULT NULL,
  `color` varchar(50) DEFAULT NULL,
  `health_status` varchar(100) DEFAULT NULL,
  `adoption_status` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`animal_id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `animal`
--

LOCK TABLES `animal` WRITE;
/*!40000 ALTER TABLE `animal` DISABLE KEYS */;
INSERT INTO `animal` VALUES (1,'Dog','Chowlong','Dachshund',3,'Medium','Male','Short','Golden','Healthy','Adopted'),(2,'Cat','Luna','Siamese',2,'Small','Female','Short','White','Healthy','Adopted'),(3,'Bird','Ling','Parrot',1,'Small','Female','N/A','Green','Healthy','Adopted'),(4,'Dog','Buddy','Labrador Retriever',4,'Large','Male','Short','Black','Healthy','Available'),(5,'Cat','Ming','Mixed Breed',5,'Male','Male','Medium','Black and White','Special Needs','Adopted'),(6,'Rabbit','Snowball','Holland Lop',2,'Small','Female','Short','White','Healthy','Adopted'),(7,'Dog','Whitey','Poodle',2,'Small','Female','Short','White','Healthy','Available'),(8,'Cat','Simba','Maine Coon',3,'Large','Male','Long','Orange','Healthy','Adopted'),(9,'Bird','Coco','Cockatiel',1,'Small','Male','N/A','Grey','Healthy','Available'),(10,'Dog','Rocky','German Shepherd',6,'Large','Male','Medium','Black and Tan','Under Treatment','Available'),(11,'Dog','Ganda','Aspin',2,'Female','test','Short','Black','Special Needs','Available'),(12,'Cat','Caramel','Puspin',3,'Male','Male','Short','Orange','Healthy','Adopted');
/*!40000 ALTER TABLE `animal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `donation`
--

DROP TABLE IF EXISTS `donation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `donation` (
  `donation_id` int NOT NULL AUTO_INCREMENT,
  `donor_name` varchar(255) DEFAULT NULL,
  `donor_contact` varchar(100) DEFAULT NULL,
  `donation_date` date DEFAULT NULL,
  `donation_type` varchar(50) DEFAULT NULL,
  `donation_amount` decimal(10,2) DEFAULT NULL,
  `donation_method` varchar(50) DEFAULT NULL,
  `purpose` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`donation_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `donation`
--

LOCK TABLES `donation` WRITE;
/*!40000 ALTER TABLE `donation` DISABLE KEYS */;
INSERT INTO `donation` VALUES (1,'Mikaela','mik@gmail.com','2024-03-15','Money',100.00,'GCash','Animal Welfare Fund'),(2,'Anonymous','anonymous','2024-03-20','Dog Food',2.00,'In Person','Animal Food'),(3,'Anonymous','anonymous','2024-04-08','Cat Food ',3.00,'In Person','Animal Food'),(4,'Aly','aly@gmail.com','2024-05-09','Money',1000.00,'Cash','Animal Welfare Fund'),(5,'Thea','thea@gmail.com','2024-05-09','Money',500.00,'Bank Transfer','Animal Welfare Fund'),(6,'Lor','lor@gmail.com','2024-05-10','Dog Food',2.00,'In Person','Animal Food'),(7,'Amir','amir@gmail','2024-04-14','Money',200.00,'GCash','Animal Welfare Fund'),(8,'Maureen Benitez','mau@gmal.com','2024-04-15','Money',500.00,'Cash','Animal Welfare Fund');
/*!40000 ALTER TABLE `donation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `donation_report`
--

DROP TABLE IF EXISTS `donation_report`;
/*!50001 DROP VIEW IF EXISTS `donation_report`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `donation_report` AS SELECT 
 1 AS `total_donors`,
 1 AS `donation_type`,
 1 AS `total_donation_amount`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `gender_distribution`
--

DROP TABLE IF EXISTS `gender_distribution`;
/*!50001 DROP VIEW IF EXISTS `gender_distribution`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `gender_distribution` AS SELECT 
 1 AS `Gender`,
 1 AS `Count`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `health_status`
--

DROP TABLE IF EXISTS `health_status`;
/*!50001 DROP VIEW IF EXISTS `health_status`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `health_status` AS SELECT 
 1 AS `health_status`,
 1 AS `Count`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `total_animals`
--

DROP TABLE IF EXISTS `total_animals`;
/*!50001 DROP VIEW IF EXISTS `total_animals`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `total_animals` AS SELECT 
 1 AS `total_animals`,
 1 AS `total_animal_kinds`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `total_dogs_and_cats`
--

DROP TABLE IF EXISTS `total_dogs_and_cats`;
/*!50001 DROP VIEW IF EXISTS `total_dogs_and_cats`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `total_dogs_and_cats` AS SELECT 
 1 AS `total_dogs`,
 1 AS `total_cats`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `user_id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `Birthdate` date DEFAULT NULL,
  `FirstPetName` varchar(50) DEFAULT NULL,
  `status` enum('active','inactive') NOT NULL DEFAULT 'inactive',
  `first_name` varchar(255) DEFAULT NULL,
  `last_name` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `phone_number` varchar(255) DEFAULT NULL,
  `roles` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `username` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'admin1','123','2002-05-31','Chichi','inactive','Maureen','Benitez','mau@gmail.com','09123456789','Veterenarian'),(2,'admin2','321','1999-06-26','Red','inactive','Alyssa','Benitez','aly@gmail.com','09876543210','Groomer'),(3,'admin3','456','1967-08-15','Wally','inactive','Miriam','Benitez','miam@gmail.com','09988776655','Adoption Counselor'),(4,'admin4','789','1968-07-19','Ming','inactive','Vicente','Benitez','vince@gmail.com','09911223344','Animal Control'),(5,'admin5','999','2003-06-27','Kent','inactive','Diogenes','Tayam','dio@gmail.com','09999999999','Groomer'),(6,'admin6','888','2001-05-13','Dio','inactive','Kent Arjay','Dela Pena','kent@gmail.com','09888888888','Animal Caretaker'),(7,'admin7','111','2002-06-12','Kent','inactive','Vivian','Vivo','viv@gmail.com','09111111111','Animal Caretaker');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'animaladoptionmanagement'
--

--
-- Dumping routines for database 'animaladoptionmanagement'
--
/*!50003 DROP FUNCTION IF EXISTS `CountAvailableAnimals` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `CountAvailableAnimals`() RETURNS int
    READS SQL DATA
BEGIN
    DECLARE availableCount INT;
    SELECT COUNT(*) INTO availableCount FROM Animals WHERE adoption_status = 'Available';
    RETURN availableCount;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `UpdateAdoptionStatus` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateAdoptionStatus`(IN animalID INT, IN newStatus VARCHAR(50))
BEGIN
    UPDATE Animals SET adoption_status = newStatus WHERE animal_id = animalID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `adopted_animals`
--

/*!50001 DROP VIEW IF EXISTS `adopted_animals`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `adopted_animals` AS select `animal`.`animal_id` AS `animal_id`,`animal`.`animal_kind` AS `animal_kind`,`animal`.`name` AS `name`,`animal`.`breed` AS `breed`,`animal`.`age` AS `age`,`animal`.`size` AS `size`,`animal`.`sex` AS `sex`,`animal`.`coat_length` AS `coat_length`,`animal`.`color` AS `color`,`animal`.`health_status` AS `health_status`,`animal`.`adoption_status` AS `adoption_status` from `animal` where (`animal`.`adoption_status` = 'Adopted') */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `adoption_report`
--

/*!50001 DROP VIEW IF EXISTS `adoption_report`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `adoption_report` AS select `a`.`adoption_id` AS `adoption_id`,`a`.`animal_id` AS `animal_id`,`an`.`name` AS `animal_name`,`a`.`adopter_id` AS `adopter_id`,`ad`.`adopter_name` AS `adopter_name`,`a`.`adoption_date` AS `adoption_date`,`a`.`adoption_fee` AS `adoption_fee` from ((`adoption` `a` join `adopter` `ad` on((`a`.`adopter_id` = `ad`.`adopter_id`))) join `animal` `an` on((`a`.`animal_id` = `an`.`animal_id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `adoption_status`
--

/*!50001 DROP VIEW IF EXISTS `adoption_status`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `adoption_status` AS select `animal`.`adoption_status` AS `adoption_status`,count(0) AS `Count` from `animal` group by `animal`.`adoption_status` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `adoption_summary`
--

/*!50001 DROP VIEW IF EXISTS `adoption_summary`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `adoption_summary` AS select count(`adoption_report`.`adoption_id`) AS `total_adoptions`,sum(`adoption_report`.`adoption_fee`) AS `total_adoption_fee` from `adoption_report` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `age_distribution`
--

/*!50001 DROP VIEW IF EXISTS `age_distribution`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `age_distribution` AS select (case when (`animal`.`age` <= 2) then 'Baby' when (`animal`.`age` <= 5) then 'Adult' else 'Senior' end) AS `AgeGroup`,count(0) AS `Count` from `animal` group by `AgeGroup` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `donation_report`
--

/*!50001 DROP VIEW IF EXISTS `donation_report`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `donation_report` AS select count(distinct `donation`.`donation_id`) AS `total_donors`,`donation`.`donation_type` AS `donation_type`,sum(`donation`.`donation_amount`) AS `total_donation_amount` from `donation` group by `donation`.`donation_type` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `gender_distribution`
--

/*!50001 DROP VIEW IF EXISTS `gender_distribution`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `gender_distribution` AS select `animal`.`sex` AS `Gender`,count(0) AS `Count` from `animal` group by `animal`.`sex` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `health_status`
--

/*!50001 DROP VIEW IF EXISTS `health_status`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `health_status` AS select `animal`.`health_status` AS `health_status`,count(0) AS `Count` from `animal` group by `animal`.`health_status` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `total_animals`
--

/*!50001 DROP VIEW IF EXISTS `total_animals`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `total_animals` AS select count(0) AS `total_animals`,count(distinct `animal`.`animal_kind`) AS `total_animal_kinds` from `animal` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `total_dogs_and_cats`
--

/*!50001 DROP VIEW IF EXISTS `total_dogs_and_cats`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `total_dogs_and_cats` AS select sum((case when (`animal`.`animal_kind` = 'Dog') then 1 else 0 end)) AS `total_dogs`,sum((case when (`animal`.`animal_kind` = 'Cat') then 1 else 0 end)) AS `total_cats` from `animal` */;
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

-- Dump completed on 2024-04-25 14:22:53
