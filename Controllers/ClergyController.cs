using Churchmanagement.Models;
using Microsoft.AspNetCore.Mvc;
using Churchmanagement.Services;
using Microsoft.AspNetCore.Authorization;

namespace Churchmanagement.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ClergyController : ControllerBase
    {

        private readonly ILogger<ClergyController> _logger;
        private readonly IClergyServices _clergyServices;


        public ClergyController(ILogger<ClergyController> logger, IClergyServices clergyServices)
        {
            _logger = logger;
            _clergyServices = clergyServices;
        }

        [HttpGet("get-clergy/{clergyID}")]
        public IActionResult getClergyByID(int clergyID)
        {
            Console.WriteLine("Fetching getClergyByID");

            var clergy = _clergyServices.getClergyByID(clergyID);

            if (clergy == null)
            {
                return NotFound($"No Clergy found for ClergyID provided");
            }

            return Ok(clergy);
        }

        [HttpGet("localChurch/{localChurchID}")]
        public IActionResult getLocalChurchClergy(int localChurchID)
        {
            Console.WriteLine("Fetching getLocalChurchClergy");

            var clergy = _clergyServices.getLocalChurchClergy(localChurchID);

            if (clergy == null)
            {
                return NotFound($"No Clergy found for LocalChurchID provided");
            }

            return Ok(clergy);
        }

        [HttpGet("parish/{parishID}")]
        public IActionResult getParishClergy(int parishID)
        {
            Console.WriteLine("Fetching getParishClergy");

            var clergy = _clergyServices.getParishClergy(parishID);

            if (clergy == null)
            {
                return NotFound($"No Clergy found for parishID provided");
            }

            return Ok(clergy);
        }

        [HttpGet("diocese/{dioceseID}")]
        public IActionResult getDioceseClergy(int dioceseID)
        {
            Console.WriteLine("Fetching getDioceseClergy");

            var clergy = _clergyServices.getDioceseClergy(dioceseID);

            if (clergy == null)
            {
                return NotFound($"No Clergy found for diocese provided");
            }

            return Ok(clergy);
        }
    }
}
