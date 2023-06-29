CREATE TABLE [dbo].[Users]
(
	[Id] NVARCHAR(128) NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Wins] INT NOT NULL DEFAULT 0, 
    [Losses] INT NOT NULL DEFAULT 0, 
    [Rank] INT NOT NULL, 
    [EmailAddress] NVARCHAR(MAX) NULL, 
    [PhoneNumber] NVARCHAR(10) NULL
)
