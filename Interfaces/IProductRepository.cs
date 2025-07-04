﻿using ForumWebApp.Models;

namespace ForumWebApp.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<IEnumerable<Product>> GetSearchAsync(string search);
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Category>> GetCategoriesByProductAsync(int productId);
        Task<Studio?> GetStudioByProductAsync(int productId);
        Task<IEnumerable<Comment>> GetCommentsByProductAsync(int productId);
        Task AddCommentToProductAsync(int productId, string userId,string title, string commentText);
        Task DeleteCommentAsync(int productId, int userId, string title, string commentText);
        bool Add(Product product);
        bool Delete(Product product);
        bool Update(Product product);
        bool Save();
    }
}
