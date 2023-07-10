using PickemWebAPI.Library.Internal.DataAccess;
using PickemWebAPI.Library.Models;
using System.Collections.Generic;

namespace PickemWebAPI.Library.DataAccess
{
    public class GameData
    {
        public List<GameModel> GetGames()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = sql.LoadData<GameModel, dynamic>("dbo.spGame_GetAll", new { }, "PickemDB");

            return output;
        }
    }
}
