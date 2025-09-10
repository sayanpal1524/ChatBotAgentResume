namespace ChatBotResumeBE.Services.ResumeParserService.Interface
{
    public interface IResumeParser
    {
        public Task<Util.Model.Profile> ParseAsync(IFormFile file);
    }
}
