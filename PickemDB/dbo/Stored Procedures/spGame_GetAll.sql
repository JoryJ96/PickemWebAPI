CREATE PROCEDURE [dbo].[spGame_GetAll]
	@week int
AS
BEGIN
	SELECT *
	FROM dbo.Games
	WHERE week = @week
	ORDER BY GameId;
END
