DECLARE @Book TABLE 
(
	[Id]				INT NOT NULL,
	[Title]				VARCHAR(128) NOT NULL,
	[PublicationDate]	DATE NOT NULL,
	[Rating]			TINYINT NOT NULL,
	[PagesCount]		INT NOT NULL
);

INSERT INTO @Book ([Id], [Title], [PublicationDate], [Rating], [PagesCount])
VALUES
(1, 'Life is What You Make It', '2011-01-01', 8, 224),
(2, 'Wish I Could Tell You', '2019-10-04', 6, 288),
(3, 'You are the Best Wife: A True Love Story', '2015-11-23', 7, 248),
(4, 'The Girl Who Knew Too Much: What if the Loved One You Lost Were to Come Back?', '2017-04-14', 5, 224);

SET IDENTITY_INSERT [Book] ON;

INSERT INTO [Book] ([Id], [Title], [PublicationDate], [Rating], [PagesCount])
SELECT [temp].[Id]
	,[temp].[Title]
	,[temp].[PublicationDate]
	,[temp].[Rating]
	,[temp].[PagesCount]
FROM @Book AS [temp]
LEFT JOIN [Book] AS [actual] on [actual].[Id] = [temp].[Id]
WHERE [actual].[Id] IS NULL

SET IDENTITY_INSERT [Book] OFF;
