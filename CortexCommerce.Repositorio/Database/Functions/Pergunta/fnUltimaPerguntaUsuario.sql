CREATE FUNCTION fnUltimaPerguntaUsuario
(
    @UsuarioId INT
)
RETURNS NVARCHAR(500)
AS
BEGIN
    DECLARE @Pergunta NVARCHAR(500);

    SELECT 
        TOP 1 @Pergunta = Pergunta
    FROM 
        HistoricoPesquisas
    WHERE 
        UsuarioId = @UsuarioId
    ORDER BY 
        Data DESC;

    RETURN @Pergunta;
END