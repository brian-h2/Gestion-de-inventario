using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMinimal.Models
{
    [Table("Tasks")]
    public class Tasks
    {
        //[Key]
        public Guid IdTask { get; set; }

        //[Required]
        //[MaxLength(200)]
        public string? TaskName { get; set; }

        public string? Description { get; set; }

        public Priority PriorityTask { get; set; }

        public DateTime DateCreation { get; set; }

        public int DurationTask { get; set; }

        /*Relacion con category*/

        //[ForeignKey("CategoriaID")] 
        public Guid CategoryID { get; set; } //Llave Foranea
        public virtual Category Category { get; set; } //

        [NotMapped]//En momento que se haga el mapeo de nuestro contexto, se omita este atributo
        public string Resum {  get; set; } //Resume un valor extenso

    }

    /*Propiedad de prioridad*, permite asignar el nivel de prioridad para cada tarea*/
    /*En base de datos va a determinar tambien un valor en base a la prioridad*/

    public enum Priority
    {
        Low,
        Medium,
        High
    }
}
