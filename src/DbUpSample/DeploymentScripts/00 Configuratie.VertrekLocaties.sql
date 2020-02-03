/*
Verwijzing naar vertreklocatie waarvandaan de ritten moeten vertrekken en waar ze na afloop naartoe terug moeten keren.
= depots
*/
CREATE TABLE IF NOT EXISTS Configuratie.VertrekLocaties
(
	VertrekLocatieId INT NOT NULL PRIMARY KEY,
	VertrekLocatie NVARCHAR(10) NOT NULL,
	Depot VARCHAR(50),
	Lat FLOAT,
	Lon FLOAT
)
