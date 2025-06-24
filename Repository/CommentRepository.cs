using ForumWebApp.Data;
using ForumWebApp.Interfaces;
using ForumWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumWebApp.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;

        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Comment> GetByIdAsync(int id)
        {
            return await _context.Comments
                .Include(c => c.Review)
                .ThenInclude(r => r.Product)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task DeleteAsync(int id)
        {
            var comment = await _context.Comments
                .Include(c => c.Review)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (comment != null)
            {
                _context.Reviews.RemoveRange(comment.Review);
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task EditAsync(int id, string title, string content)
        {
            var comment = await _context.Comments
                .Include(c => c.Review)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (comment != null)
            {
                comment.Title = title;
                comment.Content = content;

                await _context.SaveChangesAsync();
            }
        }
    }
}
