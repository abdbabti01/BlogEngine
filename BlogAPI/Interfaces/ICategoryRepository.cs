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
        void UpdateCategoryAsync(Category category);

        void AddCategory(Category category);

        Task<bool> SaveAllAsync();

        Task<Category> GetCategoryByIdAsync(int id);

        Task<Category> GetCategoryByTitleAsync(string title);
        

        Task<IEnumerable<Category>> GetCategoriesAsync();
        
    }
}