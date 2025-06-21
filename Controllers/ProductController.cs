using ForumWebApp.Data;
using ForumWebApp.Interfaces;
using ForumWebApp.Models;
using ForumWebApp.Repository;
using ForumWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await _productRepository.GetAll();
            return View(products);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return NotFound();

            var categories = await _productRepository.GetCategoriesByProductAsync(id);
            var studio = await _productRepository.GetStudioByProductAsync(id);

            var viewModel = new ProductDetailViewModel
            {
                Categories = categories,
                Product = product,
                Studio = studio
            };
            return View(viewModel);
        }
    }
}
