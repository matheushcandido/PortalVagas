using Application.DTOs;
using Application.UseCases.Job.Create;
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

        [HttpPost]
        public async Task<IActionResult> CreateJob([FromBody] JobDTO jobDto)
        {
            var command = new CreateJobCommand { Job = jobDto };
            var response = await _mediator.Send(command);

            if (response.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(response.Response);
            }
        }
    }
}
