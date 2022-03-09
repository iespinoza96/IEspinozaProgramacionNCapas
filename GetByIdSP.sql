CREATE PROCEDURE ProductoGetById
@IdProducto INT
AS
	SELECT
		IdProducto,
		Nombre,
		PrecioUnitario,
		Stock,
		IdProveedor,
		IdDepartamento,
		Descripcion

	FROM 
		Producto
	WHERE 
		IdProducto = @IdProducto;
