USE [IEspinozaProgramacionNCapas]
GO
/****** Object:  StoredProcedure [dbo].[UsuarioAdd]    Script Date: 9/14/2021 10:44:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[UsuarioAdd]
	@UserName VARCHAR (100)
	,@Nombre VARCHAR (100)
	,@ApellidoPaterno VARCHAR (100)
	,@ApellidoMaterno VARCHAR (100)
	,@Email VARCHAR (100)
	,@Password VARBINARY(100)
	,@FechaNacimiento DATE
	,@Telefono VARCHAR (50)
	,@Sexo CHAR
	,@Status BIT 
	,@IdRol INT 

AS

INSERT INTO [Usuario]
           ([UserName]
		   ,[Nombre]
           ,[ApellidoPaterno]
           ,[ApellidoMaterno]
           ,[Email]
           ,[Password]
           ,[FechaNacimiento]
           ,[Telefono]
           ,[Sexo]
           ,[Status]
           ,[IdRol])
     VALUES
           (@UserName 
		   ,@Nombre
			,@ApellidoPaterno 
			,@ApellidoMaterno 
			,@Email 
			,@Password
			,@FechaNacimiento 
			,@Telefono 
			,@Sexo 
			,@Status  
			,@IdRol)