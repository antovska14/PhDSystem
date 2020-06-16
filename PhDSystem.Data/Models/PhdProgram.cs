using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhDSystem.Data.Models
{
    [Table("PhdProgram")]
    public class PhdProgram
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength]
        public string Name { get; set; }

        public ProfessionalField ProfessionalField { get; set; }

        public int ProfessionalFieldId { get; set; }
    }
}
