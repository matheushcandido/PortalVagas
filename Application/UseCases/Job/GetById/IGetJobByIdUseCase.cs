using Application.DTOs;
using MediatR;

namespace Application.UseCases.Job.GetById
{
    public interface IGetJobByIdUseCase : IRequestHandler<GetJobByIdQuery, UseCaseResponse<JobDTO>>
    {
    }
}
