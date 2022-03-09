CREATE PROCEDURE ProductoUpdate 
	 @IdProducto INT,
	 @Nombre VARCHAR(200),
	 @PrecioUnitario DECIMAL(18,2), 
	 @Stock INT,
	 @IdProveedor INT, 
	 @IdDepartamento INT, 
	 @Descripcion VARCHAR(500) 
AS 
	UPDATE Producto 

	SET Nombre=@Nombre, 
		PrecioUnitario=@PrecioUnitario, 
		Stock=@Stock, 
		IdProveedor=@IdProveedor, 
		IdDepartamento=@IdDepartamento, 
		Descripcion=@Descripcion 

	WHERE IdProducto=@IdProducto