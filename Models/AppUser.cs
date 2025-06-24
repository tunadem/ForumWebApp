using Microsoft.AspNetCore.Identity;

namespace ForumWebApp.Models
{
    public class AppUser : IdentityUser
    {
        public string? ImageUrl { get; set; }
    }
}
