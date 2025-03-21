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
    public class ProfileController : ControllerBase
    {

        private readonly ILogger<ProfileController> _logger;
        private readonly IProfileService _profileservices;


        public ProfileController(ILogger<ProfileController> logger, IProfileService profileservice)
        {
            _logger = logger;
            _profileservices = profileservice;
        }

        public class CreateMemberDto
        {
            public string UserId { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
        }
        [AllowAnonymous]
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
                string userId = _profileservices.CreateNewMemberProfileRecord(newMember.UserId, newMember.Name, newMember.Email);

                return Ok(new { message = "Member profile created successfully", userID = userId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the member profile", error = ex.Message });
            }
        }

    }
}
