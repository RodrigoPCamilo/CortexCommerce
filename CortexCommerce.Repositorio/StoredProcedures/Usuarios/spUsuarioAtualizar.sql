CREATE PROCEDURE spUsuarioAtualizar
    @Id INT,
    @Nome NVARCHAR(150),
    @CategoriaFavorita NVARCHAR(200),
    @OrcamentoMedio DECIMAL(18,2)
AS
BEGIN
    UPDATE Usuarios
    SET Nome = @Nome,
        CategoriaFavorita = @CategoriaFavorita,
        OrcamentoMedio = @OrcamentoMedio
    WHERE Id = @Id
END