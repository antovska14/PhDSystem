using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhDSystem.Data.Entities
{
    [Table("StudentFiles")]
    public class StudentFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        [Required]
        public string FileGroup { get; set; }

        [Required]
        [MaxLength(255)]
        public string FileName { get; set; }
    }
}
