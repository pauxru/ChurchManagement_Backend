using Churchmanagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace Churchmanagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnnouncementController : ControllerBase
    {

        private readonly ILogger<AnnouncementController> _logger;
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(ILogger<AnnouncementController> logger, IAnnouncementService announcementService)
        {
            _logger = logger;
            _announcementService = announcementService;

        }

        [HttpGet("get-announcement/{eventId}")]
        public IActionResult getAnnouncementByID(int eventId)
        {
            if (eventId <= 0)
            {
                return BadRequest("Invalid event ID provided.");
            }

            Console.WriteLine($"Fetching getAnnouncementByID: {eventId}");

            var announce = _announcementService.getAnnouncementByID(eventId);

            if (announce == null)
            {
                return NotFound("No Clergy found for Event provided");
            }

            return Ok(announce);
        }

        [HttpGet("get-level-announcement/{announcementLevel}/{levelId}")]
        public IActionResult getLevelAnnouncement(int announcementLevel, int levelId)
        {
            Console.WriteLine("Fetching getAnnouncementByID");

            var announce = _announcementService.getLevelAnnouncement(announcementLevel, levelId);

            if (announce == null)
            {
                return NotFound($"No Announcement found for provided id");
            }

            return Ok(announce);
        }
    }
}
