using Microsoft.AspNetCore.Mvc;

namespace WebServerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobController : Controller
    {
        public String get()
        {
            return "Job Controller Test";
        }
    }
}
