using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhDSystem.Data.POCOs
{
    [Table("Faculty", Schema = "dbo")]
    public class Faculty
    {
        [Key]
        public int Id { get; set; }

    }
}
