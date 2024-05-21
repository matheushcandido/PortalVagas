using Application.DTOs;
using MediatR;

namespace Application.UseCases.Job.Create
{
    public class CreateJobCommand : IRequest<UseCaseResponse<bool>>
    {
        public required JobDTO Job { get; set; }
    }
}
