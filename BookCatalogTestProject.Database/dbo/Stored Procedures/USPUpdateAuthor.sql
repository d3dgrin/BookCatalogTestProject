CREATE PROCEDURE [dbo].[USPUpdateAuthor]
	@Id INT,
	@Name NVARCHAR(MAX),
	@Surname NVARCHAR(MAX)
AS
BEGIN

	UPDATE [Author]
	SET [Name] = @Name, [Surname] = @Surname
	WHERE [Id] = @Id;

END;