namespace Churchmanagement.Services
{
    public interface ITwilioCommunication
    {
        bool SendWelcomeMessage(string recipientPhoneNumber, string messageBody);
        Task<bool> SendWelcomeMessageCelcom(string recipientPhoneNumber, string messageBody);
    }
}
