using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAPI.Data;
using BlogAPI.Entities;
using BlogAPI.Interfaces;
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
            
            var posts = await _context.Posts.ToListAsync();
        
            return posts;
        }



    }
}