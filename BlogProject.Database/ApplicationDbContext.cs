using BlogProject.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
    }
}
