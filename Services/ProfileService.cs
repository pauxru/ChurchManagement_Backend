using Churchmanagement.Models;
using Microsoft.EntityFrameworkCore;

namespace Churchmanagement.Services
{
    public class ProfileService : IProfileService
    {
        private readonly ApplicationDbContext _context;
        public ProfileService(ApplicationDbContext context)
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
    }
}
