using ForumWebApp.Data;
using ForumWebApp.Interfaces;
using ForumWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumWebApp.Repository
{
    public class StudioRepository : IStudioRepository
    {
        private readonly AppDbContext _context;

        public StudioRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool Add(Studio studio)
        {
            _context.Add(studio);
            return Save();
        }

        public bool Delete(Studio studio)
        {
            _context.Remove(studio);
            return Save();
        }

        public async Task<Address> GetAddress(int id)
        {
            return await _context.Addresses.FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<Address?> GetAddressAsync(int addressId)
        {
            var studio = await _context.Studios
                .Include(p => p.Address)
                .FirstOrDefaultAsync(p => p.Id == addressId);

            return studio?.Address;
        }

        public async Task<IEnumerable<Studio>> GetAllAsync()
        {
            return await _context.Studios.ToListAsync();
        }

        public async Task<Studio> GetByIdAsync(int id)
        {
            return await _context.Studios.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsByStudioAsync(int studioId)
        {
            return await _context.Products
                .Where(p => p.StudioId == studioId)
                .Include(p => p.ProductCategories)
                    .ThenInclude(pc => pc.Category)
                .ToListAsync();
        }



        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Studio studio)
        {
            _context.Update(studio);
            return Save();
        }
    }
}
