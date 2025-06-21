using ForumWebApp.Data;
using ForumWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumWebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.ToList();
            return View(categories);
        }
        public IActionResult Detail(int id)
        {
            Category category = _context.Categories.SingleOrDefault(p => p.Id == id);
            return View(category);
        }
    }
}
