﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhDSystem.Core.DTOs
{
    [Table("Title", Schema = "dbo")]
    public class Title
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameShort { get; set; }
    }
}