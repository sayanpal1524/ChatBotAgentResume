using ChatBotResumeBE.Services.AiProvider.Interface;
using OpenAI.Chat;

namespace ChatBotResumeBE.Services.AiProvider
{
    public class SarvamAiProvider : IAiProvider
    {
        public Task<string> GeneratApiLey()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetApiKey()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetChatCompletionAsync(string prompt, string systemMessage = "")
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmbeddingAsync(string input)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetModerationAsync(string input)
        {
            throw new NotImplementedException();
        }

        Task<ChatMessageContent> IAiProvider.GetChatCompletionAsync(string prompt, string systemMessage)
        {
            throw new NotImplementedException();
        }
    }
}
