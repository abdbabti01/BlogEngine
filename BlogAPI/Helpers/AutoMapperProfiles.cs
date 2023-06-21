using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogAPI.Dtos;
using BlogAPI.Entities;

namespace BlogAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Post, PostDto>();
            CreateMap<Category, CategoryDto>();
        }
    }
}