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
        private readonly HttpClient _httpClient = new HttpClient();

        public SarvamAiProvider(IConfiguration config, HttpClient httpClient)
        {
            if (string.IsNullOrEmpty(_apiKey))
                throw new InvalidOperationException("Sarvam API key is missing.");
            _model = config["SarvamAI:Model"] ?? "sarvam-m";
            _chatCompletionEndpoint = config["SarvamAI:BaseUrl"] + _chatCompletionUri;
            _httpClient = httpClient;
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
            //Create the request payload
            var requestPayload = new
            {
                model = _model,
                messages = new[]
                {
                    new { role = "user", content = prompt }
                }
            };
            var jsonPayload = System.Text.Json.JsonSerializer.Serialize(requestPayload);
            var content = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json");
            try
            {
                //Make the HTTP POST request to Sarvam API
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);
                var response = _httpClient.PostAsync(_chatCompletionEndpoint, content);
                if(response.Result.IsSuccessStatusCode)
                {
                    //Parse the response and return the content
                    var responseContent = response.Result.Content.ReadAsStringAsync().Result;
                    return Task.FromResult(responseContent);
                }
                else
                {
                    throw new Exception($"Sarvam API error: {response.Result.StatusCode}, {response.Result.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while calling Sarvam API: " + ex.Message);
            }
            
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
