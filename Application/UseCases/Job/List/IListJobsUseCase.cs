using Application.DTOs;
using MediatR;

namespace Application.UseCases.Job.List
{
    public interface IListJobsUseCase : IRequestHandler<ListJobsQuery, UseCaseResponse<IEnumerable<JobDTO>>>
    {
    }
}
