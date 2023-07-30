CREATE TABLE [dbo].[PickSets]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserID] NVARCHAR(128) NOT NULL, 
    [MNFSelection] NVARCHAR(50) NOT NULL, 
    [SNFSelection] NVARCHAR(50) NOT NULL, 
    [FirstOptionalSelection] NVARCHAR(50) NOT NULL, 
    [SecondOptionalSelection] NVARCHAR(50) NOT NULL, 
    [ThirdOptionalSelection] NVARCHAR(50) NOT NULL, 
    [FourthOptionalSelection] NVARCHAR(50) NOT NULL, 
    [FifthOptionalSelection] NVARCHAR(50) NOT NULL, 
    [TripleOption] NVARCHAR(50) NULL, 
    [Week] INT NULL, 
    [Username] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_PickSets_Users] FOREIGN KEY (UserID) REFERENCES Users(ID)
)
