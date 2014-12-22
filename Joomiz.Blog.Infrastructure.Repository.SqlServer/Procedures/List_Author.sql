CREATE PROCEDURE [dbo].[List_Author]	
AS
BEGIN

	SELECT [Id], [Name], [Email], [Password], [IsActive], [DateCreated] FROM [Author]
	ORDER BY [Name]

END
