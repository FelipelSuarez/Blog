using Microsoft.EntityFrameworkCore;
using Projeto_Bolg.Models;

namespace Projeto_Bolg.Repositories.Data
{
	public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options)
        : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>();
        }
    }
}