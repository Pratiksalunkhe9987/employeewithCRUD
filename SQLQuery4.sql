CREATE PROCEDURE empupdate
      @Pid  int
AS 
BEGIN
UPDATE dbo.emp SET Name='Satish' WHERE Id=@Pid
END