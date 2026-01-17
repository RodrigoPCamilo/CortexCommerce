CREATE PROCEDURE spProdutoAtualizar
    @Id INT,
    @Nome NVARCHAR(150),
    @Descricao NVARCHAR(500),
    @Categoria NVARCHAR(100),
    @Preco DECIMAL(18, 2),
    @Estoque INT
AS
BEGIN
    UPDATE Produtos
    SET Nome = @Nome,
        Descricao = @Descricao,
        Categoria = @Categoria,
        Preco = @Preco,
        Estoque = @Estoque
    WHERE Id = @Id
END