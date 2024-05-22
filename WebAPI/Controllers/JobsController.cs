using Application.DTOs;
using Application.UseCases.Job.Create;
using Application.UseCases.Job.List;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/jobs")]
    [ApiController]
    public class JobsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public JobsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new ListJobsQuery();
            var response = await _mediator.Send(query);

            if (response.IsSuccess)
            {
                return Ok(response.Response);
            }
            else
            {
                return BadRequest(response.Response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] JobDTO jobDto)
        {
            var command = new CreateJobCommand { Job = jobDto };
            var response = await _mediator.Send(command);

            if (response.IsSuccess)
            {
                return Ok(response.Response);
            }
            else
            {
                return BadRequest(response.Response);
            }
        }
    }
}
