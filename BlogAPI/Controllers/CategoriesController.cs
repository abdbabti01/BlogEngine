using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogAPI.Data;
using BlogAPI.Dtos;
using BlogAPI.Entities;
using BlogAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Controllers
{
    public class CategoriesController : BaseController
    {

        private readonly ICategoryRepository _categoryRepository;

        private readonly IPostRepository _postRepository;

        private readonly IMapper _mapper;   

        private readonly DataContext _dataContext;
        public CategoriesController(ICategoryRepository categoryRepository, IPostRepository postRepository, IMapper mapper, DataContext dataContext)
        {
            _categoryRepository = categoryRepository;
            _postRepository = postRepository;
            _mapper = mapper;
            _dataContext = dataContext;
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

        [HttpPost("addCategory")]
        public async Task<ActionResult<CategoryDto>> AddCategory(CategoryDto categoryDto){

            if(await CatExist(categoryDto)) return BadRequest("Category Already Exists");

            var category = new Category{
                Title = categoryDto.Title
            };
            
            _categoryRepository.AddCategory(category);

            if(await _categoryRepository.SaveAllAsync()) return new CategoryDto{
                Title = category.Title};
            

            return BadRequest("Failed to add category");
        
        }

        
        [HttpPut("updateCategory")]
        public async Task<ActionResult<CategoryDto>> UpdateCategory(CategoryDto categoryDto){

            if(await CatExist(categoryDto)) return BadRequest("Category Already Exists");

            var category = await _categoryRepository.GetCategoryByIdAsync(categoryDto.Id);
                
            if(category == null) return NotFound();

            _mapper.Map(categoryDto, category);

            _categoryRepository.UpdateCategoryAsync(category);

            if(await _categoryRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update category");

        }


        public async Task<bool> CatExist(CategoryDto categoryDto){

            return await _dataContext.Categories.AnyAsync(X => X.Title == categoryDto.Title);
        }



        
    }
}