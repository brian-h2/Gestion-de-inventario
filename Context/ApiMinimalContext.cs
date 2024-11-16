using ApiMinimal.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMinimal.Context
{
    public class ApiMinimalContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>()
                .HasKey(t => t.IdTask);

            
        }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ApiMinimalContext(DbContextOptions<ApiMinimalContext> options) : base (options) 
        { }
    }
}
