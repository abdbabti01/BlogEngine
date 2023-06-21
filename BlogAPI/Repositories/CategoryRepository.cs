using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogAPI.Data;
using BlogAPI.Dtos;
using BlogAPI.Entities;
using BlogAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            var categories = await _context.Categories.ToListAsync();
        
            return categories;
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            return category;
        }

        public Task<bool> SaveAllAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdatePost(Category category)
        {
            throw new NotImplementedException();
        }
    }
}