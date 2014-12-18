CREATE PROCEDURE [dbo].[List_Post]
	@PageNumber INT,
	@PageSize INT	
AS
BEGIN

	SELECT [Id], [AuthorId], [Title], [Body], [IsPublished], [DateCreated] FROM [Post] 
	ORDER BY [DateCreated] DESC
	OFFSET ((@PageNumber - 1) * @PageSize) ROWS
	FETCH NEXT @PageSize ROWS ONLY

END