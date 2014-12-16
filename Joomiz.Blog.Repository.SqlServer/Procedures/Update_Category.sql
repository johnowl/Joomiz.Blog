CREATE PROCEDURE [dbo].[Update_Category]
	@Id INT,
	@Name VARCHAR(70)	
AS
BEGIN

	UPDATE [Category]
	   SET [Name] = @Name
	WHERE [Id] = @Id
		
END