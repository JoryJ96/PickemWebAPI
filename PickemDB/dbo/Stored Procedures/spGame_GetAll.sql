CREATE PROCEDURE [dbo].[spGame_GetAll]
AS
BEGIN
	SELECT *
	FROM dbo.Games
	ORDER BY GameId;
END
