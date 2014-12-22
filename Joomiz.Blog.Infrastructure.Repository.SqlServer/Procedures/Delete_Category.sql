CREATE PROCEDURE [dbo].[Delete_Category]
	@Id INT
AS
BEGIN

	DELETE FROM [Category]	   
	WHERE [Id] = @Id
	
	
END