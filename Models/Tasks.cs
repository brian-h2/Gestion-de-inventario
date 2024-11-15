namespace ApiMinimal.Models
{
    public class Tasks
    {
        public Guid TaskID { get; set; }

        public string? TaskName { get; set; }

        public string? Description { get; set; }

        public Priority PriorityTask { get; set; }

        public DateTime DateCreation { get; set; }

        /*Relacion con category*/ 

        public Guid CategoryID { get; set; } //Llave Foranea

        public virtual Category Category { get; set; } //

    }

    /*Propiedad de prioridad*, permite asignar el nivel de prioridad para cada tarea*/

    public enum Priority
    {
        Low,
        Medium,
        High
    }
}
