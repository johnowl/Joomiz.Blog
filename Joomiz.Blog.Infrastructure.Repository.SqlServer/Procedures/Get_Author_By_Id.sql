CREATE PROCEDURE [dbo].[Get_Author_By_Id]
	@Id INT	
AS
BEGIN

	SELECT [Id], [Name], [Email], [Password], [IsActive], [DateCreated] FROM [Author]
	WHERE [Id] = @Id

END
