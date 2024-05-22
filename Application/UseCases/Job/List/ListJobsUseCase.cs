using Application.DTOs;
using Application.Mapper;
using Core.RepositoriesInterfaces;

namespace Application.UseCases.Job.List
{
    public class ListJobsUseCase : IListJobsUseCase
    {
        private readonly IJobRepository _repository;
        private readonly JobMapper _mapper;

        public ListJobsUseCase(IJobRepository repository, JobMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UseCaseResponse<IEnumerable<JobDTO>>> Handle(ListJobsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var jobs = await _repository.GetAll();
                var jobDtos = jobs.Select(job => _mapper.DomainToViewModel(job));

                return UseCaseResponse<IEnumerable<JobDTO>>.Success(jobDtos);
            }
            catch (Exception ex)
            {
                return UseCaseResponse<IEnumerable<JobDTO>>.InternalServerError("Erro ao obter vagas. Contate o administrador.");
            }
        }
    }
}
