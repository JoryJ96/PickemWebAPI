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

            foreach (Game game in Games)
            {
                GamesDTO.Add(game);
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

        private ObservableCollection<Game> _gamesDTO = new ObservableCollection<Game>();

        public ObservableCollection<Game> GamesDTO
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
