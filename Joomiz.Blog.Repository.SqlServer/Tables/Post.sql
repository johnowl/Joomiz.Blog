CREATE TABLE [dbo].[Post]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [AuthorId] INT NOT NULL, 
    [Title] VARCHAR(1024) NULL, 
    [Body] TEXT NULL, 
	[IsPublished] BIT NOT NULL DEFAULT 0,
    [DateCreated] DATETIME NOT NULL
)
