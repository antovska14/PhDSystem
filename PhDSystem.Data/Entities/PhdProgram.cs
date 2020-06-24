using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhDSystem.Data.Entities
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

        [Required]
        public int ProfessionalFieldId { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
