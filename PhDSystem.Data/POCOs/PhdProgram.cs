using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhDSystem.Data.POCOs
{
    [Table("PhdProgram", Schema = "dbo")]
    public class PhdProgram
    {
        [Key]
        public int Id { get; set; }

    }
}
