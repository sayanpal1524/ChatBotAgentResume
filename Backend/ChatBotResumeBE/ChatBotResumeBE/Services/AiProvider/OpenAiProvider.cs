using ChatBotResumeBE.Services.AiProvider.Interface;
using OpenAI;
using OpenAI.Chat;
using StackExchange.Redis;
using static System.Net.Mime.MediaTypeNames;

namespace ChatBotResumeBE.Services.AiProvider
{
    public class OpenAiProvider : IAiProvider
    {
        private readonly OpenAIClient _client;
        private readonly string _model;

        public OpenAiProvider(IConfiguration config)
        {
            var apiKey = config["OpenAI:ApiKey"] ??
                         Environment.GetEnvironmentVariable("OPENAI_API_KEY");

            if (string.IsNullOrEmpty(apiKey))
                throw new InvalidOperationException("OpenAI API key is missing.");

            _client = new OpenAIClient(apiKey);
            _model = config["OpenAI:Model"] ?? "gpt-4o-mini";
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

        public async Task<ChatMessageContent> GetChatCompletionAsync(string prompt, string systemMessage = "")
        {
            if (string.IsNullOrEmpty(prompt))
            {
                // 2. Prompt OpenAI for structured extraction
                var chatRequest = new ChatRequest(
                    messages: new List<Message>
                    {
                        new Message(new Role().System, "You are a resume parsing assistant. Extract structured data from resumes."),
                        new Message(new Role().User, $@"Parse this resume into JSON with keys: FullName, Email, Phone, Summary, Skills, Experience, Education, Certifications.
                            Resume Text:
                            {prompt}"
                        )
                    },
                    model: _model,
                    temperature: 0
                );
            }
            var response = await _client.GetChatClient(_model).CompleteChatAsync(prompt);
            return response.Value.Content;
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
