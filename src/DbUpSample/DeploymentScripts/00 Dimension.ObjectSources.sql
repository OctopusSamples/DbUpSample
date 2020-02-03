CREATE TABLE IF NOT EXISTS `Dimension`.`ObjectSources` (
	`ObjectSourceId` INT(11) NOT NULL,
	`ObjectSourceName` VARCHAR(15) NOT NULL COLLATE 'utf8mb4_general_ci',
	PRIMARY KEY (`ObjectSourceId`)
);
