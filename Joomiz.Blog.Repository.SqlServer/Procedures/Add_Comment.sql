CREATE PROCEDURE [dbo].[Add_Comment]
	@Id INT OUTPUT,
	@PostId INT, 
	@Name VARCHAR(70), 
	@Email VARCHAR(100), 
	@Url VARCHAR(1024), 
	@Body TEXT, 
	@Status INT, 
	@DateCreated DATETIME
AS
BEGIN

	INSERT INTO [Comment]([PostId], [Name], [Email], [Url], [Body], [Status], [DateCreated]) 
	VALUES(@PostId, @Name, @Email, @Url, @Body, @Status, @DateCreated)

	SET @Id = SCOPE_IDENTITY	
	
END