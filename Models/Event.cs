using System.ComponentModel.DataAnnotations;

namespace Churchmanagement.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public string? EventCategory { get; set; }
        public LeadershipLevels EventLevel { get; set; }
        public int EventLevelID { get; set; }
        public DateOnly EventStratDate { get; set; }
        public TimeOnly EventStratTime { get; set; }
        public DateOnly EventEndDate { get; set; }
        public TimeOnly EventEndTime { get; set; }
        public string EventOrganizers { get; set; }
        public string? EventSpecialGuests { get; set; }
        public string EventLocationChurch { get; set; }
        public string? EventCoverPhoto { get; set; }
        public string? EventTargetAttendees { get; set; }
        public string? EventTheme { get; set; }
        public int? EventActive { get; set; }


    }
}
