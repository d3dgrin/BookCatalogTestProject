DECLARE @BookAuthor TABLE 
(
	[BookId]	INT NOT NULL,
	[AuthorId]	INT NOT NULL
);

INSERT INTO @BookAuthor ([BookId], [AuthorId])
VALUES
((SELECT TOP 1 [BookId] FROM [Book] WHERE [Title] = 'Life is What You Make It'), (SELECT TOP 1 [AuthorId] FROM [Author] WHERE [Name] = 'Preeti' AND [Surname] = 'Shenoy')),
((SELECT TOP 1 [BookId] FROM [Book] WHERE [Title] = 'Wish I Could Tell You'), (SELECT TOP 1 [AuthorId] FROM [Author] WHERE [Name] = 'Durjoy' AND [Surname] = 'Datta')),
((SELECT TOP 1 [BookId] FROM [Book] WHERE [Title] = 'You are the Best Wife: A True Love Story'), (SELECT TOP 1 [AuthorId] FROM [Author] WHERE [Name] = 'Ajay' AND [Surname] = 'Pandey')),
((SELECT TOP 1 [BookId] FROM [Book] WHERE [Title] = 'The Girl Who Knew Too Much: What if the Loved One You Lost Were to Come Back?'), (SELECT TOP 1 [AuthorId] FROM [Author] WHERE [Name] = 'Vikrant' AND [Surname] = 'Khanna'));

SELECT [temp].[BookId]
	,[temp].[AuthorId]
FROM @BookAuthor AS [temp]
LEFT JOIN [BookAuthor] ba ON ba.AuthorId = [temp].AuthorId AND ba.BookId = [temp].BookId
WHERE ba.AuthorId IS NULL AND ba.BookId IS NULL;