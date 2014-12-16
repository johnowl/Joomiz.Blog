CREATE TABLE [dbo].[PostCategory]
(
	[PostId] INT NOT NULL, 
    [CategoryId] INT NOT NULL,
	CONSTRAINT [PK_PostCategory] PRIMARY KEY ([PostId], [CategoryId]),
	CONSTRAINT [FK_PostCategory_PostId] FOREIGN KEY ([PostId]) REFERENCES [Post]([Id]),
	CONSTRAINT [FK_PostCategory_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id])
)
