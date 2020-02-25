CREATE PROCEDURE [dbo].[USPGetAuthors]
	@OrderBy NVARCHAR(max) = NULL,
	@Direction VARCHAR(10) NULL = NULL,
	@Start INT,
	@Length INT,
	@TotalFiltered INT OUT
AS
BEGIN

	DROP TABLE IF EXISTS [#ResultTempTable];

	SELECT [AuthorId], [Name], [Surname]
	INTO #ResultTempTable
	FROM [Author]
	ORDER BY
	CASE WHEN @ORDERBY = 'AuthorId' AND @Direction = 'asc' THEN [AuthorId] END ASC,
	CASE WHEN @ORDERBY = 'Name' AND @Direction = 'asc' THEN [Name] END ASC,
	CASE WHEN @ORDERBY = 'Surname' AND @Direction = 'asc' THEN [Surname] END ASC,

	CASE WHEN @ORDERBY = 'AuthorId' AND @Direction = 'desc' THEN [AuthorId] END DESC,
	CASE WHEN @ORDERBY = 'Name' AND @Direction = 'desc' THEN [Name] END DESC,
	CASE WHEN @ORDERBY = 'Surname' AND @Direction = 'desc' THEN [Surname] END DESC

	OFFSET @Start ROWS
	FETCH FIRST @Length ROWS ONLY

	SELECT * FROM #ResultTempTable;
	SELECT @TotalFiltered = COUNT(*) FROM #ResultTempTable;

END