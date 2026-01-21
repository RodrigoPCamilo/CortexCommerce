CREATE PROCEDURE spListarHistoricoPorUsuario(
    @UsuarioId INT
)
AS
BEGIN 
    SET NOCOUNT ON;

    SELECT 
        Id,
        Pergunta,
        RespostaGerada,
        Data
    FROM 
        HistoricoPesquisas
    WHERE 
        UsuarioId = @UsuarioId
    ORDER BY 
        Data DESC;
END