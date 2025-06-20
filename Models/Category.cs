using System.ComponentModel.DataAnnotations;

namespace ForumWebApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<ProductCategory>? ProductCategories { get; set; }

    }
}
