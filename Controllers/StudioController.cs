using ForumWebApp.Data;
using ForumWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            List<Studio> studios = _context.Studios.ToList();
            return View(studios);
        }
        public IActionResult Detail(int id)
        {
            Studio studio = _context.Studios.Include(p=> p.Address).Include(p=> p.Products).SingleOrDefault(p => p.Id == id);
            return View(studio);
        }
    }
}
