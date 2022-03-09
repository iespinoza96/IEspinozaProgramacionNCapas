---- LEFT JOIN Y RIGHT JOIN DE PRODUCTOS QUE SE HAN VENDIDO

SELECT 

	Producto.Nombre,
	Venta.Fecha 

	FROM VentaProducto

		RIGHT JOIN Producto ON VentaProducto.IdProducto = Producto.IdProducto
		LEFT JOIN Venta ON Venta.IdVenta = Venta.IdVenta

			WHERE VentaProducto.IdProducto IS NOT NULL AND VentaProducto.IdVenta IS NOT NULL
-------------------------------------------------------------------------------------------------------

---- LEFT JOIN Y RIGHT JOIN DE PRODUCTOS QUE NO SE HAN VENDIDO
SELECT 

	Producto.Nombre,
	Venta.Fecha 

	FROM VentaProducto

		RIGHT JOIN Producto ON VentaProducto.IdProducto = Producto.IdProducto
		RIGHT JOIN Venta ON Venta.IdVenta = Venta.IdVenta

			WHERE VentaProducto.IdProducto IS  NULL AND VentaProducto.IdVenta IS NULL
-------------------------------------------------------------------------------------------------
---- RIGHT JOIN DE USUARIOS QUE NO HAN COMPRADO 
SELECT 

	Usuario.Nombre

	FROM Venta 

		RIGHT JOIN Usuario ON Venta.UserName = Usuario.UserName
			
			WHERE Venta.IdVenta IS NULL
------------------------------------------------------------------------------------
----RIGHT JOIN DE USUARIOS QUE HAN COMPRADO 
SELECT 

	Usuario.Nombre

	FROM Venta 

		RIGHT JOIN Usuario ON Venta.UserName = Usuario.UserName
			
			WHERE Venta.IdVenta IS  NOT NULL
------------------------------------------------------------------------------------
--------MOTRAR LOS PRODUCTOS QUE EXISTEN 
SELECT 

	Producto.Nombre,PrecioUnitario,Stock,Proveedor.Nombre,Departamento.Nombre, Descripcion, Imagen

	FROM Producto 
	INNER JOIN Proveedor ON Producto.IdProducto = Proveedor.IdProveedor
	  INNER  JOIN Departamento ON Producto.IdDepartamento = Departamento.IdDepartamento

----------------------------------------------------------------------------------

---------Consulta que muestre las ventas realizadas dado un intervalo de fechas

SELECT Idventa, Usuario.Nombre,Total, MetodoPago.Nombre, Fecha  

	FROM Venta

	  LEFT JOIN MetodoPago ON Venta.IdMetodoPago = Venta.IdVenta
	  LEFT JOIN Usuario ON Venta.UserName = Usuario.UserName

		WHERE Venta.Fecha BETWEEN '2021-09-13' AND '2021-09-13'

-------------------------------------------------------------------------------------
----Tablas temporales 

SELECT 
	IdProducto,Producto.Nombre,PrecioUnitario,Stock,IdProveedor,IdDepartamento, Descripcion, Imagen

INTO #Producto_Temp

FROM Producto

-------------------------------------------------------------------------------------
-------Consulta que muestra los clientes que el Apellido Paterno inicie con G
SELECT 
	       [UserName]
		  ,[Nombre]
		  ,[ApellidoPaterno]
		  ,[ApellidoMaterno]
		  ,[Email]
		  ,[Password]
		  ,[FechaNacimiento]
		  ,[Telefono]
		  ,[Sexo]
		  ,[Status]
		  ,[IdRol]

		  FROM Usuario

			 WHERE ApellidoPaterno LIKE '%'+'a'

--------------------------------------------------------------------------------
---Consulta que muestra los clientes en donde el Nombre del cliente se repita más de una vez

SELECT COUNT(UserName), Nombre 
FROM Usuario
GROUP BY Nombre
HAVING COUNT(UserName) > 1
ORDER BY COUNT(UserName) DESC;
---------------------------------------------------------------------------------
---"Replicar los productos en la una tabla nueva agregando al Nombre del Producto una C al principio

BEGIN TRY
     BEGIN TRANSACTION
              
		INSERT INTO Producto(Nombre,PrecioUnitario,Stock,IdProveedor,IdDepartamento, Descripcion)
		(
		    SELECT 'C-'+Nombre,PrecioUnitario,Stock,IdProveedor,IdDepartamento, Descripcion
		    FROM Producto
	            WHERE IdProducto=2
		)
     COMMIT TRANSACTION  
     --PR'Transacción completada'
	 
END TRY
BEGIN CATCH
     ROLLBACK TRANSACTION
     --PRINT 'Transacción cancelada'
END CATCH
------------------------------------------------------------------------------------------
------------"Actualizar el Nombre de los productos replicados quitando la C y agregando al final del nombre del producto: ""01""

---Ejemplo:  Nombre: Ctelevisión,  Nombre del producto Replicado: Televisión"

