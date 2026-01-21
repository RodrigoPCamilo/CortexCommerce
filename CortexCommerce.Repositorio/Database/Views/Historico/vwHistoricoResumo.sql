CREATE VIEW vwHistoricoResumo
AS
SELECT 
    UsuarioId,
    Pergunta,
    LEFT(RespostaGerada, 200) AS RespostaResumo,
    Data
FROM 
    HistoricoPesquisas;