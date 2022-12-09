using Microsoft.AspNetCore.Mvc;

namespace Replica.Server.Controllers
{
    public class RefreshTokenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
