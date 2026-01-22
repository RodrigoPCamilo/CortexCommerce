CREATE PROCEDURE spUsuarioAtualizar
    @Id INT,
    @Nome NVARCHAR(150),
    @CategoriaFavorita NVARCHAR(200),
    @OrcamentoMedio DECIMAL(18,2),
    @LojaPreferida INT
AS
BEGIN
SET NOCOUNT ON;
    UPDATE Usuarios
    SET Nome = @Nome,
        CategoriaFavorita = @CategoriaFavorita,
        OrcamentoMedio = @OrcamentoMedio,
        LojaPreferida = @LojaPreferida
    WHERE Id = @Id
END