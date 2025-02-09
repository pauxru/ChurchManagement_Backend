using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Churchmanagement.Models
{
    public class LocalChurch
    {
        [Key]
        public int LocalChurchId { get; set; }
        [Required]
        public string LocalChurchName { get; set; }
        public string LocalChurchDescription { get; set; }
        public string? LocalChurchLocation { get; set; }
        public string? LocalChurchClass { get; set; }
        public string? LocalChurchAddress { get; set; }
        public string? LocalChurchCoordinates { get; set; }

        [Required]
        [ForeignKey("Parish")]
        public int LocalChurchParishID { get; set; } 
        //public ICollection<Clergy> localChurchClergies { get; set; }

    }
}
