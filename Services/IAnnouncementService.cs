using Churchmanagement.Models;

namespace Churchmanagement.Services
{
    public interface IAnnouncementService
    {
        public Announcement getAnnouncementByID(int AnnouncementID);
        public List<Announcement> getLevelAnnouncement(int level, int levelID);
    }
}
