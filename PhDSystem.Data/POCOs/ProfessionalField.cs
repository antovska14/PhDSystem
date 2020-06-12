using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhDSystem.Data.POCOs
{
    [Table("ProfessionalField", Schema = "dbo")]
    public class ProfessionalField
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
