CREATE PROCEDURE spUsuarioObterPorEmail
    @Email NVARCHAR(150)
AS
BEGIN
    SELECT * FROM Usuarios
    WHERE Email = @Email
END