using ChatBotResumeBE.Services.AiProvider.Interface;
using ChatBotResumeBE.Services.ResumeParserService.Interface;
using ChatBotResumeBE.Util.Model;
using net.arnx.jsonic;
using TikaOnDotNet.TextExtraction;

namespace ChatBotResumeBE.Services.ResumeParserService
{
    public class ResumeParserService : IResumeParser
    {
        private readonly ILogger<ResumeParserService> _logger;
        private readonly IAiProvider _aiProviderClient;
        private readonly TextExtractor _textExtractor;

        public ResumeParserService(ILogger<ResumeParserService> logger, IAiProvider aiProviderClient)
        {
            _logger = logger;
            _aiProviderClient = aiProviderClient;
            _textExtractor = new TextExtractor();
        }

        public async Task<Profile> ParseAsync(IFormFile file)
        {
            //throw new NotImplementedException();
            // Use a library like iTextSharp for PDFs or OpenXML for Word documents
            // Extract text from the file
            using var stream = file.OpenReadStream();
            using var ms = new MemoryStream();
            await stream.CopyToAsync(ms);
            var text = _textExtractor.Extract(ms.ToArray()).Text;
            // Use regex or NLP techniques to extract structured data
            var response = await _aiProviderClient.GetChatCompletionAsync(text);
            // Map extracted data to Profile object
            var parameterList = response.Select(x => x.Text);
            //parameterList.
            // return profile;
        }
    }
}
