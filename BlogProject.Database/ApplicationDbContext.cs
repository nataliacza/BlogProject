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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Post>()
                .Property(c => c.Content)
                .HasMaxLength(1000);
        }
    }
}
