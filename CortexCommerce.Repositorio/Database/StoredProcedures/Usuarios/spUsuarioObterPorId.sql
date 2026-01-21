CREATE PROCEDURE spUsuarioObterPorId
(
    @Id INT
)    
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        Id,
        Nome,
        Email,
        SenhaHash,
        CategoriaFavorita,
        OrcamentoMedio,
        LojaPreferida,
        DataCriacao 
    FROM Usuarios
    WHERE Id = @Id
END