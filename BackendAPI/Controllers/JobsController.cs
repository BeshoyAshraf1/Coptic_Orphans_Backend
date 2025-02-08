using BAL.managers;
using BAL.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace TaskBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IJobManager _jobManager;

        public JobsController(IJobManager jobManager)
        {
            _jobManager = jobManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJobs([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var response = await _jobManager.GetAllJobs(pageNumber, pageSize);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobById(int id)
        {
            var job = await _jobManager.GetJobById(id);
            return job != null ? Ok(job) : NotFound();
        }

        [HttpPost("apply")]
        [RequestSizeLimit(5 * 1024 * 1024)] 
        public async Task<IActionResult> ApplyForJob([FromForm] ApplicationViewModel application)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _jobManager.ApplyForJob(application);
                return CreatedAtAction(nameof(GetJobById), new { id = result.JobId }, result.ApplicantName);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, "An error occurred while processing your application.");
            }
        }

    }
}
