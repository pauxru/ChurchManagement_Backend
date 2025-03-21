using Churchmanagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace Churchmanagement.Services
{
    public interface IMemberService
    {
        List<ChurchMember> GetLCMembers(int localChurch);

        List<ChurchMember> GetParishMembers(int parishID);

        List<ChurchMember> GetDioceseMembers(int dioceseID);

        List<ChurchMember> GetArchDioceseMembers(int archDioceseID);

        

    }
}
