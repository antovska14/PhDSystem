using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhDSystem.Data.Entities
{
    [Table("Faculty")]
    public class Faculty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual University University { get; set; }

        [Required]
        public int UniversityId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string DeanFullName { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
    }
}
