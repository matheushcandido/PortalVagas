using Application.DTOs;
using MediatR;

namespace Application.UseCases.Job.List
{
    public class ListJobsQuery : IRequest<UseCaseResponse<IEnumerable<JobDTO>>>
    {
    }
}
