using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Dtos
{
    public class PostDto
    {
         public string Title { get; set; }

        public DateTime PublicationDate { get; set; } = DateTime.UtcNow;

        public string   Content { get; set; }
    }
}