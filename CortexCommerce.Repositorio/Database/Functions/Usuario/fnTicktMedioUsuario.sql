
CREATE FUNCTION fnTicktMedioUsuario()
RETURNS DECIMAL(10,2)
AS
BEGIN 
    DECLARE @Media DECIMAL(10,2);

    SELECT 
        @Media = AVG(OrcamentoMedio)
    FROM 
        Usuarios;

    RETURN @Media;
END