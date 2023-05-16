CREATE PROCEDURE empdelete
       @Pid int
       
AS
BEGIN
DELETE FROM dbo.emp WHERE Id=@Pid
END