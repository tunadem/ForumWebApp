using ForumWebApp.Data;
using ForumWebApp.Models;
using ForumWebApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ForumWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _context;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public IActionResult Login()
        {
            var model = new LoginRegisterViewModel
            {
                LoginViewModel = new LoginViewModel(),
                RegisterViewModel = new RegisterViewModel()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                var model = new LoginRegisterViewModel
                {
                    LoginViewModel = loginViewModel,
                    RegisterViewModel = new RegisterViewModel()
                };
                return View("Login", model);
            }

            var user = await _userManager.FindByEmailAsync(loginViewModel.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                    if (result.Succeeded)
                        return RedirectToAction("Index", "Home");
                }

                TempData["Error"] = "Invalid password. Please try again.";
            }
            else
            {
                TempData["Error"] = "User not found. Please check your email address.";
            }

            var errorModel = new LoginRegisterViewModel
            {
                LoginViewModel = loginViewModel,
                RegisterViewModel = new RegisterViewModel()
            };

            return View("Login", errorModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginRegisterViewModel model)
        {
            var registerViewModel = model.RegisterViewModel;

            if (!ModelState.IsValid)
            {
                return View("Login", model);
            }

            var user = new AppUser
            {
                UserName = registerViewModel.UserName,
                Email = registerViewModel.EmailAddress
            };

            var result = await _userManager.CreateAsync(user, registerViewModel.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View("Login", model);
        }






    }
}
