using ChatBotResumeBE.Util.DTO.RequestDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatBotResumeBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        [HttpGet("findJobs/{profileId}")]
        public async Task<IActionResult> FindJobs(Guid profileId)
        {
            //var profile = await _profileService.GetAsync(profileId);

            //var jobs = await _jobScraper.FetchJobsAsync(profile.Skills);
            //var matches = await _jobMatcher.MatchAsync(profile, jobs);

            //return Ok(matches.OrderByDescending(m => m.FitScore));
            throw new NotImplementedException();
        }

        [HttpPost("applyJob")]
        public async Task<IActionResult> ApplyJob([FromBody] ApplyJobRequest request)
        {
            //var profile = await _profileService.GetAsync(request.ProfileId);
            //var job = await _jobScraper.GetJobAsync(request.JobId);

            //var success = await _applicationAgent.ApplyAsync(profile, job);
            //return Ok(new { Applied = success });
            throw new NotImplementedException();
        }

    }
}
