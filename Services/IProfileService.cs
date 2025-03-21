namespace Churchmanagement.Services
{
    public interface IProfileService
    {
        string CreateNewMemberProfileRecord(string userId, string name, string email);
    }
}
