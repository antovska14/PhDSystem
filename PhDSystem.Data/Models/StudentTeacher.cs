using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhDSystem.Data.Models
{
    public class StudentTeacher
    {
        [Key, Column(Order = 1)]
        public int StudentId { get; set; }
        [Key, Column(Order =2)]
        public int SupervisorId { get; set; }
    }
}
