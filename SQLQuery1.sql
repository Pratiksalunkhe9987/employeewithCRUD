CREATE PROCEDURE searchprocedure
       @Name VARCHAR(MAX),
       @Salary FLOAT
AS
BEGIN
 SELECT Name,Salary FROM dbo.emp WHERE ID=Id;
 END