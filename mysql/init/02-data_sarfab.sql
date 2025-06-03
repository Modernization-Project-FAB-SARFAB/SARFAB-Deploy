LOCK TABLES `person` WRITE;
/*!40000 ALTER TABLE `person` DISABLE KEYS */;
INSERT INTO `person` VALUES (1,'Luis','Lovera',1,NULL,'2025-02-09 19:03:03','2025-02-09 19:03:03');
/*!40000 ALTER TABLE `person` ENABLE KEYS */;
UNLOCK TABLES;

-- LOCK TABLES `military` WRITE;
-- /*!40000 ALTER TABLE `military` DISABLE KEYS */;
-- INSERT INTO `military` VALUES (1,'7842932',1,1,'2025-02-09 19:04:59','2025-02-12 02:16:41');
-- /*!40000 ALTER TABLE `military` ENABLE KEYS */;
-- UNLOCK TABLES;

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` 
VALUES (1,1,'admin','$2a$12$cEVDVuXx/8uDAV7W41z.beSUPqaMPgpnituKITFhKHZkiRq3o9JiW','lovera2luis@gmail.com',1,0,1,'2025-02-19 22:48:30','2025-04-05 22:22:25');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

LOCK TABLES `department` WRITE;
/*!40000 ALTER TABLE `department` DISABLE KEYS */;
INSERT INTO `department` VALUES
(1, 'Chuquisaca'),
(2, 'La Paz'),
(3, 'Cochabamba'),
(4, 'Oruro'),
(5, 'Potosí'),
(6, 'Tarija'),
(7, 'Santa Cruz'),
(8, 'Beni'),
(9, 'Pando');
/*!40000 ALTER TABLE `department` ENABLE KEYS */;
UNLOCK TABLES;

LOCK TABLES `province` WRITE;
/*!40000 ALTER TABLE `province` DISABLE KEYS */;
INSERT INTO `province` VALUES
(1, 'Arani', 3),
(2, 'Arque', 3),
(3, 'Ayopaya', 3),
(4, 'Bolívar', 3),
(5, 'Campero', 3),
(6, 'Capinota', 3),
(7, 'Carrasco', 3),
(8, 'Cercado', 3),
(9, 'Chapare', 3),
(10, 'Esteban Arze', 3),
(11, 'Germán Jordán', 3),
(12, 'Mizque', 3),
(13, 'Punata', 3),
(14, 'Quillacollo', 3),
(15, 'Tapacarí', 3),
(16, 'Tiraque', 3);
/*!40000 ALTER TABLE `province` ENABLE KEYS */;
UNLOCK TABLES;

LOCK TABLES `municipality` WRITE;
/*!40000 ALTER TABLE `municipality` DISABLE KEYS */;
INSERT INTO `municipality` VALUES
(1, 'Arani', 1),
(2, 'Vacas', 1),
(3, 'Arque', 2),
(4, 'Tacopaya', 2),
(5, 'Independencia', 3),
(6, 'Morochata', 3),
(7, 'Cocapata', 3),
(8, 'Bolívar', 4),
(9, 'Aiquile', 5),
(10, 'Pasorapa', 5),
(11, 'Omereque', 5),
(12, 'Villa Capinota', 6),
(13, 'Santiváñez', 6),
(14, 'Sicaya', 6),
(15, 'Totora', 7),
(16, 'Pocona', 7),
(17, 'Pojo', 7),
(18, 'Entre Ríos', 7),
(19, 'Puerto Villarroel', 7),
(20, 'Chimoré', 7),
(21, 'Cochabamba', 8),
(22, 'Sacaba', 9),
(23, 'Colomi', 9),
(24, 'Villa Tunari', 9),
(25, 'Tarata', 10),
(26, 'Anzaldo', 10),
(27, 'Sacabamba', 10),
(28, 'Arbieto', 10),
(29, 'Cliza', 11),
(30, 'Toco', 11),
(31, 'Tolata', 11),
(32, 'Mizque', 12),
(33, 'Vila Vila', 12),
(34, 'Alalay', 12),
(35, 'Punata', 13),
(36, 'San Benito', 13),
(37, 'Villa Rivero', 13),
(38, 'Tacachi', 13),
(39, 'Cuchumuela', 13),
(40, 'Quillacollo', 14),
(41, 'Sipe Sipe', 14),
(42, 'Vinto', 14),
(43, 'Tiquipaya', 14),
(44, 'Colcapirhua', 14),
(45, 'Tapacarí', 15),
(46, 'Tiraque', 16),
(47, 'Shinaota', 16);
/*!40000 ALTER TABLE `municipality` ENABLE KEYS */;
UNLOCK TABLES;


LOCK TABLES `military_rank` WRITE;
/*!40000 ALTER TABLE `military_rank` DISABLE KEYS */;
INSERT INTO `military_rank` VALUES
(1,'Coronel','Cnl.'),
(2,'Teniente Coronel','Tcnl.'),
(3,'Mayor','My.'),
(4,'Capitán','Cap.'),
(5,'Teniente','Tte.'),
(6,'Subteniente','Sbtte.'),
(7,'Suboficial Maestre','Sof. Mtre.'),
(8,'Suboficial Mayor','Sof. My.'),
(9,'Suboficial Primero','Sof. 1ro.'),
(10,'Suboficial Segundo','Sof. 2do.'),
(11,'Suboficial Inicial','Sof. Inc.'),
(12,'Sargento Primero','Sgto. 1ro.'),
(13,'Sargento Segundo','Sgto. 2do.'),
(14,'Sargento Inicial','Sgto. Inc.');
/*!40000 ALTER TABLE `military_rank` ENABLE KEYS */;
UNLOCK TABLES;


LOCK TABLES `grade` WRITE;
/*!40000 ALTER TABLE `grade` DISABLE KEYS */;
INSERT INTO `grade` VALUES
(1,'Rescatista Comando','Resc. Cmdo.'),
(2,'Rescatista Master','Resc. Master'),
(3,'Rescatista Primero','Resc. 1ro.'),
(4,'Rescatista Segundo','Resc. 2do.'),
(5,'Rescatista Inicial','Resc. Inc.');
/*!40000 ALTER TABLE `grade` ENABLE KEYS */;
UNLOCK TABLES;

LOCK TABLES `operation_category` WRITE;
/*!40000 ALTER TABLE `operation_category` DISABLE KEYS */;
INSERT INTO `operation_category` VALUES
(1,'AGUA'),
(2,'FUEGO'),
(3,'AIRE'),
(4,'TIERRA');
/*!40000 ALTER TABLE `operation_category` ENABLE KEYS */;
UNLOCK TABLES;

LOCK TABLES `operation_type` WRITE;
/*!40000 ALTER TABLE `operation_type` DISABLE KEYS */;
INSERT INTO `operation_type` VALUES
-- AGUA (1)
(1,'Rescate en Aguas turbulentas',1),
(2,'Rescate en ríos',1),
(3,'Demostración',1),
(4,'Capacitación',1),

-- FUEGO (2)
(5,'Control de Incendios Forestales',2),
(6,'Capacitación en Extintores',2),
(7,'Capacitación',2),
(8,'Simulacro',2),
(9,'Demostración',2),

-- AIRE (3)
(10,'Operación Helitáctica',3),
(11,'Rescate en Altura',3),
(12,'Aeromedicina',3),
(13,'Paracaidismo',3),

-- TIERRA (4)
(14,'Primeros Auxilios',4),
(15,'Soporte Básico de Vida',4),
(16,'Atención Prehospitalaria',4),
(17,'Entrenamiento',4),
(18,'Capacitación',4),
(19,'Seguridad Médica',4),
(20,'Cabullería y Campismo',4),
(21,'Sobrevivencia',4);
/*!40000 ALTER TABLE `operation_type` ENABLE KEYS */;
UNLOCK TABLES;

-- USUARIOS