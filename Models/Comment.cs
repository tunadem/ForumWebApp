using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumWebApp.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public Review? Review { get; set; }
    }
}
