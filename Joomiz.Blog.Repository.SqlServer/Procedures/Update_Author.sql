CREATE PROCEDURE [dbo].[Update_Author]
	@Id INT,
	@Name VARCHAR(70), 
	@Email VARCHAR(70), 
	@Password VARCHAR(32), 
	@IsActive BIT
AS
BEGIN

	UPDATE [Author]
	   SET [Name] = @Name, 
		   [Email] = @Email, 
		   [Password] = @Password, 
		   [IsActive] = @IsActive
	WHERE [Id] = @Id
	
	
END