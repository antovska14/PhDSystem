using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace PhDSystem.Data.Entities
{
    [Table("Student")]
    public class Student
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

        [Required]
        public int FormOfEducationId { get; set; }

        public virtual FormOfEducation FormOfEducation { get; set; }

        [Required]
        public int PhdProgramId { get; set; }

        public virtual PhdProgram PhdProgram { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        [Required]
        public int CurrentYear { get; set; }

        [Required]
        [MaxLength(255)]
        public string SpecialtyName { get; set; }

        public string DissertationTheme { get; set; }

        [Required]
        public DateTime FacultyCouncilChosenDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<StudentTeacher> StudentTeachers { get; set; }

        public virtual ICollection<Exam> Exams { get; set; }

        public virtual ICollection<StudentFile> StudentFiles { get; set; }
    }
}
