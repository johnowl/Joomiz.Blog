CREATE TABLE [dbo].[Comment]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [PostId] INT NOT NULL, 
    [Name] VARCHAR(70) NOT NULL, 
    [Email] VARCHAR(100) NULL, 
    [Url] VARCHAR(1024) NULL, 
    [Body] TEXT NOT NULL, 
	[Status] INT NOT NULL DEFAULT 0,
    [DateCreated] NCHAR(10) NOT NULL
)
