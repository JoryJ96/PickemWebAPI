using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickemWebAPI.Library.DataAccess;
using PickemWebAPI.Library.Models;
using System.Security.Claims;

namespace PickemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Basic, Admin")]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;

        public UserController(IConfiguration config)
        {
            _config = config;
        }

        public UserModel GetById()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            UserData data = new UserData(_config);

            return data.GetUserById(userId).FirstOrDefault();
        }
    }
}
