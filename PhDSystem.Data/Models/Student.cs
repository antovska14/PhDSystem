using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhDSystem.Data.Models
{
    [Table("Student", Schema = "dbo")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        [Required]
        public int FormOfEducationId { get; set; }

        public FormOfEducation FormOfEducation { get; set; }

        [Required]
        [MaxLength(255)]
        public string SpecialtyName { get; set; }

        [Required]
        public DateTime FacultyCouncilChosenDate { get; set; }

        public int TitleId { get; set; }
        
        public int DegreeId { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<StudentTeacher> StudentTeachers { get; set; } = new List<StudentTeacher>();
    }
}
