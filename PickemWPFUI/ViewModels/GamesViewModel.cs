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
        private ILoggedInUserModel _loggedInUser;

        private ObservableCollection<UserPick> _pickSet = new ObservableCollection<UserPick>();

        public GamesViewModel(IGameEndpoint gameEndpoint, ILoggedInUserModel loggedInUser)
        {
            _gameEndpoint = gameEndpoint;
            _loggedInUser = loggedInUser;
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

            if (_loggedInUser.PickSet != null)
            {
                foreach (UserPick pick in _loggedInUser.PickSet)
                {
                    PickSet.Add(pick);
                }
            }
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

        public ObservableCollection<UserPick> PickSet
        {
            get { return _pickSet; }
            set {  
                _pickSet = value;
                NotifyOfPropertyChange(() => PickSet);
            }
        }


        public void HomeButtonClicked(Game game)
        {
            UserPick pick = new UserPick
            {
                GameID = game.gameId,
                Team = game.Home,
                Spread = game.HomeSpread,
                TimeSlot = game.TimeSlot
            };

            if (game.IsHomeClicked)
            {
                game.IsHomeClicked = false;

                Remove(game);
                NotifyOfPropertyChange(() => PickSet);
            } else
            {
                game.IsHomeClicked = true;

                PickSet.Add(pick);
                NotifyOfPropertyChange(() => PickSet);
            }
        }

        public void AwayButtonClicked(Game game)
        {
            UserPick pick = new UserPick
            {
                GameID = game.gameId,
                Team = game.Away,
                Spread = game.AwaySpread,
                TimeSlot = game.TimeSlot
            };

            if (game.IsAwayClicked)
            {
                game.IsAwayClicked = false;

                Remove(game);
                NotifyOfPropertyChange(() => PickSet);
            }
            else
            {
                game.IsAwayClicked = true;

                PickSet.Add(pick);
                NotifyOfPropertyChange(() => PickSet);
            }
        }

        private void Remove(Game game)
        {
            foreach (UserPick gameToRemove in PickSet)
            {
                if (gameToRemove.GameID == game.gameId)
                {
                    PickSet.Remove(gameToRemove);
                    break;
                }
            }
        }

        public void SubmitPicks(object sender, EventArgs e)
        {
            // However we stored the pick set, fire that off to the API
        }
    }
}
