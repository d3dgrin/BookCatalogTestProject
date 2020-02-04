CREATE PROCEDURE [dbo].[USPGetBooks]
AS
BEGIN

	SELECT b.[BookId] AS BookId, 
		b.Title, 
		b.PublicationDate, 
		b.Rating, 
		b.PagesCount,
		a.[AuthorId] AS AuthorId,
		a.Name,
		a.Surname
	FROM [Book] b
	LEFT JOIN [BookAuthor] ba ON ba.BookId = b.[BookId]
	LEFT JOIN [Author] a ON a.[AuthorId] = ba.AuthorId;

END