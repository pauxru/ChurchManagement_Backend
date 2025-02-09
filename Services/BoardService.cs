using Churchmanagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Churchmanagement.Services
{
    public class BoardService : IBoardService
    {
        private readonly ApplicationDbContext _context;

        public BoardService(ApplicationDbContext context)
        {
            _context = context;
            
        }

        public LeadershipBoard getBoardByID(int BoardID)
        {
            var board = _context.LeadershipBoards
                .FromSqlInterpolated($"SELECT * FROM leadershipBoard WHERE boardID = {BoardID}")
                .AsEnumerable()
                .FirstOrDefault();
            
            if (board == null)
            {
                throw new KeyNotFoundException($"Board with ID {BoardID} not found.");
            }

            return board;
        }

        public List<LeadershipBoard> getBoardByLevelAndID(int level, int levelID)
        {
            var boards = _context.LeadershipBoards
                .FromSqlInterpolated($"SELECT * FROM LeadershipBoard where LeadershipLevel = {level} AND LevelID = {levelID}")
                .ToList();

            return boards;
        }
    }
}
