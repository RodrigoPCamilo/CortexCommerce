CREATE PROCEDURE spUsuarioCriar
(
    @Nome NVARCHAR(150),
    @Email NVARCHAR(150),
    @SenhaHash NVARCHAR(150),
    @CategoriaFavorita NVARCHAR(200),
    @OrcamentoMedio DECIMAL(18,2),
    @LojaPreferida INT
)
AS
BEGIN
SET NOCOUNT ON;
    INSERT INTO Usuarios 
    (Nome, Email, SenhaHash, CategoriaFavorita, OrcamentoMedio, LojaPreferida, DataCriacao)
    VALUES 
    (@Nome, @Email, @SenhaHash, @CategoriaFavorita, @OrcamentoMedio,@LojaPreferida, GETUTCDATE())
    SELECT SCOPE_IDENTITY() AS Id
END