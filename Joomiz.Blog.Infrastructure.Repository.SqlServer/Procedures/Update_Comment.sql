CREATE PROCEDURE [dbo].[Update_Comment]
	@Id INT OUTPUT,
	@PostId INT, 
	@Name VARCHAR(70), 
	@Email VARCHAR(100), 
	@Url VARCHAR(1024), 
	@Body TEXT, 
	@Status INT
AS
BEGIN

	UPDATE [Comment]
		SET [PostId] = @PostId, 
			[Name] = @Name, 
			[Email] = @Email, 
			[Url] = @Url, 
			[Body] = @Body, 
			[Status] = @Status
	WHERE [Id] = @Id
	
END