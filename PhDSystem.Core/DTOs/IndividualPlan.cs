using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhDSystem.Core.DTOs
{
    [Table("IndividualPlan", Schema = "dbo")]
    public class IndividualPlan
    {
        [Key]
        public int Id { get; set; }

    }
}
