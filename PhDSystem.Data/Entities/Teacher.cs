using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhDSystem.Data.Entities
{
    [Table("Teacher")]
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        public string Title { get; set; }

        public string Degree { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<StudentTeacher> StudentTeachers { get; set; } = new List<StudentTeacher>();
    }
}
