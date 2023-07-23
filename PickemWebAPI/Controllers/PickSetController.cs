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
        [Authorize]
        public async Task Post(PickSetAPIModel model)
        {
            Console.WriteLine();
        }
    }
}
