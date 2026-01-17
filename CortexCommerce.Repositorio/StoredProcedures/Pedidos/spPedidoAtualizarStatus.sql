CREATE PROCEDURE spPedidoAtualizarStatus
    @PedidoId INT,
    @Status INT
AS
BEGIN
    UPDATE Pedidos
    SET Status = @Status
    WHERE Id = @Id
END