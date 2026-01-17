CREATE PROCEDURE spProdutoCriar
    @Nome NVARCHAR(150),
    @Descricao NVARCHAR(500),
    @Categoria NVARCHAR(100),
    @Preco DECIMAL(18,2),
    @Estoque INT
AS
BEGIN 
    INSERT INTO Produtos 
    (Nome, Descricao, Categoria, Preco, Estoque)
    VALUES 
    (@Nome, @Descricao, @Categoria, @Preco, @Estoque, GETUTCDATE())
    SELECT SCOPE_IDENTITY() AS Id
END
