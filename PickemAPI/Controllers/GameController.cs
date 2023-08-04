using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickemWebAPI.Library.DataAccess;
using PickemWebAPI.Library.Models;

namespace PickemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IConfiguration _config;

        public GameController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public List<GameModel> Get()
        {
            GameData data = new GameData(_config);

            return data.GetGames();
        }
    }
}
