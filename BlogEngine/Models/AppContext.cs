using System.Data.Entity;
using BlogEngine.Models.Entities;

namespace BlogEngine.Models
{
    public class AppContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
    }
}