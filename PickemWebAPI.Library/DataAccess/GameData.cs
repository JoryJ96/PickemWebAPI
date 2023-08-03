using Microsoft.Extensions.Configuration;
using PickemWebAPI.Library.Internal.DataAccess;
using PickemWebAPI.Library.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;

namespace PickemWebAPI.Library.DataAccess
{
    public class GameData
    {
        private readonly IConfiguration _config;

        public GameData(IConfiguration config)
        {
            _config = config;
        }
        public List<GameModel> GetGames()
        {
            
            SqlDataAccess sql = new SqlDataAccess(_config);

            var output = sql.LoadData<GameModel, dynamic>("dbo.spGame_GetAll", new { }, "PickemDB");

            return output;
        }
    }
}
