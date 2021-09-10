USE [BDTravel]
CREATE TABLE dbo.tblAuthor
(id int primary key identity,
nombre varchar(45),
apellido varchar(45),
fechaCreacion datetime NULL,
usuarioCreacion varchar(50) NULL,
fechaModificacion datetime,
usuarioModificacion varchar(50)
)
GO

USE [BDTravel]
CREATE TABLE dbo.tblEditorial
(id int primary key identity,
nombre varchar(45),
sede varchar(45),
fechaCreacion datetime NULL,
usuarioCreacion varchar(50) NULL,
fechaModificacion datetime NULL,
usuarioModificacion varchar(50) NULL
)
GO



USE [BDTravel]
CREATE TABLE dbo.tblLibro
(id int identity,
ISBN int primary key,
editorial_id int,
titulo varchar(45),
sinopsis text,
n_paginas varchar(45),
fechaCreacion datetime NULL,
usuarioCreacion varchar(50) NULL,
fechaModificacion datetime NULL,
usuarioModificacion varchar(50) NULL
)

GO
SET ANSI_PADDING OFF
GO

ALTER TABLE dbo.tblLibro WITH CHECK ADD CONSTRAINT [FK_IdLibroEditorial] FOREIGN KEY ([editorial_id]) REFERENCES 
dbo.tblEditorial(id)
GO 

ALTER TABLE dbo.tblLibro CHECK CONSTRAINT [FK_IdLibroEditorial]
GO



USE [BDTravel]
CREATE TABLE dbo.tbAuthor_Has_Libro
(authorLibro_id int identity primary key,
author_id int ,
ISBN int,
fechaCreacion datetime NULL,
usuarioCreacion varchar(50) NULL,
fechaModificacion datetime NULL,
usuarioModificacion varchar(50) NULL
)

GO
SET ANSI_PADDING OFF
GO

ALTER TABLE dbo.tbAuthor_Has_Libro WITH CHECK ADD CONSTRAINT [FK_IdtbAuthor_Has_Libro__Libro] FOREIGN KEY ([ISBN]) REFERENCES 
dbo.tblLibro(ISBN)
GO 

ALTER TABLE dbo.tbAuthor_Has_Libro CHECK CONSTRAINT [FK_IdtbAuthor_Has_Libro__Libro]
GO

ALTER TABLE dbo.tbAuthor_Has_Libro WITH CHECK ADD CONSTRAINT [FK_IdtbAuthor_Has_Libro__Author] FOREIGN KEY ([author_id]) REFERENCES 
dbo.tblAuthor(id)
GO 

ALTER TABLE dbo.tbAuthor_Has_Libro CHECK CONSTRAINT [FK_IdtbAuthor_Has_Libro__Author]
GO
