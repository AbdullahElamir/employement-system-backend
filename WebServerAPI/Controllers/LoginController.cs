using Microsoft.AspNetCore.Mvc;

namespace WebServerAPI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
