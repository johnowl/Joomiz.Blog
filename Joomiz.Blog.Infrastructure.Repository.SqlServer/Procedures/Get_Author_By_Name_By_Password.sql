CREATE PROCEDURE [dbo].[Get_Author_By_Name_By_Password]
	@Name VARCHAR(100),
	@Password VARCHAR(32)
AS
BEGIN

	SELECT [Id], [Name], [Email], [Password], [IsActive], [DateCreated] FROM [Author]
	WHERE [Name] = @Name AND [Password] = @Password

END
