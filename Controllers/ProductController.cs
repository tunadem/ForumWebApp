using ForumWebApp.Data;
using ForumWebApp.Interfaces;
using ForumWebApp.Models;
using ForumWebApp.Repository;
using ForumWebApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IAppUserRepository _userRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IStudioRepository _studioRepository;
        private readonly UserManager<AppUser> _userManager;

        public ProductController(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IStudioRepository studioRepository,
            IAppUserRepository userRepository,
            ICommentRepository commentRepository,
            UserManager<AppUser> userManager)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _studioRepository = studioRepository;
            _userRepository = userRepository;
            _commentRepository = commentRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string? query)
        {
            IEnumerable<Product> products;

            if (!string.IsNullOrEmpty(query))
            {
                products = await _productRepository.GetSearchAsync(query);
            }
            else
            {
                products = await _productRepository.GetAll();
            }

            return View(products);
        }

        public async Task<IActionResult> Detail(int id)
        {
            
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return NotFound();

            var categories = await _productRepository.GetCategoriesByProductAsync(id);
            var studio = await _productRepository.GetStudioByProductAsync(id);
            var comments = await _productRepository.GetCommentsByProductAsync(id);

            var viewModel = new ProductDetailViewModel
            {
                Categories = categories,
                Product = product,
                Studio = studio,
                Comments = comments
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(int productId, string commentTitle, string commentText)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            await _productRepository.AddCommentToProductAsync(productId, user.Id, commentTitle, commentText);

            return RedirectToAction("Detail", "Product", new { id = productId });
        }


        [HttpPost]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null) return NotFound();

            var productId = comment.Review.ProductId;

            await _commentRepository.DeleteAsync(id);

            return RedirectToAction("Detail", "Product", new { id = productId });
        }
        [HttpPost]
        public async Task<IActionResult> EditComment(int id, string content, int productId)
        {
            await _commentRepository.EditAsync(id, null, content);
            return RedirectToAction("Detail", "Product", new { id = productId });

        }








    }
}
