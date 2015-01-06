CREATE TABLE [dbo].[Comment]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [PostId] INT NOT NULL, 
    [Name] VARCHAR(70) NOT NULL, 
    [Email] VARCHAR(100) NULL, 
    [Url] VARCHAR(1024) NULL, 
    [Body] TEXT NOT NULL, 
	[Status] INT NOT NULL DEFAULT 0,
    [DateCreated] DATETIME NOT NULL,
	CONSTRAINT [FK_Comment_PostId] FOREIGN KEY ([PostId]) REFERENCES [Post]([Id])
)
