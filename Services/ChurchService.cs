using Churchmanagement.Models;
using Microsoft.EntityFrameworkCore;

namespace Churchmanagement.Services
{
    public class ChurchService : IChurchService
    {
        private readonly ApplicationDbContext _context;

        public ChurchService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<LocalChurch> GetLocalChurchesInParish(int parishID)
        {
            var churches = _context.LocalChurches
                //.FromSqlRaw("SELECT * FROM ChurchMember")
                .FromSqlInterpolated($"SELECT * FROM LocalChurch where LocalChurchParishID =  {parishID}")
                .ToList();

            return churches;
        }
        public List<LocalChurch> GetLocalChurchesInDiocese(int dioceseID)
        {
            var members = _context.LocalChurches
                //.FromSqlRaw("SELECT * FROM ChurchMember")
                .FromSqlInterpolated($"SELECT * FROM LocalChurch where LocalChurchParishID IN \r\n(Select parishID from Parish where DioceseID = {dioceseID})")
                .ToList();

            return members;
        }

        public List<Parish> GetParishesInDiocese(int dioceseID)
        {
            var members = _context.Parishes
                //.FromSqlRaw("SELECT * FROM ChurchMember")
                .FromSqlInterpolated($"SELECT * FROM Parish where DioceseID = {dioceseID}")
                .ToList();

            return members;
        }

        public List<Diocese> GetAllDiocese()
        {
            var dioceses = _context.Dioceses
                //.FromSqlRaw("SELECT * FROM ChurchMember")
                .FromSqlInterpolated($"SELECT * FROM Diocese")
                .ToList();

            return dioceses;
        }

        public List<Parish> GetAllParish()
        {
            var parishes = _context.Parishes
                //.FromSqlRaw("SELECT * FROM ChurchMember")
                .FromSqlInterpolated($"SELECT * FROM Parish")
                .ToList();

            return parishes;
        }

        public LocalChurch GetLocalChurchDetails(int localChurchID)
        {
            var lc = _context.LocalChurches
                .FromSqlInterpolated($"SELECT * FROM LocalChurch WHERE localchurchid = {localChurchID}")
                .AsEnumerable()
                .FirstOrDefault();

            if (lc == null)
            {
                throw new KeyNotFoundException($"Local Church with ID {localChurchID} not found.");
            }

            return lc;
        }

    }
}
