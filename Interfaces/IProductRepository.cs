using ForumWebApp.Models;

namespace ForumWebApp.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Category>> GetCategoriesByProductAsync(int productId);
        Task<Studio?> GetStudioByProductAsync(int productId);
        bool Add(Product product);
        bool Delete(Product product);
        bool Update(Product product);
        bool Save();
    }
}
