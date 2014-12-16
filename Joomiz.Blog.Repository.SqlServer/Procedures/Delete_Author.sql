CREATE PROCEDURE [dbo].[Delete_Author]
	@Id INT
AS
BEGIN

	UPDATE [Author]
	   SET [Name] = @Name, 
		   [Email] = @Email, 
		   [Password] = @Password, 
		   [IsActive] = @IsActive
	WHERE [Id] = @Id
	
	
END