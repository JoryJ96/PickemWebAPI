﻿using Microsoft.Extensions.Configuration;
using PickemWebAPI.Library.Internal.DataAccess;
using PickemWebAPI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickemWebAPI.Library.DataAccess
{
    public class UserData
    {
        private readonly IConfiguration _config;

        public UserData(IConfiguration config)
        {
            _config = config;
        }
        public List<UserModel> GetUserById(string Id)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            var p = new { ID = Id };

            var output = sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", p, "PickemDB");

            return output;
        }
    }
}
