using ForumWebApp.Data;
using ForumWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Product> products = _context.Products.ToList();
            return View(products);
        }
        public IActionResult Detail(int id)
        {
            Product product = _context.Products.Include(a=> a.Studio).Include(p => p.ProductCategories).ThenInclude(pc => pc.Category).SingleOrDefault(p => p.Id == id);
            return View(product);
        }
    }
}
