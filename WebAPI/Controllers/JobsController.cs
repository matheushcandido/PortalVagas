using Application.DTOs;
using Application.UseCases.Job.Create;
using Application.UseCases.Job.GetById;
using Application.UseCases.Job.List;
using Application.UseCases.Job.Update;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetJobByIdQuery { JobId = id };
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] JobDTO jobDto)
        {
            var command = new UpdateJobCommand { JobId = id, JobDTO = jobDto };
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
