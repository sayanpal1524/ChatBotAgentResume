using ChatBotResumeBE.Services.AiProvider.Interface;

namespace ChatBotResumeBE.Orchestrator
{
    public class ChatOrchestrator : IChatOrchestrator
    {
        private readonly Func<string, IAiProvider> _aiProvider;

        public ChatOrchestrator(Func<string, IAiProvider> aiProvider)
        {
            _aiProvider = aiProvider;
        }

        public async Task<string> HandleMessageAsync(string sessionId, string userMessage)
        {
            // Add a call to the AI provider to get a response
            var aiProviderClient = _aiProvider("openai");
            var response =  await aiProviderClient.GetChatCompletionAsync(userMessage);
            // Add a generic call to Map the call to class object
            return response.ToString();
        }

        //public async IAsyncEnumerable<string> HandleMessageStreamAsync(string sessionId, string userMessage)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
