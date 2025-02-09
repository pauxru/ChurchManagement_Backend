namespace Churchmanagement.Models
{
    public class ChurchLeader : Clergy
    {
        public DateTime OrdinationToCLDate { get; set; }

        public int Tenure { get; set; }

        public int localChurchID { get; set; }

    }
}
