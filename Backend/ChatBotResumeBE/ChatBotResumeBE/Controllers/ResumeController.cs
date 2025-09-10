using Microsoft.AspNetCore.Mvc;

namespace ChatBotResumeBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResumeController : Controller
    {
        [HttpPost("uploadResume")]
        public async Task<IActionResult> UploadResume(IFormFile file)
        {
            //Parse resume → structured profile
            //var profile = await _resumeParser.ParseAsync(file);
            //await _profileService.SaveAsync(profile);
            //return Ok(profile);
            throw new NotImplementedException();
        }

    }
}
