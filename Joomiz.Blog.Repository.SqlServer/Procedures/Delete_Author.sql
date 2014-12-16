CREATE PROCEDURE [dbo].[Delete_Author]
	@Id INT
AS
BEGIN

	DELETE FROM [Author]	   
	WHERE [Id] = @Id
	
	
END