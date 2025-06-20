using Microsoft.AspNetCore.Mvc;

namespace ForumWebApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
