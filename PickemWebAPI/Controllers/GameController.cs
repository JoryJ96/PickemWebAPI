using PickemWebAPI.Library.DataAccess;
using PickemWebAPI.Library.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace PickemWebAPI.Controllers
{
    [Authorize(Roles = "Basic, Admin")]
    public class GameController : ApiController
    {
        public List<GameModel> Get()
        {
            GameData data = new GameData();

            return data.GetGames();
        }
    }
}
