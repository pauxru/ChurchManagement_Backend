namespace Churchmanagement.Models
{
    public class Announcement
    {
        public int AnnouncementID { get; set; }
        public string AnnouncementTitle { get; set; }
        public string AnnouncementDescription { get; set; }
        public string? AnnouncementTargetAudience { get; set; }
        public LeadershipLevels AnnouncementLevel { get; set; }
        public int AnnouncementLevelID { get; set; }
        public DateTime AnnouncementStratDate { get; set; }
        public int? AnnouncementActive { get; set; }
    }
}
