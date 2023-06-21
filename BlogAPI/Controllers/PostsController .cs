using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAPI.Dtos;
using BlogAPI.Interfaces;
using BlogAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    public class PostsController : BaseController
    {

        private readonly IPostRepository _postRepository;   
        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetPosts(){

            var users =  await _postRepository.GetPostsAsync();

            return Ok(users);

        }
    }
}