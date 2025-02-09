using System;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
namespace Churchmanagement.Models
{
    public class UserProfile
    {
        [Key]
        public string UserID { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string MemberName { get; set; }
        public int? MemberAge { get; set; }
        public DateTime? MemberSince { get; set; }
        public string MemberEmail { get; set; }
        public string? MemberPhoneNum { get; set; }
        public string? MemberRole { get; set; }
        public int? MemberLocalChurchID { get; set; }
        public char? MemberSex { get; set; }
        public DateTime? BaptismDay { get; set; }
        public string? BaptisedBy { get; set; }
        public string? BaptismChurch { get; set; }
        public string? BaptismRepresentative { get; set; }
        public DateTime? ConfirmationDay { get; set; }
        public string? ConfirmedBy { get; set; }
        public string? ConfirmationChurch { get; set; }
        public string? ConfirmationWitness { get; set; }
        public DateTime? ConsecrationDay { get; set; }
        public string? ConsecratedBy { get; set; }
        public string? ConsecrationChurch { get; set; }
        public string? ConsecrationRepresentative { get; set; }
        public bool? IsActive { get; set; } = true;
        public string? Alias { get; set; }
    }
}
