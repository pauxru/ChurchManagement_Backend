using System.ComponentModel.DataAnnotations.Schema;

namespace Churchmanagement.Models
{
    public class ArchDeacon : Clergy
    {
        public DateTime OrdinationToArchDeaconDate { get; set; }

        public int Tenure { get; set; }
        [ForeignKey("Parish")]
        public int ParishID { get; set; }

    }
}
