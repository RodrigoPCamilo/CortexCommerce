CREATE VIEW vwHistoricoPesquisaCompleto 
AS
SELECT 
    h.Id,
    u.Id AS UsuarioId,
    u.Nome,
    u.Email,
    h.Pergunta,
    h.RespostaGerada,
    h.Data
FROM 
    HistoricoPesquisas h
INNER JOIN 
    Usuarios u ON u.Id = u.UsuarioId;