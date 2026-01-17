CREATE PROCEDURE spPedidoObterPorId
    @Id INT
AS
BEGIN
    SELECT * FROM Pedidos
    WHERE Id = @Id
END