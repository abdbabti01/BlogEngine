using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogAPI.Data;
using BlogAPI.Dtos;
using BlogAPI.Entities;
using BlogAPI.Interfaces;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DataContext _context;
        public PostRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            
            var posts = await _context.Posts.OrderByDescending(p => p.PublicationDate).ToListAsync();
        
            return posts;
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            return post;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdatePost(Post post)
        {
             _context.Entry(post).State = EntityState.Modified;
        }

        public async Task<IEnumerable<Post>> GetPostsByCategoryIdAsync(int id)
        {
           var posts = await _context.Posts.Where(x => x.CategoryId == id).ToListAsync();

           return posts;
        }

        public void AddPost(Post post)
        {
             _context.Posts.Add(post);
        }


        public async Task<bool> Exists(PostDto postDto){

           return await _context.Categories.AnyAsync(X => X.Title == postDto.Title);
        }
    }
}