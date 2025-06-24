using ForumWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class UserInfoViewComponent : ViewComponent
{
    private readonly UserManager<AppUser> _userManager;

    public UserInfoViewComponent(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        if (!User.Identity.IsAuthenticated) return View("Anonymous");

        var user = await _userManager.GetUserAsync(UserClaimsPrincipal);
        return View(user);
    }
}
