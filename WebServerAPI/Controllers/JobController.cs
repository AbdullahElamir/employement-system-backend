using Microsoft.AspNetCore.Mvc;
using WebServerAPI.DTOs;
using WebServerAPI.Services;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
;
        }

        [HttpGet("GetJob")]
        public IActionResult Get()
        {
            var jobs = _jobService.GetAllJobs();
            return Ok(jobs);
        }

        [HttpGet("GetJob/{id}")]
        public IActionResult GetJob(int id)
        {
            var job = _jobService.GetJobById(id);
            if (job == null)
            {
                return NotFound("Job not found");
            }
            return Ok(job);
        }


        [HttpPost("AddJob")]
        public IActionResult Post([FromBody] JobPostDto job)
        {
            if (string.IsNullOrEmpty(job.JobName))
            {
                return BadRequest("Job name is required");
            }

            _jobService.AddJob(job);
            return Ok("Job added successfully");
        }

        [HttpPut("UpdateJob/{id}")]
        public IActionResult UpdateJob(int id, [FromBody] JobPostDto Ujob)
        {
            if (string.IsNullOrEmpty(Ujob.JobName))
            {
                return BadRequest("Job name is required");
            }

            var job = _jobService.GetJobById(id);
            if (job == null)
            {
                return NotFound("Job not found");
            }

            _jobService.UpdateJob(id, Ujob);
            return Ok("Job updated successfully");
        }

        [HttpDelete("DeleteJob/{id}")]
        public IActionResult DeleteJob(int id)
        {
            var job = _jobService.GetJobById(id);
            if (job == null)
            {
                return NotFound("Job not found");
            }
            else
            {
                _jobService.DeleteJob(id);
                return Ok("Job deleted successfully");
            }
        }
    }
}
