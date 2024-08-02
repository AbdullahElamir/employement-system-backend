using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Register Controller Test";
        }
    }
}
