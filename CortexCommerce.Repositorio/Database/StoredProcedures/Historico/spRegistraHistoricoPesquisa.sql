CREATE PROCEDURE spRegistraHistoricoPesquisa
(
    @UsuarioId INT,
    @Pergunta NVARCHAR(500),
    @RespostaGerada NVARCHAR(MAX)
)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO HistoricoPesquisas (UsuarioId, Pergunta, RespostaGerada, Data)
    VALUES (@UsuarioId, @Pergunta, @RespostaGerada, GETDATE());

    SELECT SCOPE_IDENTITY();
END
