CREATE TYPE [dbo].[TypeListInteger] AS TABLE(
 [Id] [int] NOT NULL
)
GO
CREATE PROCEDURE [dbo].[Add_Post]
	@Id INT OUTPUT,
	@AuthorId INT, 
	@Title VARCHAR(1024), 
	@Body TEXT, 
	@IsPublished BIT, 
	@DateCreated DATETIME,
	@Categories TypeListInteger READONLY
AS
BEGIN

	INSERT INTO [Post]([AuthorId], [Title], [Body], [IsPublished], [DateCreated]) 
	VALUES(@AuthorId, @Title, @Body, @IsPublished, @DateCreated)

	SET @Id = SCOPE_IDENTITY

	INSERT INTO [PostCategory]([PostId], [CategoryId])
	SELECT @Id, Id FROM @Categories
	
END