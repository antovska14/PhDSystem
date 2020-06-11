﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhDSystem.Data.Models
{
    [Table("Department", Schema = "dbo")]
    public class Department
    {
        [Key]
        public int Id { get; set; }

    }
}
