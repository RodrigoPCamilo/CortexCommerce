CREATE PROCEDURE spUsuarioObterPorId
    @Id INT
AS
BEGIN
    SELECT * FROM Usuarios
    WHERE Id = @Id
END