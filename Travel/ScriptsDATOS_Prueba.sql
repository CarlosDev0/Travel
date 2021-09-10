--SCRIPTS DE DATOS

USE [BDTravel]
INSERT INTO dbo.tblEditorial
(
nombre ,
sede ,
fechaCreacion ,
usuarioCreacion ,
fechaModificacion ,
usuarioModificacion )
VALUES (
'Publisher', 'NY', '08-09-2021', 'Admin', '', '')
GO
--SELECT * FROM dbo.tblEditorial

INSERT INTO 
dbo.tblLibro
(
ISBN ,
editorial_id ,
titulo ,
sinopsis ,
n_paginas ,
fechaCreacion ,
usuarioCreacion ,
fechaModificacion ,
usuarioModificacion )
VALUES (555433355, 1, 'Traveling into USA', 'MMM', 55, '08-09-2021', 'Admin', '', '')
GO
--SELECT * FROM dbo.tblLibro

INSERT INTO dbo.tblAuthor
(
nombre ,
apellido ,
fechaCreacion ,
usuarioCreacion ,
fechaModificacion ,
usuarioModificacion 
) VALUES ('Juan', 'Rulfo', '08-09-2021', 'Admin','','')

GO
--SELECT * FROM dbo.tblAuthor


INSERT INTO [dbo].[tbAuthor_Has_Libro]
           ([author_id]
           ,[ISBN]
           ,[fechaCreacion]
           ,[usuarioCreacion]
           ,[fechaModificacion]
           ,[usuarioModificacion])
     VALUES
           (1, 555433355,'08-09-2021', 'Admin','','')
GO