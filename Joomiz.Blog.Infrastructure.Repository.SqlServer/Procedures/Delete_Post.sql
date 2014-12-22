CREATE PROCEDURE [dbo].[Delete_Post]
	@Id INT
AS
BEGIN

	DELETE FROM [Post]	   
	WHERE [Id] = @Id
	
	
END