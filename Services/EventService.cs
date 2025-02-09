using Churchmanagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Churchmanagement.Services
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _context;
        public EventService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Event getEventByID(int EventID)
        {
            try
            {
                var query = $"SELECT * FROM Event WHERE EventID = {EventID}";
                Console.WriteLine($"Executing query: {query}");

                var evnt = _context.Events
                    .FromSqlInterpolated($"SELECT * FROM Event WHERE EventID = {EventID}")
                    .AsEnumerable()
                    .FirstOrDefault();

                if (evnt == null)
                {
                    throw new KeyNotFoundException($"Event with ID {EventID} not found.");
                }

                return evnt;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }


        private List<Event> getLocalChurchEvents( int levelID)
        {
            var events = _context.Events
                .FromSqlInterpolated($"SELECT * FROM Event where Eventlevel = 1 AND eventLevelID = {levelID}")
                .ToList();

            return events;
        }
        private List<Event> getParishEvents( int levelID)
        {
            var events = _context.Events
                .FromSqlInterpolated($"SELECT * FROM Event where Eventlevel = 2 AND eventLevelID = {levelID}")
                .ToList();

            return events;
        }
        private List<Event> getDioceseEvents( int levelID)
        {
            var events = _context.Events
                .FromSqlInterpolated($"SELECT * FROM Event where Eventlevel = 3 AND eventLevelID = {levelID}")
                .ToList();

            return events;
        }
        private List<Event> getArchDioceseEvents(int levelID)
        {
            var events = _context.Events
                .FromSqlInterpolated($"SELECT * FROM Event where Eventlevel = 4 AND eventLevelID = {levelID}")
                .ToList();

            return events;
        }

        public List<Event> getLevelEvents(int level, int levelID)
        {
            int CurrentLevelID = levelID;

            var events = _context.Events
                .FromSqlInterpolated($"SELECT * FROM Event where Eventlevel = 5")
                .ToList();

            for (int i = level; i < (int)LeadershipLevels.National; i++)
            {
                if (i == (int)LeadershipLevels.AchDiocese)
                {
                    var tmp = getArchDioceseEvents(CurrentLevelID);
                    Console.WriteLine($"getArchDioceseEvents : {tmp}");

                }

                if (i == (int)LeadershipLevels.Diocese)
                {
                    var tmp = getDioceseEvents(CurrentLevelID);
                    events.AddRange(tmp);

                    var TempCurrentLevelID1 = _context.Dioceses
                    .FromSqlInterpolated($"SELECT * FROM Diocese WHERE DioceseID = {CurrentLevelID}")
                    .AsEnumerable()
                    .Select(d => d.ArchDioceseId)
                    .FirstOrDefault();

                    CurrentLevelID = TempCurrentLevelID1.Value;
                }

                if (i == (int)LeadershipLevels.Parish)
                {
                    var tmp = getParishEvents(CurrentLevelID);
                    events.AddRange(tmp);

                    var TempCurrentLevelID2 = _context.Parishes
                    .FromSqlInterpolated($"SELECT * FROM Parish WHERE ParishID = {CurrentLevelID}")
                    .AsEnumerable()
                    .Select(d => d.DioceseID)
                    .FirstOrDefault();

                    CurrentLevelID = TempCurrentLevelID2;
                }

                if (i == (int)LeadershipLevels.LocalChurch)
                {
                    var tmp = getLocalChurchEvents(CurrentLevelID);
                    events.AddRange(tmp);

                    var TempCurrentLevelID2 = _context.LocalChurches
                    .FromSqlInterpolated($"SELECT * FROM LocalChurch WHERE LocalChurchID = {CurrentLevelID}")
                    .AsEnumerable()
                    .Select(d => d.LocalChurchParishID)
                    .FirstOrDefault();

                    CurrentLevelID = TempCurrentLevelID2;
                }
            }

            
            return events;
        }
    }
}
