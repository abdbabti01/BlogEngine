using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Entities
{
    public class Post
    {

        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime PublicationDate { get; set; }
    }
}