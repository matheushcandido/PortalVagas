using Application.DTOs;
using Application.Mapper;
using Core.Entities;
using Core.RepositoriesInterfaces;

namespace Application.UseCases.Job.GetById
{
    public class GetJobByIdUseCase : IGetJobByIdUseCase
    {
        private readonly IJobRepository _repository;
        private readonly JobMapper _mapper;

        public GetJobByIdUseCase(IJobRepository repository, JobMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UseCaseResponse<JobDTO>> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var job = await _repository.GetById(request.JobId);
                var jobDto = _mapper.DomainToViewModel(job);

                return UseCaseResponse<JobDTO>.Success(jobDto);
            }
            catch (Exception ex)
            {
                return UseCaseResponse<JobDTO>.InternalServerError("Erro ao obter vagas. Contate o administrador." + ex);
            }
        }
    }
}
