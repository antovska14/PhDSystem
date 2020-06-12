using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhDSystem.Data.POCOs
{
    [Table("Student", Schema = "dbo")]
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int FormOfEducationId { get; set; }
        public int TitleId { get; set; }
        public int DegreeId { get; set; }
    }
}
