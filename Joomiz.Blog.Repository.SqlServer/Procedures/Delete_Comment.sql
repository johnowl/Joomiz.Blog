CREATE PROCEDURE [dbo].[Delete_Comment]
	@Id INT
AS
BEGIN

	DELETE FROM [Comment]	   
	WHERE [Id] = @Id
	
	
END