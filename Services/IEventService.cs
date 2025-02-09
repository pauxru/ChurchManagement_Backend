using Churchmanagement.Models;

namespace Churchmanagement.Services
{
    public interface IEventService
    {
        public Event getEventByID(int EventID);
        public List<Event> getLevelEvents(int level, int levelID);
        //public List<Event> getEvents(int level, int levelID);
    }
}
