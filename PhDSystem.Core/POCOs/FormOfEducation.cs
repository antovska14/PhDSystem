using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhDSystem.Core.POCOs
{
    [Table("FormOfEducation", Schema = "dbo")]
    public class FormOfEducation
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearsCount { get; set; }
    }
}
