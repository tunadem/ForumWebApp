using ForumWebApp.Data;
using ForumWebApp.Interfaces;
using ForumWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumWebApp.Repository
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly AppDbContext _context;

        public AppUserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AppUser?> GetByUserAsync(string UserName)
        {
            return await _context.AppUsers.FindAsync(UserName);
        }

        public async Task<AppUser?> GetFirstAsync()
        {
            return await _context.AppUsers.FirstOrDefaultAsync();
        }
    }

}
