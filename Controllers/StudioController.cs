using ForumWebApp.Data;
using ForumWebApp.Interfaces;
using ForumWebApp.Models;
using ForumWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumWebApp.Controllers
{
    public class StudioController : Controller
    {

        private readonly IStudioRepository _studioRepository;

        public StudioController(AppDbContext context,IStudioRepository studioRepository)
        {

            _studioRepository = studioRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Studio> studios = await _studioRepository.GetAllAsync();
            return View(studios);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var studio = await _studioRepository.GetByIdAsync(id);
            if (studio == null) return NotFound();

            var products = await _studioRepository.GetProductsByStudioAsync(id);
            var address = await _studioRepository.GetAddressAsync(id);


            var viewModel = new StudioDetailViewModel
            {
                Address = address,
                Studio = studio,
                Products = products,

            };

            return View(viewModel);
        }
    }
}
