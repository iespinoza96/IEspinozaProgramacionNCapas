CREATE PROCEDURE ProductoDelete
@IdProducto INT
AS
	DELETE FROM [Producto]
	WHERE IdProducto=@IdProducto;