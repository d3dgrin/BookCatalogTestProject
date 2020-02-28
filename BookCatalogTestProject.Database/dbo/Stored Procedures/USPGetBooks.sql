CREATE PROCEDURE [dbo].[USPGetBooks]
	@OrderBy NVARCHAR(max) = NULL,
	@Direction VARCHAR(10) NULL = NULL,
	@Start INT,
	@Length INT,
	@TotalFiltered INT OUT
AS
BEGIN

	DROP TABLE IF EXISTS [#ResultTempTable];

	SELECT b.[BookId], 
		b.Title, 
		b.PublicationDate, 
		b.Rating, 
		b.PagesCount,
		a.[AuthorId],
		a.Name,
		a.Surname
	INTO #ResultTempTable
	FROM [Book] b
	LEFT JOIN [BookAuthor] ba ON ba.BookId = b.[BookId]
	LEFT JOIN [Author] a ON a.[AuthorId] = ba.AuthorId
	ORDER BY
	CASE WHEN @OrderBy = 'BookId' AND @Direction = 'asc' THEN b.[BookId] END ASC,
	CASE WHEN @OrderBy = 'Title' AND @Direction = 'asc' THEN [Title] END ASC,
	CASE WHEN @OrderBy = 'PublicationDate' AND @Direction = 'asc' THEN [PublicationDate] END ASC,
	CASE WHEN @OrderBy = 'Rating' AND @Direction = 'asc' THEN [Rating] END ASC,
	CASE WHEN @OrderBy = 'PagesCount' AND @Direction = 'asc' THEN [PagesCount] END ASC,

	CASE WHEN @OrderBy = 'BookId' AND @Direction = 'desc' THEN b.[BookId] END DESC,
	CASE WHEN @OrderBy = 'Title' AND @Direction = 'desc' THEN [Title] END DESC,
	CASE WHEN @OrderBy = 'PublicationDate' AND @Direction = 'desc' THEN [PublicationDate] END DESC,
	CASE WHEN @OrderBy = 'Rating' AND @Direction = 'desc' THEN [Rating] END DESC,
	CASE WHEN @OrderBy = 'PagesCount' AND @Direction = 'desc' THEN [PagesCount] END DESC

	OFFSET @Start ROWS
	FETCH FIRST @Length ROWS ONLY

	SELECT * FROM #ResultTempTable;
	SELECT @TotalFiltered = COUNT(*) FROM #ResultTempTable;

END