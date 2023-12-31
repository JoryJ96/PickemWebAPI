﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickemWebAPI.Library.DataAccess;
using PickemWebAPI.Library.Models;

namespace PickemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PickSetController : ControllerBase
    {
        private readonly IConfiguration _config;

        public PickSetController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        public void Post(PickSetModel model)
        {
            PickSetData data = new PickSetData(_config);

            data.SaveData(model);
        }
    }
}
