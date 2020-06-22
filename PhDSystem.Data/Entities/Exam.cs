using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhDSystem.Data.Entities
{
    [Table("Exam")]
    public class Exam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        public int Year { get; set; }

        [Required]
        public string Name { get; set; }

        public double Grade { get; set; }

        public DateTime Date { get; set; }
    }
}
