using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Churchmanagement.Models
{
    public class ArchDiocese
    {
        [Key]
        public int ArchDioceseId { get; set; }
        public string ArchDioceseName { get; set; }
        public string ArchDioceseDescription { get; set; }

        [ForeignKey("LocalChurch")]
        public int? ArchDioceseHeadquater { get; set; }
        //public ICollection<Parish> Parishes { get; set; } // Navigation Property
    }
}
