using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumWebApp.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public int CommentId { get; set; }
        public Comment? Comment { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
