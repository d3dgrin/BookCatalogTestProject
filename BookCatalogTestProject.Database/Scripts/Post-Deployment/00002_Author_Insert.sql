DECLARE @Author TABLE 
(
	[Id]		INT NOT NULL,
	[Name]		VARCHAR(64) NOT NULL,
	[Surname]	VARCHAR(64) NOT NULL
);

INSERT INTO @Author ([Id], [Name], [Surname])
VALUES
(1, 'Preeti', 'Shenoy'),
(2, 'Durjoy', 'Datta'),
(3, 'Ajay', 'Pandey'),
(4, 'Vikrant', 'Khanna');

SET IDENTITY_INSERT [Author] ON;

INSERT INTO [Author] ([Id], [Name], [Surname])
SELECT [temp].[Id]
	,[temp].[Name]
	,[temp].[Surname]
FROM @Author AS [temp]
LEFT JOIN [Author] AS [actual] on [actual].[Id] = [temp].[Id]
WHERE [actual].[Id] IS NULL

SET IDENTITY_INSERT [Author] OFF;
