using Application.DTOs;
using MediatR;

namespace Application.UseCases.Job.GetById
{
    public class GetJobByIdQuery : IRequest<UseCaseResponse<JobDTO>>
    {
        public required Guid JobId { get; set; }
    }
}
