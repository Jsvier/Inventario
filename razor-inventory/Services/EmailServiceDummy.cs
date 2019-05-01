using Microsoft.Extensions.Logging;

namespace razor_inventory.Services
{
    public class EmailServiceDummy : IEmailServices
    {
        public ILogger<EmailServiceDummy> Logger { get; set; }
        public EmailServiceDummy(ILogger<EmailServiceDummy> logger )
        {
            Logger = logger;
        }
        public string SendMail()
        {
            Logger.LogWarning("LOG");
            return "Javier Etchepare";
        }
    }
}