using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhDSystem.Core.DTOs
{
    [Table("PhdProgram", Schema = "dbo")]
    public class PhdProgram
    {
        [Key]
        public int Id { get; set; }

    }
}
