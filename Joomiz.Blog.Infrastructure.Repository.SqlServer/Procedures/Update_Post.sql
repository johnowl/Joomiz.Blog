CREATE PROCEDURE [dbo].[Update_Post]
	@Id INT,
	@AuthorId INT, 
	@Title VARCHAR(1024), 
	@Body TEXT, 
	@IsPublished BIT, 
	@Categories TypeListInteger READONLY
AS
BEGIN

	UPDATE [Post] 
	SET [AuthorId] = @AuthorId, 
		[Title] = @Title, 
		[Body] = @Body, 
		[IsPublished] = @IsPublished 
	WHERE [Id] = @Id

	DELETE FROM [PostCategory]
	WHERE [PostId] = @Id

	INSERT INTO [PostCategory]([PostId], [CategoryId])
	SELECT @Id, Id FROM @Categories
	
END