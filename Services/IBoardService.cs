using Churchmanagement.Models;

namespace Churchmanagement.Services
{
    public interface IBoardService
    {
        public LeadershipBoard getBoardByID(int BoardID);
        public List<LeadershipBoard> getBoardByLevelAndID(int level, int levelID);
    }
}
