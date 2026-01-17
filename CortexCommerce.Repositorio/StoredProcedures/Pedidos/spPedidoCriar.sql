CREATE PROCEDURE spPedidoCriar
    @UsuarioId INT,
AS
BEGIN
    INSERT INTO Pedidos (UsuarioId, DataCriacao, Status)
    VALUES (@UsuarioId,0, GETUTCDATE())

    SELECT SCOPE_IDENTITY() AS Id
END