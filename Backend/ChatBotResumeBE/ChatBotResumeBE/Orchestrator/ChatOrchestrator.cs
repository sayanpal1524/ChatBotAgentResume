using ChatBotResumeBE.Services.AiProvider.Interface;

namespace ChatBotResumeBE.Orchestrator
{
    public class ChatOrchestrator : IChatOrchestrator
    {
        private readonly IAiProvider _aiProvider;

        public ChatOrchestrator(IAiProvider aiProvider)
        {
            _aiProvider = aiProvider;
        }

        public async Task<string> HandleMessageAsync(string sessionId, string userMessage)
        {
            return await _aiProvider.GetChatCompletionAsync(userMessage);
        }

        public async IAsyncEnumerable<string> HandleMessageStreamAsync(string sessionId, string userMessage)
        {
            throw new NotImplementedException();
        }
    }
}
