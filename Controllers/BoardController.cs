using Churchmanagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace Churchmanagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardController : ControllerBase
    {
        private readonly ILogger<BoardController> _logger;
        private readonly IBoardService _boardService;

        public BoardController(ILogger<BoardController> logger, IBoardService boardService)
        {
            _logger = logger;
            _boardService = boardService;

        }

        [HttpGet("get-board/{boardId}")]
        public IActionResult getBoardByID(int boardId)
        {
            if (boardId <= 0)
            {
                return BadRequest("Invalid Board ID provided.");
            }

            Console.WriteLine($"Fetching getBoardByID: {boardId}");

            var board = _boardService.getBoardByID(boardId);

            if (board == null)
            {
                return NotFound("No board found for Event provided");
            }

            return Ok(board);
        }

        [HttpGet("get-level-board/{boardLevel}/{levelId}")]
        public IActionResult getBoardByLevelAndID(int boardLevel, int levelId)
        {
            Console.WriteLine("Fetching getBoardByLevelAndID");

            var boards = _boardService.getBoardByLevelAndID(boardLevel, levelId);

            if (boards == null)
            {
                return NotFound($"No boards found for Events provided");
            }

            return Ok(boards);
        }
    }
}
