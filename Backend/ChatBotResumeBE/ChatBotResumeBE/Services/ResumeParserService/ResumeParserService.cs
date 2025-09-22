using ChatBotResumeBE.Services.AiProvider;
using ChatBotResumeBE.Services.AiProvider.Interface;
using ChatBotResumeBE.Services.ResumeParserService.Interface;
using ChatBotResumeBE.Util.Model;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using net.arnx.jsonic;
using System.Text;
using TikaOnDotNet.TextExtraction;

namespace ChatBotResumeBE.Services.ResumeParserService
{
    public class ResumeParserService : IResumeParser
    {
        private readonly ILogger<ResumeParserService> _logger;
        private readonly Func<string, IAiProvider> _aiProviderClient;
        private readonly TextExtractor _textExtractor;

        public ResumeParserService(ILogger<ResumeParserService> logger, Func<string, IAiProvider> aiProviderClient)
        {
            _logger = logger;
            _aiProviderClient = aiProviderClient;
            _textExtractor = new TextExtractor();
        }

        public async Task<Profile> ParseAsync(IFormFile file)
        {
            //throw new NotImplementedException();
            var text = String.Empty;
            // Use a library like iTextSharp for PDFs or OpenXML for Word documents
            // Extract text from the file
            try 
            {
                using var stream = file.OpenReadStream();
                using var ms = new MemoryStream();
                if (file == null || file.Length == 0)
                    throw new ArgumentException("Invalid file uploaded.");

                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    memoryStream.Position = 0; // Reset to beginning

                    using (var reader = new PdfReader(memoryStream))
                    {
                        StringBuilder output = new StringBuilder();

                        for (int i = 1; i <= reader.NumberOfPages; i++)
                        {
                            string pageText = PdfTextExtractor.GetTextFromPage(reader, i, new LocationTextExtractionStrategy());
                            output.AppendLine(pageText);
                        }

                        text = output.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error extracting text from resume.");
                return null;
            }
            // Use regex or NLP techniques to extract structured data
            var aiProvider = _aiProviderClient("sarvam");
            var response = await aiProvider.GetChatCompletionAsync(text);
            // Map extracted data to Profile object
            var parameterList = response;
            //parameterList.
            return new Profile();
        }
    }
}
