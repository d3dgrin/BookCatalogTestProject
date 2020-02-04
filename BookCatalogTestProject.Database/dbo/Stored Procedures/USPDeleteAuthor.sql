CREATE PROCEDURE [dbo].[USPDeleteAuthor]
	@Id int
AS
BEGIN

	DELETE FROM [BookAuthor]
	WHERE [AuthorId] = @Id;

	DELETE FROM [Author]
	WHERE [AuthorId] = @Id;

END;