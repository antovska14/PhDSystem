using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhDSystem.Data.Models
{
    [Table("PhdProgram", Schema = "dbo")]
    public class PhdProgram
    {
        [Key]
        public int Id { get; set; }

    }
}
