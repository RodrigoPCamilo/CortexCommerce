CREATE VIEW vwUsuarioPublico
AS
SELECT 
    Id,
    Nome,
    CategoriaFavorita,
    OrcamentoMedio,
    LojaPreferida
FROM 
    Usuarios;
    