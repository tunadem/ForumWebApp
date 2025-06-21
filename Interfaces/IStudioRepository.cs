using ForumWebApp.Models;

namespace ForumWebApp.Interfaces
{
    public interface IStudioRepository
    {
        Task<IEnumerable<Studio>> GetAllAsync();
        Task<Studio> GetByIdAsync(int id);
        Task<Address> GetAddressAsync(int id);
        Task<IEnumerable<Product>> GetProductsByStudioAsync(int studioId);
        bool Add(Studio studio);
        bool Update(Studio studio);
        bool Delete(Studio studio);
        bool Save();
    }
}
