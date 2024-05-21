using MediatR;

namespace Application.UseCases.Job.Create
{
    public interface ICreateJobUseCase : IRequestHandler<CreateJobCommand, UseCaseResponse<bool>>
    {
    }
}
