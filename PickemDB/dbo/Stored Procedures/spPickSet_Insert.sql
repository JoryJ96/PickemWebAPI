CREATE PROCEDURE [dbo].[spPickSet_Insert]
	@UserID nvarchar(128),
	@MNFSelection nvarchar(50),
	@SNFSelection nvarchar(50),
	@FirstOptionalSelection nvarchar(50),
	@SecondOptionalSelection nvarchar(50),
	@ThirdOptionalSelection nvarchar(50),
	@FourthOptionalSelection nvarchar(50),
	@FifthOptionalSelection nvarchar(50),
	@TripleOption nvarchar(50),
	@Username nvarchar(50)
AS
	BEGIN
	INSERT INTO dbo.PickSets(UserID, MNFSelection, SNFSelection, FirstOptionalSelection, SecondOptionalSelection, ThirdOptionalSelection, FourthOptionalSelection, FifthOptionalSelection, TripleOption, Username)
	VALUES (@UserID, @MNFSelection, @SNFSelection, @FirstOptionalSelection, @SecondOptionalSelection, @ThirdOptionalSelection, @FourthOptionalSelection, @FifthOptionalSelection, @TripleOption, @Username);
END
