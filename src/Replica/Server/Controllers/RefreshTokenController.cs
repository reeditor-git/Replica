using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Replica.Server.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    //[Authorize]
    public class RefreshTokenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
