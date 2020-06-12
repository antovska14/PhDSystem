using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhDSystem.Data.Models
{
    [Table("Attestation", Schema = "dbo")]
    public class Attestation
    {
        [Key]
        public int Id { get; set; }

    }
}
