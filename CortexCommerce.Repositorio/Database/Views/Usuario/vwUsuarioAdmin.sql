CREATE VIEW vwUsuarioAdmin
AS
SELECT 
    Id,
    Nome,
    Email,
    CategoriaFavorita,
    OrcamentoMedio,
    LojaPreferida,
    DataCriacao
FROM 
    Usuarios;