namespace PickemWPFUI.Library.Models
{
    public interface ILoggedInUserModel
    {
        string AuthToken { get; set; }
        string EmailAddress { get; set; }
        string Id { get; set; }
        int Losses { get; set; }
        string Name { get; set; }
        string PhoneNumber { get; set; }
        int Rank { get; set; }
        int Wins { get; set; }
    }
}