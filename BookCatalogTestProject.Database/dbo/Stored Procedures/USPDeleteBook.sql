﻿CREATE PROCEDURE [dbo].[USPDeleteBook]
	@Id int
AS
BEGIN

	DELETE FROM [BookAuthor]
	WHERE [BookId] = @Id;

	DELETE FROM [Book]
	WHERE [BookId] = @Id;

END