CREATE FUNCTION fnTotalUsuarios()
RETURNS INT
AS
BEGIN 
    DECLARE @Total INT;

    SELECT 
        @Total = COUNT(*)
    FROM 
        Usuarios;

    RETURN @Total;
END