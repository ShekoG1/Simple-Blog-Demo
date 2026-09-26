using Microsoft.EntityFrameworkCore;
using SunEasy_Blog.Models;

namespace SunEasy_Blog.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts => Set<BlogPost>();
    }
}
