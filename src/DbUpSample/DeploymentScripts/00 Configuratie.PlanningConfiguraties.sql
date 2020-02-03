CREATE TABLE IF NOT EXISTS Configuratie.PlanningConfiguraties
(
	PlanningConfiguratieId INT NOT NULL PRIMARY KEY,
	PlanningConfiguratie VARCHAR(100) NOT NULL,
	RunOrder INT NOT NULL
)