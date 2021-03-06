USE [IEspinozaProgramacionNCapas]
GO
/****** Object:  StoredProcedure [dbo].[VentaProductoGetByIdVenta]    Script Date: 9/13/2021 5:04:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [VentaProductoGetByIdVenta]
@IdVenta INT
AS
	SELECT 
		VP.IdVentaProducto,
		VP.IdVenta,
		Cantidad,
		VP.IdProducto,
		Producto.Nombre AS ProductoNombre,
		Producto.PrecioUnitario AS ProductoPrecioUnitario,
		Producto.Descripcion AS ProductoDescripcion,
		Producto.Imagen AS ProductoImagen,
		Venta.Total AS VentaTotal

		FROM	
			VentaProducto VP
			
			INNER JOIN Producto 
				ON VP.IdProducto = Producto.IdProducto

				INNER JOIN Venta
				ON VP.IdVenta = Venta.IdVenta

				WHERE VP.IdVenta = @IdVenta