using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAPI.Entities;

namespace BlogAPI.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPostsAsync();
        
    }
}