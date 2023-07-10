using Caliburn.Micro;
using PickemWPFUI.Helpers;
using PickemWPFUI.Library.Api;
using PickemWPFUI.Library.Models;
using PickemWPFUI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
        private IGameEndpoint _gameEndpoint;

        public GamesViewModel(IEventAggregator events, IAPIHelper apiClient, IGameEndpoint gameEndpoint)
        {
            _apiClient = apiClient;
            _events = events;
            _gameEndpoint = gameEndpoint;
        }

        private async Task LoadGames()
        {
            var gameList = await _gameEndpoint.GetAll();
            Games = new BindingList<Game>(gameList);

            foreach (Game gameToPopulate in _games)
            {
                string gameId = gameToPopulate.gameId;

                DockPanel game = (DockPanel)_gamesStackPanel.FindName(gameId);

                List<Button> buttons = game.Children.OfType<Button>().ToList();

                buttons[0].Content = $"{gameToPopulate.Home} {gameToPopulate.HomeSpread}";
                buttons[1].Content = $"{gameToPopulate.Away} {gameToPopulate.AwaySpread}";
            }
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadGames();
        }

        private BindingList<Game> _games;

        public BindingList<Game> Games
        {
            get { return _games; }
            set { 
                _games = value;
                NotifyOfPropertyChange(() => Games);
            }
        }


        public StackPanel GamesStackPanel
        {
            get { return _gamesStackPanel; }
            set {
                _gamesStackPanel = value;
                NotifyOfPropertyChange(() => GamesStackPanel);
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
