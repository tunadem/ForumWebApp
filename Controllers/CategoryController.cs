using Microsoft.AspNetCore.Mvc;

namespace ForumWebApp.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
