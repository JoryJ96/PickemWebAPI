CREATE TABLE [dbo].[Games]
(
	[GameID] INT NOT NULL PRIMARY KEY, 
    [Week] INT NOT NULL, 
    [Home] NCHAR(10) NOT NULL, 
    [Away] NCHAR(10) NOT NULL, 
    [Spread] REAL NOT NULL 
)
