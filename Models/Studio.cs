using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumWebApp.Models
{
    public class Studio
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        [ForeignKey("AddressId")]
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
