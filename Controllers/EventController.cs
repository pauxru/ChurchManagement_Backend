using Churchmanagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace Churchmanagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        
        private readonly ILogger<EventsController> _logger;
        private readonly IEventService _eventService;

        public EventsController(ILogger<EventsController> logger, IEventService eventService)
        {
            _logger = logger;
            _eventService = eventService;
            
        }

        [HttpGet("get-event/{eventId}")]
        public IActionResult getEventByID(int eventId)
        {
            if (eventId <= 0)
            {
                return BadRequest("Invalid event ID provided.");
            }

            Console.WriteLine($"Fetching getEventByID: {eventId}");

            var evnt = _eventService.getEventByID(eventId);

            if (evnt == null)
            {
                return NotFound("No Clergy found for Event provided");
            }

            return Ok(evnt);
        }

        [HttpGet("get-level-events/{eventLevel}/{levelId}")]
        public IActionResult getLevelEvents(int eventLevel, int levelId)
        {
            Console.WriteLine("Fetching getLevelEvents");

            var evnts = _eventService.getLevelEvents(eventLevel, levelId);

            if (evnts == null)
            {
                return NotFound($"No Clergy found for Events provided");
            }

            return Ok(evnts);
        }
    }
}
