using System.ComponentModel.DataAnnotations;

namespace Churchmanagement.Models
{
    public class LeadershipBoard
    {
        [Key]
        public int BoardID { get; set; }
        [Required]
        public LeadershipLevels LeadershipLevel { get; set; }
        [Required]
        public int LevelID { get; set; }

        public DateOnly? DateFormed { get; set; }
        public int? BoardTenure { get; set; }
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
