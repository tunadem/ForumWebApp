using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumWebApp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public float Stars { get; set; }
        public string? Image {  get; set; }
        [ForeignKey("StudioId")]
        public int StudioId { get; set; }
        public Studio? Studio { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public ICollection<ProductCategory>? ProductCategories { get; set; }
        public ICollection<Review>? Reviews { get; set; }

    }
}
