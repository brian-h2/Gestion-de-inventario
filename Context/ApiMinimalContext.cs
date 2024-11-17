using ApiMinimal.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMinimal.Context
{
    public class ApiMinimalContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(category =>
            {
                category.ToTable("Categoria"); //Especificamos nombre de tabla
                category.HasKey(t => t.CategoryID); //Especificamos clave

                category.Property(t => t.Name).IsRequired().HasMaxLength(150);

                category.Property(t => t.Description);  
            });

            modelBuilder.Entity<Tasks>(task =>
            {
                task.ToTable("Tareas");
                task.HasKey(t => t.CategoryID);

                task.Property(t => t.TaskName).IsRequired().HasMaxLength(200);

                task.Property(t => t.Description);

                task.Property(t => t.DateCreation);

                
            });

            
        }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ApiMinimalContext(DbContextOptions<ApiMinimalContext> options) : base (options) 
        { }
    }
}
