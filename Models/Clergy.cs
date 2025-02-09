using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Churchmanagement.Models
{
    public class Clergy
    {
        [Key]
        public int ClergyID { get; set; }

        [Required]
        public string ClergyName { get; set; }
        public string? ClergyAlias { get; set; }

        //[ForeignKey("ChurchMember")]
        public int ChurchMemberID { get; set; }

        [Required]
        public ClergyRanks ClergyRank { get; set; }

        [NotMapped] // This property is not mapped to the database, as it's determined automatically.
        public LeadershipLevels Level
        {
            get
            {
                return DetermineLeadershipLevel(ClergyRank);
            }
        }

        public int LevelID { get; set; } // This will be a unique identifier for the corresponding level.

        [Required]
        public DateTime OrdinationDate { get; set; }

        [Required]
        public string OrdainedBy { get; set; }

        [Required]
        public string OrdinationChurch { get; set; }

        public string? Salary { get; set; }
        public string? Description { get; set; }

        private LeadershipLevels DetermineLeadershipLevel(ClergyRanks rank)
        {
            return rank switch
            {
                ClergyRanks.Evagelist or ClergyRanks.ChurchLeader or ClergyRanks.Deacon => LeadershipLevels.LocalChurch,
                ClergyRanks.Pastor or ClergyRanks.ArchDeacon => LeadershipLevels.Parish,
                ClergyRanks.Bishop => LeadershipLevels.Diocese,
                ClergyRanks.ArchBishop => LeadershipLevels.AchDiocese,
                ClergyRanks.PresidingArchbishop => LeadershipLevels.National,
                _ => throw new ArgumentOutOfRangeException(nameof(rank), $"Unexpected rank: {rank}")
            };
        }
    }
}
