CREATE PROCEDURE searchprocedure
     @Id Int
AS
BEGIN
 SELECT * FROM dbo.emp WHERE ID=Id;
 END