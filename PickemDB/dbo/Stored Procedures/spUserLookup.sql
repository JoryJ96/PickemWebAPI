CREATE PROCEDURE [dbo].[spUserLookup]
	@Id nvarchar(128)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM dbo.Users
	WHERE Id = @Id;
END
