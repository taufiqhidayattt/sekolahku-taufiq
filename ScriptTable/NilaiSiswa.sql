﻿CREATE TABLE NilaiSiswa(
	SiswaId VARCHAR(5) NOT NULL DEFAULT(''),
	KelasId VARCHAR(3) NOT NULL DEFAULT(''),
	MapelId VARCHAR(3) NOT NULL DEFAULT(''),
	MapelName VARCHAR(30) NOT NULL DEFAULT(''),
	Nilai VARCHAR(10) NOT NULL DEFAULT(''),

	
	

	CONSTRAINT PK_NilaiSiswa PRIMARY KEY CLUSTERED(KelasId, SiswaId, MapelId)
)