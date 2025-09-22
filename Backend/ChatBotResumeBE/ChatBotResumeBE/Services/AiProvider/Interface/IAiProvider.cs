using OpenAI.Chat;

namespace ChatBotResumeBE.Services.AiProvider.Interface
{
    public interface IAiProvider
    {
        Task<string> GetChatCompletionAsync(string prompt, string systemMessage = "");
        Task<string> GetEmbeddingAsync(string input);
        Task<string> GetModerationAsync(string input);
        Task<string> GetApiKey();
        Task<string> GeneratApiLey();
    }
}
