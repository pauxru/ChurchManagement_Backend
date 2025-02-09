using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Churchmanagement.Models
{
    public class ChurchMember
    {
        [Key]
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public string? Alias { get; set; }
        [Required]
        [ForeignKey("LocalChurch")]
        public int MemberLocalChurchID { get; set; }
        public bool? IsActive { get; set; }

        [Required]
        public string MemberSex { get; set; }
        public int? MemberAge { get; set; }
        public DateTime MemberSince { get; set; }
        public string? MemberEmail { get; set; }
        public string? MemberPhoneNum { get; set; }
        public string? MemberRole { get; set; }
        public DateTime? BaptismDay { get; set; }
        public  string? BatisedBy { get; set; }
        public string? BatismChurch { get; set; }
        public string? BatismRepresentative { get; set; }
        public DateTime? ConfirmationDay { get; set; }
        public  string? ConfirmedBy { get; set; }
        public string? ConfirmationChurch { get; set; }
        public string? ConfirmationWitness { get; set; }
        public DateTime? ConcecrationDay { get; set; }
        public  string? ConcecratedBy { get; set; }
        public string? ConcecrationChurch { get; set; }
        public string? ConcecrationRepresentative { get; set; }

    }
    
}
