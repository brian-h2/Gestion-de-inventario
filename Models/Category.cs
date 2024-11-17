using System.ComponentModel.DataAnnotations;

namespace ApiMinimal.Models
{
    public class Category
    {
        //[Key]//Data Annotations
        public Guid CategoryID { get; set; }

        //[Required]//Data Annotations
        //[MaxLength(150)]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Tasks> Tasks { get; set; }

    }
}
