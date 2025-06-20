using Microsoft.AspNetCore.Mvc;

namespace ForumWebApp.Controllers
{
    public class StudioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
