using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhDSystem.Data.Entities
{
    [Table("StudentTeacher")]
    public class StudentTeacher
    {
        public int? StudentId { get; set; }

        public virtual Student Student { get; set; }

        public int? TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
