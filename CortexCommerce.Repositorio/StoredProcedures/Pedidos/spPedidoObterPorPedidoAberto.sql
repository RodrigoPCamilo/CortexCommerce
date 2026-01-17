CREATE PROCEDURE spPedidoObterPorPedidoAberto
    @UsuarioId INT

AS
BEGIN
    SELECT * FROM Pedidos
    WHERE UsuarioId = @UsuarioId AND Status = 'Aberto'
END