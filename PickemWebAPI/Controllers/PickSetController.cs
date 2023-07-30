using PickemWebAPI.Library.DataAccess;
using PickemWebAPI.Library.Models;
using PickemWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PickemWebAPI.Controllers
{
    public class PickSetController : ApiController
    {
        [Authorize(Roles = "Basic, Admin")]
        public void Post(PickSetModel model)
        {
            PickSetData data = new PickSetData();

            data.SaveData(model);
        }
    }
}
