using ChatBotResumeBE.Services.AiProvider.Interface;
using com.sun.org.apache.xpath.@internal.operations;
using OpenAI.Chat;

namespace ChatBotResumeBE.Services.AiProvider
{
    public class SarvamAiProvider : IAiProvider
    {
        private readonly string? _apiKey = Environment.GetEnvironmentVariable("SARVAM_API_KEY");
        private const string? _chatCompletionUri = "v1/chat/completions";
        private readonly string _model;
        private readonly string _chatCompletionEndpoint;

        public SarvamAiProvider(IConfiguration config)
        {
            if (string.IsNullOrEmpty(_apiKey))
                throw new InvalidOperationException("Sarvam API key is missing.");
            _model = config["Sarvam:Model"] ?? "sarvam-m";
            _chatCompletionEndpoint = config["Sarvam:BaseUrl"]+_chatCompletionUri;
        }

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
