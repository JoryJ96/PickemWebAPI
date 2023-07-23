using System.ComponentModel;

namespace PickemWPFUI.Library.Models
{
    public class Game : INotifyPropertyChanged
    {
        private bool _isHomeClicked;
        private bool _isAwayClicked;
        private bool _isButtonClickable;

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

        public bool IsHomeClicked
        {
            get { return _isHomeClicked; }
            set { 
                _isHomeClicked = value;
                OnPropertyChanged(nameof(IsHomeClicked));
            }
        }

        public bool IsAwayClicked
        {
            get { return _isAwayClicked; }
            set { 
                _isAwayClicked = value;
                OnPropertyChanged(nameof(IsAwayClicked));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
