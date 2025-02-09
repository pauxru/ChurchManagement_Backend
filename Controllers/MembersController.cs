using Churchmanagement.Models;
using Microsoft.AspNetCore.Mvc;
using Churchmanagement.Services;
using Microsoft.AspNetCore.Authorization;
using System.Text.RegularExpressions;

namespace Churchmanagement.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MembersController : ControllerBase
    {

        private readonly ILogger<MembersController> _logger;
        private readonly IMemberService _memberservices;
        

        public MembersController(ILogger<MembersController> logger, IMemberService memberService)
        {
            _logger = logger;
            _memberservices = memberService;
        }

        public class CreateMemberDto
        {
            public string UserId { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
        }

        [HttpPost("Profile-Create")]
        public IActionResult CreateNewMemberProfileRecord([FromBody] CreateMemberDto newMember)
        {
            Console.WriteLine("Here at CreateNewMemberProfileRecord");

            if (newMember == null || string.IsNullOrWhiteSpace(newMember.Name) || string.IsNullOrWhiteSpace(newMember.Email) || string.IsNullOrWhiteSpace(newMember.UserId))
            {
                return BadRequest(new { message = "Name and Email are required." });
            }

            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!emailRegex.IsMatch(newMember.Email))
            {
                return BadRequest(new { message = "The email is invalid." });
            }

            try
            {
                // Call service to create a new member profile
                string userId = _memberservices.CreateNewMemberProfileRecord(newMember.UserId, newMember.Name, newMember.Email);

                return Ok(new { message = "Member profile created successfully", userID = userId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the member profile", error = ex.Message });
            }
        }


        [HttpGet("local-church/{localChurchId}")]
        public IActionResult GetMembersByLocalChurch(int localChurchId)
        {
            Console.WriteLine("Here at GetMembersByLocalChurch");
            var members  = _memberservices.GetLCMembers(localChurchId);

            if (members == null) {
                return NotFound($"No members found for LocalChurchID: {localChurchId}");
            }
            
            return Ok(members);
        }

        
        [HttpGet("parish/{parishId}")]
        public IActionResult GetMembersByParish(int parishId)
        {
            Console.WriteLine("Here at GetMembersByParsih");
            var members  = _memberservices.GetParishMembers(parishId);

            if (members == null) {
                return NotFound($"No members found for LocalChurchID: {parishId}");
            }
            
            return Ok(members);
        } 

        [HttpGet("diocese/{dioceseID}")]
        public IActionResult GetMembersByDiocese(int dioceseID)
        {
            Console.WriteLine("Here at GetMembersByDiocese");
            var members  = _memberservices.GetDioceseMembers(dioceseID);

            if (members == null) {
                return NotFound($"No members found for LocalChurchID: {dioceseID}");
            }
            
            return Ok(members);
        }

        [HttpGet("Archdiocese/{archDioceseID}")]
        public IActionResult GetArchDioceseMembers(int archDioceseID)
        {
            Console.WriteLine("Here at GetArchDioceseMembers");
            var members  = _memberservices.GetArchDioceseMembers(archDioceseID);

            if (members == null) {
                return NotFound($"No members found for ArchDiocese: {archDioceseID}");
            }
            
            return Ok(members);
        }

        
    }
}
