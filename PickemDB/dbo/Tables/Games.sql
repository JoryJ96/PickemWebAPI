CREATE TABLE [dbo].[Games]
(
	[GameID] INT NOT NULL PRIMARY KEY, 
    [Week] INT NOT NULL, 
    [Home] NCHAR(10) NOT NULL, 
    [Away] NCHAR(10) NOT NULL, 
    [HomeSpread] REAL NOT NULL, 
    [AwaySpread] REAL NOT NULL, 
    [TimeSlot] NVARCHAR(10) NOT NULL 
)
