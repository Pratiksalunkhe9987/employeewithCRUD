CREATE PROCEDURE nsearchprocedure
        @Pname VARCHAR(MAX)
AS
BEGIN
SELECT * FROM dbo.emp WHERE Name=@Pname
END