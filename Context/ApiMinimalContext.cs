using ApiMinimal.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMinimal.Context
{
    public class ApiMinimalContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public ApiMinimalContext(DbContextOptions<ApiMinimalContext> options) : base (options) { }
    }
}
