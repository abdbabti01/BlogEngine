using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options){}

        public DbSet<Post> Posts { get; set; }
    }
}