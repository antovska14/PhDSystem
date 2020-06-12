using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhDSystem.Core.POCOs
{
    [Table("Degree", Schema = "dbo")]
    public class Degree
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameShort { get; set; }
    }
}
