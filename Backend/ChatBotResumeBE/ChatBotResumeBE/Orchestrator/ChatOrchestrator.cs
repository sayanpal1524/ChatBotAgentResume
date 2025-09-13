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
            // Add a call to the AI provider to get a response
            var response =  await _aiProvider.GetChatCompletionAsync(userMessage);
            // Add a generic call to Map the call to class object
            return response.ToString();
        }

        //public async IAsyncEnumerable<string> HandleMessageStreamAsync(string sessionId, string userMessage)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
