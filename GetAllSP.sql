CREATE PROCEDURE ProductoGetAll

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
		Producto;
