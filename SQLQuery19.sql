CREATE PROCEDURE DepartamentoAdd
@Nombre VARCHAR(100),
@IdArea INT
AS
	INSERT INTO Departamento
	(Nombre,IdArea)
	VALUES 
	(@Nombre,@IdArea)
GO

CREATE PROCEDURE DepartamentoDelete
@IdDepartamento INT
AS
	DELETE FROM Departamento
	WHERE IdDepartamento=@IdDepartamento
GO

CREATE PROCEDURE DepartamentoUpdate
@IdDepartamento INT,
@Nombre VARCHAR(100),
@IdArea INT
AS 
	UPDATE Departamento

	SET Nombre=@Nombre,IdArea=@IdArea

	WHERE IdDepartamento=@IdDepartamento
GO

CREATE PROCEDURE DepartamentoGetAll
AS 
	SELECT IdDepartamento, Nombre, IdArea
	FROM Departamento

GO

CREATE PROCEDURE DepartamentoGetById
@IdDepartamento INT
AS 
	SELECT IdDepartamento, Nombre, IdArea
	FROM Departamento
	WHERE IdDepartamento=@IdDepartamento
GO