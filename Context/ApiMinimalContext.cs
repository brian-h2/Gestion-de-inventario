using ApiMinimal.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMinimal.Context
{
    public class ApiMinimalContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Category> categoriesInit = new List<Category>();
            categoriesInit.Add(new Category() { CategoryID = Guid.Parse("f4dd7e80-b991-4992-8207-fdf90ac21b8b"), Name = "Limpiar casa", Wheight = 20 });
            categoriesInit.Add(new Category() { CategoryID = Guid.Parse("f4dd7e80-b991-4992-8207-fdf90ac21b02"), Name = "Acomodar la cama", Wheight = 40 });

            modelBuilder.Entity<Category>(category =>
            {
                category.ToTable("Categoria"); //Especificamos nombre de tabla
                category.HasKey(t => t.CategoryID); //Especificamos clave principal

                category.Property(t => t.Name).IsRequired().HasMaxLength(150);

                category.Property(t => t.Description);

                category.Property(t => t.Wheight);
            });

            List<Tasks> tasksInit = new List<Tasks>();
            

            modelBuilder.Entity<Tasks>(task =>
            {
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
