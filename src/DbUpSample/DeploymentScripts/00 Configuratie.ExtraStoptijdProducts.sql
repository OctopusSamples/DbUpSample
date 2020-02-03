CREATE TABLE IF NOT EXISTS Configuratie.ExtraStoptijdProducts
(
	ArtikelnummerMedea VARCHAR(10) NOT NULL PRIMARY KEY,
	Productcode VARCHAR(10) NOT NULL,
	ExtraStoptijdSeconden INT NOT NULL
)
