CREATE TABLE IF NOT EXISTS `Configuration`.`VehicleProfiles2` (
	`VehicleProfileId` INT(11) NOT NULL,
	`VehicleProfilename` VARCHAR(100) NOT NULL,
	`OSRMServer` VARCHAR(100) NULL DEFAULT NULL,
	`OSRMPort` INT(11) NULL DEFAULT NULL,
	PRIMARY KEY (`VehicleProfileId`)
);