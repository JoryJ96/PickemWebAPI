using PickemWebAPI.Library.Internal.DataAccess;
using PickemWebAPI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickemWebAPI.Library.DataAccess
{
    public class PickSetData
    {
        public void SaveData(PickSetModel data)
        {
            // Save a model to the DB by calling SqlDataAccess.SaveData method, passing in the name of the Stored Procedure ("spPickset_Post"), the model, and the name of the DB (PickemDB)
            // We need to grab the current week from the Games table, and also pass the PostedDate to the table from here
            SqlDataAccess sql = new SqlDataAccess();

            sql.SaveData("spPickSet_Insert", data, "PickemDB");
        }
    }
}
