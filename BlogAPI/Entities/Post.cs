using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace BlogAPI.Entities
{
    public class Post
    {

        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime PublicationDate { get; set; } = DateTime.UtcNow;

        public string   Content { get; set; }

        //RelationShip propreties 
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}