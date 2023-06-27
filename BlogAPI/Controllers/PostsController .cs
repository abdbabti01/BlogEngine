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


        [HttpPost("addPost")]
        public async Task<ActionResult<PostDto>> AddPost(PostDto postDto){

            if(await PostExist(postDto)) return BadRequest("Post Already Exists");

            var post = new Post{
                Title = postDto.Title,
                PublicationDate = postDto.PublicationDate,
                Content = postDto.Content,
                CategoryId = postDto.CategoryId
                
            };
            
            _postRepository.AddPost(post);

            if(await _postRepository.SaveAllAsync()) return NoContent();
        
            return BadRequest("Failed to add category");
        
        }


        [HttpPut("updatePost")]
        public async Task<ActionResult<PostDto>> UpdatePost(PostDto postDto){

            //if(await CatExist(categoryDto)) return BadRequest("Category Already Exists");

            var post = await _postRepository.GetPostByIdAsync(postDto.Id);
                
            if(post == null) return NotFound();

            _mapper.Map(postDto, post);

            _postRepository.UpdatePost(post);

            if(await _postRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update post");

        }


        public async Task<bool> PostExist(PostDto postDto){

            return await _postRepository.Exists(postDto);
        }


    }
}