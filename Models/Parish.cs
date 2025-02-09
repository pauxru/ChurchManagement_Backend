using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Churchmanagement.Models
{
    public class Parish
    {
        [Key]
        public int ParishId { get; set; }
        public string ParishName { get; set; }
        
        [Required]
        [ForeignKey("Diocese")]
        public int DioceseID { get; set; }

        [ForeignKey("LocalChurch")]
        public int? HeadquaterChurchID { get; set; }
        //public ICollection<LocalChurch> Churches { get; set; }

        public string Description { get; set; }
    }

}
