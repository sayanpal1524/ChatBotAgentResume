using Newtonsoft.Json;

namespace ChatBotResumeBE.Util.DTO.RequestDTO
{
    public class SarvamAIRequestDTO
    {
        [JsonProperty("model")]
        public string model { get; set; }
        [JsonProperty("messages")]
        public List<Message> messages { get; set; } = new List<Message>();
    }
    public class Message
    {
        [JsonProperty("role")]
        public string role { get; set; }
        [JsonProperty("content")]
        public string content { get; set; }
    }
}
