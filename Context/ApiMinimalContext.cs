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
                category.HasData(
                    new Category { CategoryID = Guid.Parse("f4dd7e80-b991-4992-8207-fdf90ac21b8b"), Name = "Limpieza", Wheight = 20 },
                    new Category { CategoryID = Guid.Parse("f4dd7e80-b991-4992-8207-fdf90ac21b02"), Name = "Trabajo", Wheight = 40 }
                );

                category.ToTable("Categoria"); //Especificamos nombre de tabla
                category.HasKey(t => t.CategoryID); //Especificamos clave principal

                category.Property(t => t.Name).IsRequired().HasMaxLength(150);

                category.Property(t => t.Description);

                category.Property(t => t.Wheight);
            });

            modelBuilder.Entity<Tasks>(task =>
            {
                task.HasData(
                    new Tasks { IdTask = Guid.Parse("f5601b55-2076-4b30-91d0-ecbb6648d0af"), TaskName = "Limpiar la casa", PriorityTask = Priority.Low, CategoryID = Guid.Parse("f4dd7e80-b991-4992-8207-fdf90ac21b8b") },
                    new Tasks { IdTask = Guid.Parse("f5601b55-2076-4b30-91d0-ecbb6648d099"), TaskName = "Arreglar bug en azure", PriorityTask = Priority.High, CategoryID = Guid.Parse("f4dd7e80-b991-4992-8207-fdf90ac21b02") }
                );
                task.ToTable("Tareas");
                task.HasKey(t => t.IdTask);

                task.HasOne(t => t.Category).WithMany(t => t.Tasks).HasForeignKey(t => t.CategoryID); //Hacemos relacion de categoria con varias tareas

                task.Property(t => t.TaskName).IsRequired().HasMaxLength(200);

                task.Property(t => t.DurationTask);

                task.Property(t => t.Description).HasMaxLength(500);

                task.Property(t => t.DateCreation);

                task.Property(t => t.PriorityTask).IsRequired();
     
            });

            
        }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ApiMinimalContext(DbContextOptions<ApiMinimalContext> options) : base (options) 
        { }
    }
}
