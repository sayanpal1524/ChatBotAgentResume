using ChatBotResumeBE.Services.Authentication.Interface;

namespace ChatBotResumeBE.Services.Authentication
{
    public class OpenAiAuthProvider : IAiAuthProvider
    {
        /// <summary>
        /// Need to check if there is any functionality to call api key from openai, update key periodically
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string GetApiKey()
        {
            // Ideally, fetch this from a secure location like environment variables or a secrets manager
            throw new NotImplementedException();
        }
    }
}
