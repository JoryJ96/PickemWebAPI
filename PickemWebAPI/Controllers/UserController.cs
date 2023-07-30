using Microsoft.AspNet.Identity;
using PickemWebAPI.Library.DataAccess;
using PickemWebAPI.Library.Models;
using PickemWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace PickemWebAPI.Controllers
{
    [Authorize(Roles = "Basic, Admin")]
    public class UserController : ApiController
    {
        public UserModel GetById()
        {
            string userId = RequestContext.Principal.Identity.GetUserId();
            UserData data = new UserData();

            return data.GetUserById(userId).FirstOrDefault();
        }
    }
}
