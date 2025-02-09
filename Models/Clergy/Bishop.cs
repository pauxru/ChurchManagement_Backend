using System.ComponentModel.DataAnnotations.Schema;

namespace Churchmanagement.Models
{
    public class Bishop : Clergy
    {
        public DateTime OrdinationToBishopDate { get; set; }

        public int Tenure { get; set; }
        [ForeignKey("Diocese")]
        public Diocese Diocese { get; set; }

    }
}
