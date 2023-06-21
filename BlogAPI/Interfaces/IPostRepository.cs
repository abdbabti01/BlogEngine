using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAPI.Dtos;
using BlogAPI.Entities;

namespace BlogAPI.Interfaces
{
    public interface IPostRepository
    {

        void UpdatePost(Post post);

        Task<bool> SaveAllAsync();

        Task<Post> GetPostByIdAsync(int id);

        Task<IEnumerable<Post>> GetPostsAsync();

        Task<IEnumerable<Post>> GetPostsByCategoryIdAsync(int id);
        
    }
}