-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  UpdateUsuario
@correo varchar(200),
@nombre varchar(150),
@apellido varchar(100),
@genero varchar(1)

AS
BEGIN

	UPDATE dbo.usuario SET
	correo = @correo,
	nombre = @nombre, 
	apellido = @apellido, 
	genero = @genero;
END
GO
