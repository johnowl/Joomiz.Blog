CREATE PROCEDURE [dbo].[Add_Author]
	@Id INT OUTPUT,
	@Name VARCHAR(70), 
	@Email VARCHAR(70), 
	@Password VARCHAR(32), 
	@IsActive BIT, 
	@DateCreated DATETIME
AS
BEGIN

	INSERT INTO [Author]([Name], [Email], [Password], [IsActive], [DateCreated]) 
	VALUES(@Name, @Email, @Password, @IsActive, @DateCreated)

	SET @Id = SCOPE_IDENTITY()
	
END