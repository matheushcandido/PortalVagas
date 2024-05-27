using Core.RepositoriesInterfaces;
using System.Net;

namespace Application.UseCases.Job.Update
{
    public class UpdateJobUseCase : IUpdateJobUseCase
    {
        private readonly IJobRepository _repository;

        public UpdateJobUseCase(IJobRepository repository)
        {
            _repository = repository;
        }

        public async Task<UseCaseResponse<bool>> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return UseCaseResponse<bool>.BadRequest("Peido inválido.");
            }

            var job = _repository.GetById(request.JobId);

            if (job == null)
            {
                return UseCaseResponse<bool>.Fail("Vaga não encontrada.", HttpStatusCode.NotFound);
            }

            job.Result.Title = request.JobDTO.Title;

            try
            {
                var updatedJob = await _repository.Update(await job);

                bool success = updatedJob != null;

                return UseCaseResponse<bool>.Success(success);
            } 
            catch (Exception ex)
            {
                return UseCaseResponse<bool>.InternalServerError("Erro ao atualizar informações da vaga. Contate o administrador do sistema.");
            }
        }
    }
}
