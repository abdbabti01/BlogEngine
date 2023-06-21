using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAPI.Dtos;
using BlogAPI.Entities;

namespace BlogAPI.Interfaces
{
    public interface ICategoryRepository
    {
        void UpdatePost(Category category);

        Task<bool> SaveAllAsync();

        Task<Category> GetCategoryByIdAsync(int id);

        Task<IEnumerable<Category>> GetCategoriesAsync();
        
    }
}