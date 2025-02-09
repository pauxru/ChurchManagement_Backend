using System.ComponentModel.DataAnnotations.Schema;

namespace Churchmanagement.Models
{
    public class Pastor : Clergy
    {
        public DateTime OrdinationToPastorDate { get; set; }

        public int Tenure { get; set; }
        [ForeignKey("Parish")]
        public Parish Parish { get; set; }

        
    }
}
