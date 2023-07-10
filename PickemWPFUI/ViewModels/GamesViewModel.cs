using Caliburn.Micro;
using PickemWPFUI.Helpers;
using PickemWPFUI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PickemWPFUI.ViewModels
{
    public class GamesViewModel : Screen
    {
        private StackPanel _gamesStackPanel;

        private IAPIHelper _apiClient;
        private IEventAggregator _events;

        public GamesViewModel(IEventAggregator events, IAPIHelper apiClient)
        {
            _apiClient = apiClient;
            _events = events;

            InitializeList();
        }

        public StackPanel GamesStackPanel
        {
            get { return _gamesStackPanel; }
            set {
                _gamesStackPanel = value;
                NotifyOfPropertyChange(() => GamesStackPanel);
            }
        }

        // Automatically populate list of games using the games table
        public void InitializeList()
        {
            // This list comes from a table that the admin populates manually
            List<Game> gamesToPopulate = new List<Game>();

            foreach (Game gameToPopulate in gamesToPopulate)
            {
                string gameId = gameToPopulate.gameId;

                DockPanel game = (DockPanel)_gamesStackPanel.FindName(gameId);

                List<Button> buttons = game.Children.OfType<Button>().ToList();

                buttons[0].Content = $"{gameToPopulate.Home} {gameToPopulate.HomeSpread}";
                buttons[1].Content = $"{gameToPopulate.Away} {gameToPopulate.AwaySpread}";
            }
        }

        public void Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var btnContent = (System.Xml.XmlElement)btn.Content;

            string[] teamInfo = btnContent.InnerText.Split(' ');


            // TODO: Process selection
            // Store in a binding list?
        }

        public void SubmitPicks(object sender, EventArgs e)
        {
            // However we stored the pick set, fire that off to the API
        }
    }
}
