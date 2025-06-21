using ForumWebApp.Models;

namespace ForumWebApp.ViewModels
{
    public class CategoryDetailViewModel
    {
        public Category Category { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
