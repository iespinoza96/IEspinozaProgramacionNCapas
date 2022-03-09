CREATE PROCEDURE AddVenta
@Total DECIMAL,
@Fecha DATETIME
AS
	INSERT INTO Venta
           (Total
           ,Fecha)
     VALUES
           (@Total, @Fecha)

