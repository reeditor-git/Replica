using Microsoft.AspNetCore.Mvc;

namespace Replica.Server.Controllers.Users
{
    public class RefreshTokenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
