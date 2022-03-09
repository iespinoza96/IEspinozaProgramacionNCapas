USE [IEspinozaProgramacionNCapas]
GO
/****** Object:  StoredProcedure [dbo].[ProductoAdd]    Script Date: 8/23/2021 4:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE ProductoAdd
	 @Nombre VARCHAR(200),
	 @PrecioUnitario DECIMAL(18,2), 
	 @Stock INT,
	 @IdProveedor INT, 
	 @IdDepartamento INT, 
	 @Descripcion VARCHAR(500) 

AS   
	
	INSERT INTO [Producto]
           ([Nombre]
           ,[PrecioUnitario]
           ,[Stock]
           ,[IdProveedor]
           ,[IdDepartamento]
           ,[Descripcion])
     VALUES
           (@Nombre, @PrecioUnitario, @Stock,@IdProveedor, @IdDepartamento, @Descripcion)




	