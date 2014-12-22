CREATE PROCEDURE [dbo].[List_Category]	
AS
BEGIN

	SELECT [Id], [Name], [DateCreated] FROM [Category]
	ORDER BY [Name]

END
