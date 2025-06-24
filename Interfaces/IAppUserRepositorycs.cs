using ForumWebApp.Models;

namespace ForumWebApp.Interfaces
{
    public interface IAppUserRepository
    {
        Task<AppUser?> GetByUserAsync(string UserName);
        Task<AppUser?> GetFirstAsync(); 
    }

}
