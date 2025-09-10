using ChatBotResumeBE.Services.ResumeParserService.Interface;
using ChatBotResumeBE.Util.Model;

namespace ChatBotResumeBE.Services.ResumeParserService
{
    public class ResumeParserService : IResumeParser
    {
        public async Task<Profile> ParseAsync(IFormFile file)
        {
            throw new NotImplementedException();
            // Use a library like iTextSharp for PDFs or OpenXML for Word documents
            // Extract text from the file
            // Use regex or NLP techniques to extract structured data
            // Map extracted data to Profile object
            // return profile;
        }
    }
}
