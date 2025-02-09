using System.ComponentModel.DataAnnotations;

namespace Churchmanagement.Models
{
    public class SubBoard
    {
        [Key]
        public int SubBoardID { get; set; }
        [Required]
        public int ConstitutedByLeadershipBoradID { get; set; }
        public DateOnly? DateFormed { get; set; }
        public int? SubBoardTenure { get; set; }
        public string? SubBoardTitle { get; set; }
        public string? BoardDescription { get; set; }
        public string? ChairmanName { get; set; }
        public string? ChairladyName { get; set; }
        public string? SecretaryName { get; set; }
        public string? TreasurerName { get; set; }
        public string? VChairmanName { get; set; }
        public string? VChairladyName { get; set; }
        public string? VSecretaryName { get; set; }
        public string? VTreasurerName { get; set; }


    }
}
