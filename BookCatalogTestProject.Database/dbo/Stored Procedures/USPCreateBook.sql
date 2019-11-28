CREATE PROCEDURE [dbo].[USPCreateBook]
	@Title NVARCHAR(MAX),
	@PublicationDate DATETIME,
	@Rating INT,
	@PagesCount INT,
	@AuthorIds IntArrayType READONLY
AS
BEGIN

	DECLARE @ID INT = 0;
	DECLARE @TransactionName VARCHAR (50) = 'Book Insert';

	BEGIN TRANSACTION @TransactionName;
	BEGIN TRY

		INSERT INTO Book (Title, PublicationDate, Rating, PagesCount)
		VALUES (@Title, @PublicationDate, @Rating, @PagesCount);

		SET @ID = SCOPE_IDENTITY();

		INSERT INTO BookAuthor (BookId, AuthorId)
		SELECT @ID, Item
		FROM @AuthorIds;

	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			BEGIN
				ROLLBACK TRANSACTION @TransactionName;
			END;
	END CATCH;

	IF @@TRANCOUNT > 0
		BEGIN
		   COMMIT TRANSACTION @TransactionName;
		END;

END;