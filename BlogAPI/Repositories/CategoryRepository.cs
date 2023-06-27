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

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
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

        public async Task<Category> GetCategoryByTitleAsync(string title)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(X => X.Title == title);

            return category;
        }

        public void UpdateCategoryAsync(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;

        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }



    }
}