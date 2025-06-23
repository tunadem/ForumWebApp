namespace ForumWebApp.Models
{
    public class AppUser //: IdentitiyUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string? ImageUrl { get; set; }
    }
}
