CREATE TABLE [dbo].[BookAuthor]
(
	[BookId] INT NOT NULL,
	[AuthorId] INT NOT NULL, 
    CONSTRAINT [FK_BookAuthor_Book] FOREIGN KEY ([BookId]) REFERENCES [Book]([Id]), 
    CONSTRAINT [FK_BookAuthor_Author] FOREIGN KEY ([AuthorId]) REFERENCES [Author]([Id])
)
