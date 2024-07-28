using Microsoft.AspNetCore.Mvc;

namespace WebServerAPI.Controllers
{
    public class LoginController : Controller
    {
        // hello world
        public IActionResult Index()
        {
            return View();
        }
    }
}
