namespace PickemWebAPI.Library.Models
{
    public class GameModel
    {
        public string gameId { get; set; }
        public int Week { get; set; }
        public string Home { get; set; }
        public double HomeSpread { get; set; }
        public string Away { get; set; }
        public double AwaySpread { get; set; }
        public string TimeSlot { get; set; }
    }
}
