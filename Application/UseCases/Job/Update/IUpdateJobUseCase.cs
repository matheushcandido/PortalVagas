
using MediatR;

namespace Application.UseCases.Job.Update
{
    public interface IUpdateJobUseCase : IRequestHandler<UpdateJobCommand, UseCaseResponse<bool>>
    {
    }
}
