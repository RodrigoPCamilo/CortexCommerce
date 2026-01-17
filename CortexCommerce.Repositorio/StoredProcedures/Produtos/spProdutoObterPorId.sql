CREATE PROCEDURE spProdutoObterPorId
    @Id INT
AS
BEGIN
    SELECT * FROM Produtos
    WHERE Id = @Id
END