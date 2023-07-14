namespace PickemWPFUI.Library.Models
{
    public class Game
    {
        public string gameId { get; set; }
        public int Week { get; set; }
        public string Home { get; set; }
        public double HomeSpread { get; set; }
        public string Away { get; set; }
        public double AwaySpread { get; set; }
        public string TimeSlot { get; set; }

        public string DisplayHome { 
            get
            {
                return $"{Home} {HomeSpread}";
            }
        }

        public string DisplayAway
        {
            get
            {
                return $"{Away} {AwaySpread}";
            }
        }

    }
}
