CREATE PROCEDURE spUsuarioObterPorEmail
(
    @Email NVARCHAR(150)
)
AS
BEGIN
    SET
    NOCOUNT ON;
    SELECT
        Id,
        Nome,
        Email,
        SenhaHash,
        CategoriaFavorita,
        OrcamentoMedio,
        LojaPreferida
     FROM Usuarios
    WHERE Email = @Email
END