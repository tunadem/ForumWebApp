using ForumWebApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace ForumWebApp.Controllers
{
    public class StudioController : Controller
    {
        private readonly AppDbContext _context;

        public StudioController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var studios = _context.Studios.ToList();
            return View(studios);
        }
    }
}
