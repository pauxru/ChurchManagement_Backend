using Churchmanagement.Models;
using Microsoft.EntityFrameworkCore;

namespace Churchmanagement.Services
{
    public class AnnouncementService : IAnnouncementService
    {

        private readonly ApplicationDbContext _context;
        public AnnouncementService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Announcement getAnnouncementByID(int announcementID)
        {
            try
            {
                var query = $"SELECT * FROM Announcement WHERE AnnouncementID = {announcementID}";
                Console.WriteLine($"Executing query: {query}");

                var evnt = _context.Announcements
                    .FromSqlInterpolated($"SELECT * FROM Announcement WHERE AnnouncementID = {announcementID}")
                    .AsEnumerable()
                    .FirstOrDefault();

                if (evnt == null)
                {
                    throw new KeyNotFoundException($"Event with ID {announcementID} not found.");
                }

                return evnt;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }


        private List<Announcement> getLocalChurchAnnouncement(int levelID)
        {
            var announcement = _context.Announcements
                .FromSqlInterpolated($"SELECT * FROM Announcement where Announcementlevel = 1 AND AnnouncementLevelID = {levelID}")
                .ToList();

            return announcement;
        }
        private List<Announcement> getParishAnnouncement(int levelID)
        {
            var announcement = _context.Announcements
                .FromSqlInterpolated($"SELECT * FROM Announcement where Announcementlevel = 2 AND AnnouncementLevelID = {levelID}")
                .ToList();

            return announcement;
        }
        private List<Announcement> getDioceseAnnouncement(int levelID)
        {
            var announcement = _context.Announcements
                .FromSqlInterpolated($"SELECT * FROM Announcement where Announcementlevel = 3 AND AnnouncementLevelID = {levelID}")
                .ToList();

            return announcement;
        }
        private List<Announcement> getArchDioceseAnnouncement(int levelID)
        {
            var announcement = _context.Announcements
                .FromSqlInterpolated($"SELECT * FROM Announcement where Announcementlevel = 4 AND AnnouncementLevelID = {levelID}")
                .ToList();

            return announcement;
        }

        public List<Announcement> getLevelAnnouncement(int level, int levelID)
        {
            int CurrentLevelID = levelID;

            var announcement = _context.Announcements
                .FromSqlInterpolated($"SELECT * FROM Announcement where Announcementlevel = 5")
                .ToList();

            for (int i = level; i < (int)LeadershipLevels.National; i++)
            {
                if (i == (int)LeadershipLevels.AchDiocese)
                {
                    var tmp = getArchDioceseAnnouncement(CurrentLevelID);
                    Console.WriteLine($"getArchDioceseEvents : {tmp}");

                }

                if (i == (int)LeadershipLevels.Diocese)
                {
                    var tmp = getDioceseAnnouncement(CurrentLevelID);
                    announcement.AddRange(tmp);

                    var TempCurrentLevelID1 = _context.Dioceses
                    .FromSqlInterpolated($"SELECT * FROM Diocese WHERE DioceseID = {CurrentLevelID}")
                    .AsEnumerable()
                    .Select(d => d.ArchDioceseId)
                    .FirstOrDefault();

                    CurrentLevelID = TempCurrentLevelID1.Value;
                }

                if (i == (int)LeadershipLevels.Parish)
                {
                    var tmp = getParishAnnouncement(CurrentLevelID);
                    announcement.AddRange(tmp);

                    var TempCurrentLevelID2 = _context.Parishes
                    .FromSqlInterpolated($"SELECT * FROM Parish WHERE ParishID = {CurrentLevelID}")
                    .AsEnumerable()
                    .Select(d => d.DioceseID)
                    .FirstOrDefault();

                    CurrentLevelID = TempCurrentLevelID2;
                }

            if (i == (int)LeadershipLevels.LocalChurch)
            {
                var tmp = getLocalChurchAnnouncement(CurrentLevelID);
                    announcement.AddRange(tmp);

                var TempCurrentLevelID2 = _context.LocalChurches
                .FromSqlInterpolated($"SELECT * FROM LocalChurch WHERE LocalChurchID = {CurrentLevelID}")
                .AsEnumerable()
                .Select(d => d.LocalChurchParishID)
                .FirstOrDefault();

                CurrentLevelID = TempCurrentLevelID2;
            }
        }


        return announcement;
    }
    
    }
}
