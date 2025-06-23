using ForumWebApp.Data;
using ForumWebApp.Interfaces;
using ForumWebApp.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ForumWebApp.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool Add(Product product)
        {
            _context.Add(product);
            return Save();
        }

        public bool Delete(Product product)
        {
            _context.Remove(product);
            return Save();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(i=>i.Id==id);
        }
        public async Task<IEnumerable<Category>> GetCategoriesByProductAsync(int productId)
        {
            return await _context.Categories
                .Where(p => p.ProductCategories.Any(pc => pc.ProductId == productId))
                .Include(p => p.ProductCategories)
                    .ThenInclude(pc => pc.Product)
                .ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetCommentsByProductAsync(int productId)
        {
            return await _context.Reviews
                .Where(r => r.ProductId == productId)
                .Include(r => r.Comment)
                .ThenInclude(c=> c.AppUser)
                .Select(r => r.Comment)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetSearchAsync(string query)
        {
            return await _context.Products
    .Where(p => p.Name.Contains(query) || p.Description.Contains(query))
    .Include(p => p.Studio)
    .Include(p => p.ProductCategories)
        .ThenInclude(pc => pc.Category)
    .ToListAsync();
        }

        public async Task<Studio?> GetStudioByProductAsync(int productId)
        {
            var product = await _context.Products
                .Include(p => p.Studio)
                .FirstOrDefaultAsync(p => p.Id == productId);

            return product?.Studio;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Product product)
        {
            _context.Update(product);
            return Save();
        }
    }
}
