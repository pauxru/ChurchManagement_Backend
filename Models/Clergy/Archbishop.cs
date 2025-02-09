using System.ComponentModel.DataAnnotations.Schema;

namespace Churchmanagement.Models
{
    public class Archbishop : Clergy
    {

        public DateTime OrdinationToArchBishopDate { get; set; }

        public int Tenure { get; set; }
        [ForeignKey("Diocese")]
        public int? DioceseID { get; set; }

    }
}
