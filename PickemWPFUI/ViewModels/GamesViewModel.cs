using Caliburn.Micro;
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

        public StackPanel GamesStackPanel
        {
            get { return _gamesStackPanel; }
        }

        // Automatically populate list of games using the games table
        public void InitializeList()
        {
            // string is just a placeholder here -- will be a 'Game' object. This comes from the API that the admin populates manually
            List<string> gamesToPopulate = new List<string>();

            // For each 'game' in gamesToPopulate, get the gameId and pass it to _gamesStackPanel.Find()
            //foreach (var gameToPopulate in gamesToPopulate)
            //{
            //    string gameId = gameToPopulate.gameId;

            //    DockPanel game = (DockPanel)_gamesStackPanel.FindName(gameId);

            //    List<Button> buttons = game.Children.OfType<Button>().ToList();

            //    buttons[0].Content = $"{gameToPopulate.Home} {gameToPopulate.HomeSpread}";
            //    buttons[1].Content = $"{gameToPopulate.Away} {gameToPopulate.AwaySpread}";
            //}
        }

        //public void Clicked(object sender, EventArgs e)
        //{
        //    Button btn = (Button)sender;
        //    var btnContent = (System.Xml.XmlElement)btn.Content;

        //    string[] teamInfo = btnContent.InnerText.Split(' ');
            

        //    // TODO: Process selection
        //    // Store in a binding list?
        //}

        //public void SubmitPicks(object sender, EventArgs e)
        //{
        //    // However we stored the pick set, fire that off to the API
        //}
    }
}
