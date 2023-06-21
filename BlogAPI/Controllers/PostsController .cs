using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogAPI.Dtos;
using BlogAPI.Entities;
using BlogAPI.Interfaces;
using BlogAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    public class PostsController : BaseController
    {

        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostsController(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetPosts(){

            var posts =  await _postRepository.GetPostsAsync();

            if(posts.Count() == 0) return NoContent();

            var postsToReturn = _mapper.Map<IEnumerable<PostDto>>(posts);

            return Ok(postsToReturn);

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> GetPostById(int id){

            var post =  await _postRepository.GetPostByIdAsync(id);

            var postDto = _mapper.Map<PostDto>(post);

            return postDto;


        }


    }
}