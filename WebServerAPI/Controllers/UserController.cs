using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebServerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly List<string> Users = new List<string>();

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Users;
        }

        // POST /User
        [HttpPost]
        public ActionResult<string> Post([FromBody] string user)
        {
            Users.Add(user);
            return Ok($"User '{user}' added");
        }
    }
}
