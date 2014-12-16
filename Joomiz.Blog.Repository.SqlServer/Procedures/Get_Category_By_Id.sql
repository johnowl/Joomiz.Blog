CREATE PROCEDURE [dbo].[Get_Category_By_Id]
	@Id INT	
AS
BEGIN

	SELECT [Id], [Name], [DateCreated] FROM [Category]
	WHERE [Id] = @Id

END
