using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhDSystem.Data.Models
{
    [Table("UserClaim", Schema = "dbo")]
    public class UserClaim
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string ClaimType { get; set; }

        [Required]
        public bool ClaimValue { get; set; }

    }
}
