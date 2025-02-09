using System.ComponentModel.DataAnnotations.Schema;

namespace Churchmanagement.Models
{
    public class Deacon : Clergy
    {
        public DateTime OrdinationToDeaconDate { get; set; }

        public int Tenure { get; set; }
        [ForeignKey("LocalChurch")]
        public int localChurchID { get; set; }

    }
}
