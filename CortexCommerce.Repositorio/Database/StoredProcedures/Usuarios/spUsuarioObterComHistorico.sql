CREATE OR ALTER PROCEDURE spUsuarioObterComHistorico
    @Id INT
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
    WHERE Id = @Id;
  
    SELECT
        Id,
        UsuarioId,
        Pergunta,
        RespostaGerada,
        Data
    FROM HistoricoPesquisas
    WHERE UsuarioId = @Id
    ORDER BY Data DESC;
END