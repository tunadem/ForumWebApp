using ForumWebApp.Data;
using ForumWebApp.Models;
using Microsoft.AspNetCore.Mvc;

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
            Product product = _context.Products.SingleOrDefault(p => p.Id == id);
            return View(product);
        }
    }
}
