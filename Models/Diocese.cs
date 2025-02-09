using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Churchmanagement.Models
{
    public class Diocese
    {
        [Key]
        public int DioceseId { get; set; }
        public int? ArchDioceseId { get; set; }
        public string DioceseName { get; set; }

        [ForeignKey("LocalChurch")]
        public int? HeadquaterChurchID { get; set; }
        //public ICollection<Parish> Parishes { get; set; } // Navigation Property
    }
}
