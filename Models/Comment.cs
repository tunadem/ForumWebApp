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
        public int? AppUserId { get; set; }
        //[ForeignKey("AppUser")]
        public AppUser? AppUser { get; set; }
        public Review? Reviews { get; set; }
    }
}
