CREATE FUNCTION fnUsuarioPorCategoria
(
    @Categoria NVARCHAR(100)
)
RETURNS INT
AS
BEGIN
    DECLARE @Total INT;

    SELECT 
        @Total = COUNT(*)
    FROM 
        Usuarios
    WHERE 
        CategoriaFavorita = @Categoria;

    RETURN @Total;
END