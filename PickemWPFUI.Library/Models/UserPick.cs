namespace PickemWPFUI.Library.Models
{
    public class UserPick
    {
        public string GameID { get; set; }
        public string Team { get; set; }
        public double Spread { get; set; }
        public string TimeSlot { get; set; }

        // Used to determine if the game is DAL game without iterating over the Games list every time a pick is made
        public string OppTeam { get; set;  }
    }
}
