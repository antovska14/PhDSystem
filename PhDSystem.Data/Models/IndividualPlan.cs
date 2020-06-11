using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhDSystem.Data.Models
{
    [Table("IndividualPlan", Schema = "dbo")]
    public class IndividualPlan
    {
        [Key]
        public int Id { get; set; }

    }
}
