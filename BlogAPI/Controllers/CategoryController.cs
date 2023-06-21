using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogAPI.Dtos;
using BlogAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    public class CategoryController : BaseController
    {

        private readonly ICategoryRepository _categoryRepository;

        private readonly IPostRepository _postRepository;

        private readonly IMapper _mapper;   
        public CategoryController(ICategoryRepository categoryRepository, IPostRepository postRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _postRepository = postRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories(){

            var categories =  await _categoryRepository.GetCategoriesAsync();

            if(categories.Count() == 0) return NoContent();

            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return Ok(categories);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategoryById(int id){

            var category =  await _categoryRepository.GetCategoryByIdAsync(id);

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return categoryDto;


        }

        [Route("{id}/posts")]
        public async Task<ActionResult<PostDto>> GetPostsByCategoryId(int id){

            var posts =  await _postRepository.GetPostsByCategoryIdAsync(id);

            if(posts.Count() == 0) return NoContent();

            var postsToReturn = _mapper.Map<IEnumerable<PostDto>>(posts);

            return Ok(postsToReturn);

        }
        
    }
}