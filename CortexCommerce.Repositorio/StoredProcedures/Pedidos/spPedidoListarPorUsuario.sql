CREATE PROCEDURE spPedidoListarPorUsuario
    @UsuarioId INT
AS
BEGIN
    SELECT * FROM Pedidos
    WHERE UsuarioId = @UsuarioId
END