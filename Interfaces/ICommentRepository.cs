using ForumWebApp.Models;
using System.Security;

namespace ForumWebApp.Interfaces
{
    public interface ICommentRepository
    {
        Task<Comment> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task EditAsync(int id, string title, string content);

    }
}
