﻿CREATE TABLE [dbo].[APODERADO]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Nombre] NVARCHAR(50) NOT NULL, 
    [Telefono] NVARCHAR(50) NOT NULL, 
    [Id_alumno] INT NOT NULL, 
    CONSTRAINT [FK_APODERADO_ALUMNO] FOREIGN KEY ([Id_alumno]) REFERENCES [ALUMNO]([Id])
)
