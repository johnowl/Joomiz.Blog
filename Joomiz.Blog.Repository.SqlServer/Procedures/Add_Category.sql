CREATE PROCEDURE [dbo].[Add_Category]
	@Id INT OUTPUT,
	@Name VARCHAR(70),
	@DateCreated DATETIME	
AS
BEGIN

	INSERT INTO [Category]([Name], [DateCreated]) 
	VALUES(@Name, @DateCreated)

	SET @Id = SCOPE_IDENTITY
	
END