BEGIN TRY
     BEGIN TRANSACTION
              
		INSERT INTO Producto(Nombre,PrecioUnitario,Stock,IdProveedor,IdDepartamento, Descripcion)
		(
		    SELECT Nombre+'01',PrecioUnitario,Stock,IdProveedor,IdDepartamento, Descripcion
		    FROM Producto
	            WHERE IdProducto=2
)
     COMMIT TRANSACTION  
     --PRINT 'Transacción completada'
END TRY
BEGIN CATCH
     ROLLBACK TRANSACTION
     --PRINT 'Transacción cancelada'
END CATCH

-------------------------------------------------------------------------

----Consulta que no muestra los nombres de productos repetidos

SELECT COUNT(DISTINCT Nombre) FROM Producto

------------------------------------------------------------------

---Realizar ejemplo de Declare y SET

DECLARE @find VARCHAR(30);   
/* Also allowed:   
DECLARE @find VARCHAR(30) = 'Man%';   
*/  
SET @find = 'Esp%';   
SELECT Usuario.Nombre, ApellidoPaterno, Telefono, Rol.Nombre
FROM Usuario  
JOIN Rol  ON Usuario.IdRol = Rol.IdRol  
WHERE ApellidoPaterno LIKE @find;  

-------------------------------------------------------------------
---Vista que muestra los productos con sus respectivos precios y proveedores 

CREATE VIEW ProductoProveedor 
AS 
	SELECT Producto.Nombre, Producto.PrecioUnitario, Proveedor.Nombre AS Proveedor 

	FROM Producto 
		
		INNER JOIN Proveedor ON Producto.IdProveedor = Proveedor.IdProveedor

		------------
		SELECT * FROM ProductoProveedor

-----------------------------------------------------------------------------------
--Consulta que muestra la cantidad que se repite cada nombre de un usuario

SELECT  APellidoPaterno, COUNT(*) AS  Repeticiones  
FROM Usuario
GROUP BY APellidoPaterno
HAVING COUNT(APellidoPaterno) > 2

--------------------------------------------------------------------
--- Pibote

WITH Tabla(Venta,Fecha,Dia) AS 
	(SELECT 
	   
	   IdVenta,
		CONVERT(VARCHAR, Venta.Fecha,103) AS FA,
		DATENAME (WEEKDAY,Venta.Fecha) AS Dia 	

			FROM Venta
)

SELECT * FROM Tabla
PIVOT(COUNT(Fecha) FOR Dia IN([Monday],[Tuesday],[Wednesday],[Thursday],[Friday])) pvt


------

CREATE FUNCTION GetPrimeraVocal
(@Nombre VARCHAR(50))
RETURNS VARCHAR(10)
AS
	BEGIN 
		
		DECLARE @Index INT
		DECLARE @PrimeraVocal VARCHAR(10)

		SET @Index = 1 
			
			WHILE @Index < LEN(@Nombre)
				BEGIN 
					IF((SUBSTRING(@Nombre,@Index,1)) LIKE '[aeiou]%')
					BEGIN 

						SET @PrimeraVocal = SUBSTRING(@Nombre,@Index,1)
						BREAK
					END 

					SET @Index=@Index+1

				END 

			RETURN @PrimeraVocal
		END 


GO

---------------------------------------
CREATE FUNCTION GetPrimerConsonante 
(@Apellido VARCHAR(50))
RETURNS VARCHAR(10)

AS
BEGIN

    DECLARE @index INT 
	DECLARE @FirstConsonant VARCHAR(10)

	SET @index =1 

				WHILE @index < LEN(@Apellido)
				BEGIN
					IF( (SUBSTRING(@Apellido,@index,1)) LIKE '[bcdfghjklmnpqrstvwxyz]%')
					BEGIN	
		
						SET @FirstConsonant=SUBSTRING(@Apellido,@index,1)
						BREAK

					END 

					SET @index=@index+1
				END

	RETURN @FirstConsonant

END

GO

-----------------------------------------------------
CREATE FUNCTION [dbo].[GetCURP]
(
	@Matricula varchar(20),
	@Nombre varchar(50),
	@ApellidoPaterno varchar(50),
	@ApellidoMaterno varchar(50),
	@CURP varchar(50),
	@FechaNacimiento varchar(20)
)
returns varchar(50)

begin

--1
SET @CURP  =  SUBSTRING(@ApellidoPaterno,1,1)
--PRINT @CURP 

--2 
set @CURP = @CURP + [dbo].[GetFirstVowel](@ApellidoPaterno)
--PRINT @CURP 


--16
SET @CURP =@CURP + dbo.GetFirstConsonant(@ApellidoMaterno)
--print @CURP

return @CURP
----------------------------------------------------------
--- SUMA
SELECT SUM(Total)
FROM Venta;
------------------------------
SELECT AVG(PrecioUnitario)
FROM Producto;

SELECT COUNT(UserName)
FROM Usuario;
-----------------------------
SELECT IdProducto, Nombre 
FROM Producto
ORDER BY Nombre ASC;



		
SELECT IdProducto,Nombre, IdDepartamento FROM Producto JOIN 