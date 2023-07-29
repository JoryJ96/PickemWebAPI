using Caliburn.Micro;
using PickemWPFUI.Helpers;
using PickemWPFUI.Library.Api;
using PickemWPFUI.Library.Helpers;
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
        private int _selectionCounter;
        private bool CanSelectGame => SelectionCounter < 7;

        private IGameEndpoint _gameEndpoint;
        private ILoggedInUserModel _loggedInUser;
        private IPickSetEndpoint _pickSetEndpoint;

        private ObservableCollection<UserPick> _pickSet = new ObservableCollection<UserPick>();
        private PickSetModel _verifiedPickSet = new PickSetModel();

        public GamesViewModel(IGameEndpoint gameEndpoint, ILoggedInUserModel loggedInUser, IPickSetEndpoint pickSetEndpoint)
        {
            _gameEndpoint = gameEndpoint;
            _loggedInUser = loggedInUser;
            _pickSetEndpoint = pickSetEndpoint;
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

        // List that is used to populate each button
        public List<Game> Games
        {
            get { return _games; }
            set { 
                _games = value;
                NotifyOfPropertyChange(() => Games);
            }
        }

        private ObservableCollection<Game> _gamesDTO = new ObservableCollection<Game>();

        // Buttons / Games
        public ObservableCollection<Game> GamesDTO
        {
            get { return _gamesDTO; }
            set { 
                _gamesDTO = value;
                NotifyOfPropertyChange(() => GamesDTO);
            }
        }

        // Users selections
        public ObservableCollection<UserPick> PickSet
        {
            get { return _pickSet; }
            set {  
                _pickSet = value;
                NotifyOfPropertyChange(() => PickSet);
            }
        }

        // For verification purposes. Not displayed on front end, but what gets shipped to API
        public PickSetModel VerifiedPickSet
        {
            get { return _verifiedPickSet; }
            set { _verifiedPickSet = value; }
        }

        public int SelectionCounter
        {
            get
            {
                return _selectionCounter;
            }
            set
            {
                _selectionCounter = value;
                NotifyOfPropertyChange(() => SelectionCounter);
                NotifyOfPropertyChange(() => CanSelectGame);
            }
        }

        public void HomeButtonClicked(Game game)
        {
            UserPick pick = new UserPick
            {
                GameID = game.gameId,
                Team = game.Home,
                Spread = game.HomeSpread,
                TimeSlot = game.TimeSlot,
                OppTeam = game.Away
            };

            if (game.IsHomeClicked)
            {
                if (ProcessSelection(pick, "remove"))
                {
                    game.IsHomeClicked = false;
                    Remove(game);
                    SelectionCounter--;
                }
            } else
            {
                if (CanSelectGame)
                {
                    if (ProcessSelection(pick, "add"))
                    {
                        game.IsHomeClicked = true;
                        SelectionCounter++;
                    }
                    else
                    {
                        MessageBox.Show($"Could not add pick because there was no slot available for {pick.TimeSlot}");
                    }
                }
            }
        }

        public void AwayButtonClicked(Game game)
        {
            UserPick pick = new UserPick
            {
                GameID = game.gameId,
                Team = game.Away,
                Spread = game.AwaySpread,
                TimeSlot = game.TimeSlot,
                OppTeam = game.Home
            };

            if (game.IsAwayClicked)
            {
                game.IsAwayClicked = false;
                Remove(game);
                ProcessSelection(pick, "remove");
                SelectionCounter--;
            }
            else
            {
                if (CanSelectGame)
                {
                    if (ProcessSelection(pick, "add"))
                    {
                        game.IsAwayClicked = true;
                        SelectionCounter++;
                    }
                    else
                    {
                        MessageBox.Show($"Could not add pick because there was no slot available for {pick.TimeSlot}");
                    }
                }
            }
        }

        private void Remove(Game game)
        {
            // Remove from pickset
            foreach (UserPick gameToRemove in PickSet)
            {
                if (gameToRemove.GameID == game.gameId)
                {
                    PickSet.Remove(gameToRemove);
                    NotifyOfPropertyChange(() => PickSet);
                    break;
                }
            }
        }

        public async Task SubmitPicks()
        {
            string userID = _loggedInUser.Id;

            VerifiedPickSet.UserID = userID;
            await _pickSetEndpoint.PostPickSet(VerifiedPickSet);
        }

        // Only handles VerifiedPickSet manipulation
        public bool ProcessSelection(UserPick pick, string command)
        {
            switch (pick.TimeSlot)
            {
                case "MNF":
                    if (command == "add")
                    {
                        VerifiedPickSet.MNFSelection = pick.Team;
                        PickSet.Add(pick);
                        NotifyOfPropertyChange(() => PickSet);
                    } else
                    {
                        VerifiedPickSet.MNFSelection = null;
                    }
                    // Add exception handling here even though it wont ever hit
                    return true;
                case "SNF":
                    if (command == "add")
                    {
                        VerifiedPickSet.SNFSelection = pick.Team;
                        PickSet.Add(pick);
                        NotifyOfPropertyChange(() => PickSet);
                    } else
                    {
                        VerifiedPickSet.SNFSelection = null;
                    }
                    return true;
                case "OPT":
                    if (command == "add")
                    {
                        if (VerifiedPickSet.FirstOptionalSelection == null)
                        {
                            VerifiedPickSet.FirstOptionalSelection = pick.Team;
                            PickSet.Add(pick);
                            NotifyOfPropertyChange(() => PickSet);
                            return true;
                        }
                        else if (VerifiedPickSet.SecondOptionalSelection == null)
                        {
                            VerifiedPickSet.SecondOptionalSelection = pick.Team;
                            PickSet.Add(pick);
                            NotifyOfPropertyChange(() => PickSet);
                            return true;
                        } else if (VerifiedPickSet.ThirdOptionalSelection == null)
                        {
                            VerifiedPickSet.ThirdOptionalSelection = pick.Team;
                            PickSet.Add(pick);
                            NotifyOfPropertyChange(() => PickSet);
                            return true;
                        }
                        else if (VerifiedPickSet.FourthOptionalSelection == null)
                        {
                            VerifiedPickSet.FourthOptionalSelection = pick.Team;
                            PickSet.Add(pick);
                            NotifyOfPropertyChange(() => PickSet);
                            return true;
                        }
                        else if (VerifiedPickSet.FifthOptionalSelection == null)
                        {
                            VerifiedPickSet.FifthOptionalSelection = pick.Team;
                            PickSet.Add(pick);
                            NotifyOfPropertyChange(() => PickSet);
                            return true;
                        } else { return false; }
                    } else
                    {
                        if (pick.TimeSlot == "MNF")
                        {
                            VerifiedPickSet.MNFSelection = null;
                            return true;
                        } else if (pick.TimeSlot == "SNF")
                        {
                            VerifiedPickSet.SNFSelection = null;
                            return true;
                        } else if (pick.TimeSlot == "OPT")
                        {
                            if (VerifiedPickSet.FirstOptionalSelection != null && VerifiedPickSet.FirstOptionalSelection.Contains(pick.Team))
                            {
                                VerifiedPickSet.FirstOptionalSelection = null;
                                return true;
                            } else if (VerifiedPickSet.SecondOptionalSelection != null && VerifiedPickSet.SecondOptionalSelection.Contains(pick.Team))
                            {
                                VerifiedPickSet.SecondOptionalSelection = null;
                                return true;
                            }
                            else if (VerifiedPickSet.ThirdOptionalSelection != null && VerifiedPickSet.ThirdOptionalSelection.Contains(pick.Team))
                            {
                                VerifiedPickSet.ThirdOptionalSelection = null;
                                return true;
                            }
                            else if (VerifiedPickSet.FourthOptionalSelection != null && VerifiedPickSet.FourthOptionalSelection.Contains(pick.Team))
                            {
                                VerifiedPickSet.FourthOptionalSelection = null;
                                return true;
                            }
                            else if (VerifiedPickSet.FifthOptionalSelection != null && VerifiedPickSet.FifthOptionalSelection.Contains(pick.Team))
                            {
                                VerifiedPickSet.FifthOptionalSelection = null;
                                return true;
                            }
                            else { return false; }
                        } else
                        {
                            return false;
                        }
                    }
            }

            // Wont reach this, but it gets the error to shut up?
            return false;
        }
    }
}
