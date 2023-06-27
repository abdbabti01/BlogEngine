using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Dtos
{
    public class CategoryDto
    {

        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }
    }
}