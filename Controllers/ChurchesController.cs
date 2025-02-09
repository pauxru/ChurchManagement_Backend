using Churchmanagement.Models;
using Microsoft.AspNetCore.Mvc;
using Churchmanagement.Services;
using Microsoft.AspNetCore.Authorization;

namespace Churchmanagement.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class ChurchesController : ControllerBase
    {

        private readonly ILogger<ChurchesController> _logger;
        private readonly IChurchService _churchService;

        public ChurchesController(ILogger<ChurchesController> logger, IChurchService churchService)
        {
            _logger = logger;
            _churchService = churchService;
        }

        [Authorize]
        [HttpGet("parish/{parishId}")]
        public IActionResult GetLocalChurchesByParish(int parishId)
        {
            Console.WriteLine("Here at GetMembersByParsih");
            var members = _churchService.GetLocalChurchesInParish(parishId);

            if (members == null)
            {
                return NotFound($"No members found for LocalChurchID: {parishId}");
            }

            return Ok(members);
        }

        [Authorize]
        [HttpGet("diocese/{dioceseID}")]
        public IActionResult GetLocalChurchesByDiocese(int dioceseID)
        {
            Console.WriteLine("Fetching local churches for DioceseID: " + dioceseID.ToString() );

            var localChurches = _churchService.GetLocalChurchesInDiocese(dioceseID);

            if (localChurches == null || !localChurches.Any())
            {
                return NotFound($"No local churches found for DioceseID: {dioceseID}");
            }

            return Ok(localChurches);
        }

        [Authorize]
        [HttpGet("diocese-parishes/{dioceseID}")]
        public IActionResult GetParishesInDiocese(int dioceseID)
        {
            Console.WriteLine("Fetching local parishes for DioceseID: " + dioceseID.ToString());

            var parishes = _churchService.GetParishesInDiocese(dioceseID);

            if (parishes == null || !parishes.Any())
            {
                return NotFound($"No local churches found for DioceseID: {dioceseID}");
            }

            return Ok(parishes);
        }

        [Authorize]
        [HttpGet("diocese")]
        public IActionResult GetAllDiocese()
        {
            Console.WriteLine("Fetching All Dioceses");

            var dioceses = _churchService.GetAllDiocese();

            if (dioceses == null || !dioceses.Any())
            {
                return NotFound($"No dioceses found for DioceseID");
            }

            return Ok(dioceses);
        }

        [Authorize]
        [HttpGet("local_church/{localChurchID}")]
        public IActionResult GetLocalChurchDetails(int localChurchID)
        {
            Console.WriteLine("Fetching All Dioceses");

            var LC = _churchService.GetLocalChurchDetails(localChurchID);

            if (LC == null)
            {
                return NotFound($"No Local Church found for LocalChurchID provided");
            }

            return Ok(LC);
        }


    }
}
