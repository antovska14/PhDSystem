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

        public virtual User User { get; set; }

        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        [MaxLength(255)]
        public string Title { get; set; }

        [MaxLength(255)]
        public string Degree { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<StudentTeacher> StudentTeachers { get; set; }
    }
}
