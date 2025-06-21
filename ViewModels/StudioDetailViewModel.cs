using ForumWebApp.Models;

namespace ForumWebApp.ViewModels
{
    public class StudioDetailViewModel
    {
        public Studio Studio { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public Address Address { get; set; }
    }
}
