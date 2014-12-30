CREATE PROCEDURE [dbo].[List_Category_By_PostId]	
(
@PostId INT
)
AS
BEGIN

	SELECT [Id], [Name], [DateCreated] FROM [Category] A
	INNER JOIN [PostCategory] B
	ON A.[Id] = B.[CategoryId]
	WHERE B.[PostId] = @PostId
	ORDER BY [Name]

END
