using ForumWebApp.Models;

namespace ForumWebApp.ViewModels
{
    public class ProductDetailViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public Studio Studio { get; set; }
    }
}
