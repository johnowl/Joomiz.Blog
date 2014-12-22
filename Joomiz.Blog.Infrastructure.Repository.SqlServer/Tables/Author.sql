CREATE TABLE [dbo].[Author]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(70) NOT NULL, 
    [Email] VARCHAR(70) NOT NULL, 
    [Password] VARCHAR(32) NOT NULL, 
	[IsActive] BIT NOT NULL DEFAULT 1,
    [DateCreated] DATETIME NOT NULL
)
