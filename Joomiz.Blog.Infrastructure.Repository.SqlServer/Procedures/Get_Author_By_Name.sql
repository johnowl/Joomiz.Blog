CREATE PROCEDURE [dbo].[Get_Author_By_Name]
	@Name VARCHAR(100)
AS
BEGIN

	SELECT [Id], [Name], [Email], [Password], [IsActive], [DateCreated] FROM [Author]
	WHERE [Name] = @Name

END
