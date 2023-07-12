using Caliburn.Micro;
using PickemWPFUI.Helpers;
using PickemWPFUI.Library.Api;
using PickemWPFUI.Library.Models;
using PickemWPFUI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PickemWPFUI.ViewModels
{
    public class GamesViewModel : Screen
    {
        private IGameEndpoint _gameEndpoint;

        public GamesViewModel(IGameEndpoint gameEndpoint)
        {
            _gameEndpoint = gameEndpoint;
        }

        private async Task LoadGames()
        {
            Games = await _gameEndpoint.GetAll();

            ObservableCollection<GameDisplay> loadedGames = new ObservableCollection<GameDisplay>();
            foreach (Game game in Games)
            {
                loadedGames.Add(new GameDisplay
                {
                    Home = $"{game.Home} {game.HomeSpread}",
                    Away = $"{game.Away} {game.AwaySpread}"
                });
            }

            GamesDTO = loadedGames;
        }

        private List<Button> GetButtons(Game game)
        {
            if (game != null)
            {
                List<Button> output = new List<Button>
                {
                    new Button
                    {
                        Content = $"{game.Home} {game.HomeSpread}",
                        Padding = new Thickness(5),
                        Margin = new Thickness(5),
                        MinWidth = 100
                    },

                    new Button
                    {
                        Content = $"{game.Away} {game.AwaySpread}",
                        Padding = new Thickness(5),
                        Margin = new Thickness(5),
                        MinWidth = 100
                    }
                };

                return output;
            } else
            {
                throw new Exception("Game not found, but I tried to make buttons anyway!");
            }
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadGames();
        }

        private List<Game> _games;

        public List<Game> Games
        {
            get { return _games; }
            set { 
                _games = value;
                NotifyOfPropertyChange(() => Games);
            }
        }

        private ObservableCollection<GameDisplay> _gamesDTO;

        public ObservableCollection<GameDisplay> GamesDTO
        {
            get { return _gamesDTO; }
            set { 
                _gamesDTO = value;
                NotifyOfPropertyChange(() => GamesDTO);
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
