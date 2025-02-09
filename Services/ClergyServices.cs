using Churchmanagement.Models;
using Microsoft.EntityFrameworkCore;

namespace Churchmanagement.Services
{
    public class ClergyServices : IClergyServices
    {
        private readonly ApplicationDbContext _context;
        public ClergyServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public Clergy getClergyByID(int clergyID)
        {
            try
            {
                var clergy = _context.Clergies
                                .FromSqlInterpolated($"select * from clergy where clergyID = {clergyID}")
                                .AsEnumerable()
                                .FirstOrDefault();
                return clergy;
            }catch(Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return null;
            }
            
            
        }
        public List<Clergy> getLocalChurchClergy(int localChurchID)
        {
            var clergies = _context.Clergies
                .FromSqlInterpolated($"select * from clergy where clergyRank in (1,2,3) and levelID = {localChurchID}")
                .ToList();
            return clergies;
        }
        public List<Clergy> getParishClergy(int parishID)
        {
            var clergies = _context.Clergies
                .FromSqlInterpolated($"select * from clergy where clergyRank in (4,5) and levelID = {parishID}")
                .ToList();
            return clergies;
        }
        public List<Clergy> getDioceseClergy(int dioceseID)
        {
            var clergies = _context.Clergies
                .FromSqlInterpolated($"select * from clergy where clergyRank in (6) and levelID = {dioceseID}")
                .ToList();
            return clergies;
        }

        public List<Clergy> getAllArchbishops()
        {
            var clergies = _context.Clergies
                .FromSqlInterpolated($"select * from clergy where clergyRank in (7)")
                .ToList();
            return clergies;
        }

        public List<Clergy> getPresidingArchbishop()
        {
            var clergies = _context.Clergies
                .FromSqlInterpolated($"select * from clergy where clergyRank in (8)")
                .ToList();
            return clergies;
        }
    }
}
