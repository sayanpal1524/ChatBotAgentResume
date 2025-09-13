
namespace ChatBotResumeBE.Services.AiProvider
{
    public class ChatRequest
    {
        private List<Message> messages;
        private string model;
        private int temperature;

        public ChatRequest(List<Message> messages, string model, int temperature)
        {
            this.messages = messages;
            this.model = model;
            this.temperature = temperature;
        }
    }

    public class Message
    {
        private readonly string _role;
        private readonly string _prompt;
        public Message(string role, string prompt)
        {
            _role = role;
            _prompt = prompt;
        }
    }

    public class Role
    {
        public string System { get; set; } = string.Empty;
        public string User { get; set; } = string.Empty;
    }
}