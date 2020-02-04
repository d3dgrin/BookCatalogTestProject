CREATE PROCEDURE [dbo].[USPGetBooks]
AS
BEGIN

	SELECT b.[BookId], 
		b.Title, 
		b.PublicationDate, 
		b.Rating, 
		b.PagesCount,
		a.[AuthorId],
		a.Name,
		a.Surname
	FROM [Book] b
	LEFT JOIN [BookAuthor] ba ON ba.BookId = b.[BookId]
	LEFT JOIN [Author] a ON a.[AuthorId] = ba.AuthorId;

END