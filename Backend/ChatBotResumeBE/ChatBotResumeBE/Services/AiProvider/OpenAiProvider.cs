using ChatBotResumeBE.Services.AiProvider.Interface;
using OpenAI;
using OpenAI.Chat;
using StackExchange.Redis;

namespace ChatBotResumeBE.Services.AiProvider
{
    public class OpenAiProvider : IAiProvider
    {
        private readonly ChatClient _client;
        private readonly string _model;

        public OpenAiProvider(IConfiguration config)
        {
            var apiKey = config["OpenAI:ApiKey"] ??
                         Environment.GetEnvironmentVariable("OPENAI_API_KEY");

            if (string.IsNullOrEmpty(apiKey))
                throw new InvalidOperationException("OpenAI API key is missing.");

            _client = new(
                model: "gpt-4o-mini",
                credential: new System.ClientModel.ApiKeyCredential(apiKey),
                options: new OpenAIClientOptions()
                {
                    Endpoint = new Uri("BASE_URL")
                }
            );
        }
        public Task<string> GeneratApiLey()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetApiKey()
        {
            var apiKey = "";
            return Task.FromResult(apiKey);
        }

        public async Task<string> GetChatCompletionAsync(string prompt, string systemMessage = "")
        {
            var response = await _client.CompleteChatAsync("You are a helpful AI assistant.");
            return response.FirstChoice?.Message?.Content ?? "";
        }

        public Task<string> GetEmbeddingAsync(string input)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetModerationAsync(string input)
        {
            throw new NotImplementedException();
        }
    }
}
