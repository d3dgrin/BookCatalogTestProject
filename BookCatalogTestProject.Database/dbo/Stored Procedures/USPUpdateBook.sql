CREATE PROCEDURE [dbo].[USPUpdateBook]
	@Id INT,
	@Title NVARCHAR(MAX),
	@PublicationDate DATETIME,
	@Rating INT,
	@PagesCount INT,
	@AuthorIds IntArrayType READONLY
AS
BEGIN

	UPDATE [Book]
	SET [Title] = @Title, [PublicationDate] = @PublicationDate, [Rating] = @Rating, [PagesCount] = @PagesCount
	WHERE [BookId] = @Id;

	DELETE FROM [BookAuthor]
	WHERE [BookId] = @Id;

	INSERT INTO [BookAuthor] ([BookId], [AuthorId])
	SELECT @Id, Item
	FROM @AuthorIds;

END