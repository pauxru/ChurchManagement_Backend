using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Churchmanagement.Services
{
    public class TwilioCommunication : ITwilioCommunication
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public TwilioCommunication(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public bool SendWelcomeMessage(string recipientPhoneNumber, string messageBody)
        {
            try
            {
                // Fetch credentials from appsettings.json
                var accountSid = _configuration["Twilio:ACCOUNT_SID"];
                var authToken = _configuration["Twilio:AUTH_TOKEN"];
                var fromPhoneNumber = _configuration["Twilio:FromPhoneNumber"];

                // Initialize Twilio client
                TwilioClient.Init(accountSid, authToken);

                // Send the message
                var message = MessageResource.Create(
                    to: new PhoneNumber(recipientPhoneNumber),
                    from: new PhoneNumber(fromPhoneNumber),
                    body: messageBody
                );

                Console.WriteLine($"Message sent successfully with SID: {message.Sid}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send message: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> SendWelcomeMessageCelcom(string recipientPhoneNumber, string messageBody)
        {
            try
            {
                // Retrieve values from appsettings.json
                string url = _configuration["CelcomSms:Url"];
                string partnerId = _configuration["CelcomSms:PartnerID"];
                string apiKey = _configuration["CelcomSms:ApiKey"];
                string shortcode = _configuration["CelcomSms:Shortcode"];
                string passType = _configuration["CelcomSms:PassType"];

                // Prepare the request payload
                var payload = new
                {
                    partnerID = partnerId,
                    apikey = apiKey,
                    mobile = recipientPhoneNumber,
                    message = messageBody,
                    shortcode = shortcode,
                    pass_type = passType
                };

                string jsonData = JsonSerializer.Serialize(payload);

                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    // Make the POST request
                    var response = await httpClient.PostAsync(url, content);

                    // Ensure the response is successful
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Message sent successfully.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"Failed to send message. Status Code: {response.StatusCode}");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
    }
}