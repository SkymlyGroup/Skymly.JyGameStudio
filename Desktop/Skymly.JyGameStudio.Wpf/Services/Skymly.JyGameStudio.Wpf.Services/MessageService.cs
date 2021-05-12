using Skymly.JyGameStudio.Wpf.Services.Interfaces;

namespace Skymly.JyGameStudio.Wpf.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}
