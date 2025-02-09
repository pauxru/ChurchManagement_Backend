using Churchmanagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace Churchmanagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageCommunicationController
    {
        private readonly ILogger<MessageCommunicationController> _logger;
        private readonly ITwilioCommunication _twilioCommunication;

        public MessageCommunicationController(ILogger<MessageCommunicationController> logger, ITwilioCommunication twilioCommunication)
        {
            _logger = logger;
            _twilioCommunication = twilioCommunication;
        }

        [HttpGet("send-welcome-message/{phoneNumber}")]
        public Task<bool> SendWelcomeMessage(string phoneNumber) {
            var snt = _twilioCommunication.SendWelcomeMessageCelcom("0701336504", "Hi, Welcome to AIPCA. We're glad to have you!");

            return snt;
        }
    }
}
