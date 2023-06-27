using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Dtos
{
    public class PostDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        
        [Required]
        public DateTime PublicationDate { get; set; } = DateTime.UtcNow;
        
        [Required]
        public string Content { get; set; }
        
        [Required]
        public int CategoryId { get; set; }
    }
}