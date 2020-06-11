using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhDSystem.Data.Models
{
    [Table("Teacher", Schema = "dbo")]
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

    }
}
