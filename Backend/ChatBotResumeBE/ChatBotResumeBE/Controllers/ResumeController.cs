using ChatBotResumeBE.Services.ResumeParserService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ChatBotResumeBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResumeController : Controller
    {
        private readonly ILogger<ResumeController> _logger;
        private readonly IResumeParser _resumeParser;
        //private readonly IProfileService _profileService;

        public ResumeController(ILogger<ResumeController> logger, IResumeParser resumeParser/*, IProfileService profileService*/)
        {
            _logger = logger;
            _resumeParser = resumeParser;
            //_profileService = profileService;
        }

        [HttpPost("uploadResume")]
        public async Task<IActionResult> UploadResume(IFormFile file)
        {
            //Parse resume → structured profile
            var profile = await _resumeParser.ParseAsync(file);
            //await _profileService.SaveAsync(profile);
            if (profile != null)
            {
                return UnprocessableEntity();
            }
            else
            {
                return Ok(profile);
            }
        }

    }
}
