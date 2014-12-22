CREATE PROCEDURE [dbo].[Get_Post_By_Id]
	@Id INT
AS
BEGIN

	SELECT [Id], [AuthorId], [Title], [Body], [IsPublished], [DateCreated] FROM [Post] 
	WHERE [Id] = @Id	
	
END