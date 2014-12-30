CREATE PROCEDURE [dbo].[List_Comment_By_PostId]
	@PostId INT,
	@PageNumber INT,
	@PageSize INT	
AS
BEGIN

	SELECT [Id], [PostId], [Name], [Email], [Url], [Body], [Status], [DateCreated] FROM [Comment]
	WHERE [PostId] = @PostId
	ORDER BY [DateCreated]
	OFFSET ((@PageNumber - 1) * @PageSize) ROWS
	FETCH NEXT @PageSize ROWS ONLY
	
END