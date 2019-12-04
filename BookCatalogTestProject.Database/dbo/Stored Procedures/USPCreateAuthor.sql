CREATE PROCEDURE [dbo].[USPCreateAuthor]
	@Name NVARCHAR(MAX),
	@Surname NVARCHAR(MAX)
AS
BEGIN

	INSERT INTO [Author] ([Name], [Surname])
	VALUES (@Name, @Surname);

END;