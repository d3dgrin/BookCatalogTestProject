DECLARE @Author TABLE 
(
	[AuthorId]		INT NOT NULL,
	[Name]		VARCHAR(64) NOT NULL,
	[Surname]	VARCHAR(64) NOT NULL
);

INSERT INTO @Author ([AuthorId], [Name], [Surname])
VALUES
(1, 'Preeti', 'Shenoy'),
(2, 'Durjoy', 'Datta'),
(3, 'Ajay', 'Pandey'),
(4, 'Vikrant', 'Khanna');

SET IDENTITY_INSERT [Author] ON;

INSERT INTO [Author] ([AuthorId], [Name], [Surname])
SELECT [temp].[AuthorId]
	,[temp].[Name]
	,[temp].[Surname]
FROM @Author AS [temp]
LEFT JOIN [Author] AS [actual] on [actual].[AuthorId] = [temp].[AuthorId]
WHERE [actual].[AuthorId] IS NULL

SET IDENTITY_INSERT [Author] OFF;
