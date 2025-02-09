using Churchmanagement.Models;
using Microsoft.EntityFrameworkCore;

namespace Churchmanagement.Services
{
    public class MemberService : IMemberService
    {
        private readonly ApplicationDbContext _context;

        public MemberService(ApplicationDbContext context)
        {
            _context = context;
        }

        public string CreateNewMemberProfileRecord(string userId, string name, string email)
        {
            try
            {
                var newUserProfile = new UserProfile
                {
                    UserID = userId,
                    MemberName = name,
                    MemberEmail = email
                };

                // Add the new record to the UserProfiles table
                _context.UserProfile.Add(newUserProfile);

                // Save changes to the database
                _context.SaveChanges();

                // Return the ID of the newly created record
                return newUserProfile.UserID;
            }
            catch (Exception ex)
            {
                // Log the error or handle it appropriately
                Console.WriteLine($"Error creating new member profile: {ex.Message}");
                throw; // Re-throw the exception if neededdot
            }
        }

        public List<ChurchMember> GetLCMembers(int localChurch)
        {
            var members = _context.ChurchMembers
                //.FromSqlRaw("SELECT * FROM ChurchMember")
                .FromSqlInterpolated($"SELECT * FROM ChurchMember WHERE MemberLocalChurchID = {localChurch}")
                .ToList();

            return members;
        }
        public List<ChurchMember> GetParishMembers(int parishID)
        {
            var members = _context.ChurchMembers
                //.FromSqlRaw("SELECT * FROM ChurchMember")
                .FromSqlInterpolated($"SELECT * FROM ChurchMember WHERE MemberLocalChurchID in (Select localchurchID from LocalChurch where LocalChurchParishID =  {parishID})")
                .ToList();

            return members;
        }

        public List<ChurchMember> GetDioceseMembers(int dioceseID)
        {
            var members = _context.ChurchMembers
                //.FromSqlRaw("SELECT * FROM ChurchMember")
                .FromSqlInterpolated($"SELECT * FROM ChurchMember WHERE MemberLocalChurchID in \r\n(Select localchurchID from LocalChurch where LocalChurchParishID IN\r\n(select parishID from Parish where DioceseID =  {dioceseID}))")
                .ToList();

            return members;
        }

        public List<ChurchMember> GetArchDioceseMembers(int archDioceseID)
        {
            var members = _context.ChurchMembers
                //.FromSqlRaw("SELECT * FROM ChurchMember")
                .FromSqlInterpolated($"SELECT * FROM ChurchMember WHERE MemberLocalChurchID in (Select localchurchID from LocalChurch where LocalChurchParishID IN (select parishID from Parish where DioceseID IN (Select DioceseID FROM Diocese WHERE ArchDioceseID =  {archDioceseID})))")
                .ToList();

            return members;
        }

         
    }
}
