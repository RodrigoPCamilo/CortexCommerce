CREATE PROCEDURE spUsuarioCriar
    @Nome NVARCHAR(150),
    @Email NVARCHAR(150),
    @Senha NVARCHAR(200),
    @CategoriaFavorita NVARCHAR(200),
    @OrcamentoMedio DECIMAL(18,2)
AS
BEGIN
    INSERT INTO Usuarios 
    (Nome, Email, Senha, CategoriaFavorita, OrcamentoMedio)
    VALUES 
    (@Nome, @Email, @Senha, @CategoriaFavorita, @OrcamentoMedio, GETUTCDATE())
    SELECT SCOPE_IDENTITY() AS Id
END