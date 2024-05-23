using Application.Mapper;
using Core.RepositoriesInterfaces;

namespace Application.UseCases.Job.Create
{
    public class CreateJobUseCase : ICreateJobUseCase
    {
        private readonly CreateJobCommandValidator _validator = new();
        private readonly IJobRepository _repository;
        private readonly JobMapper _mapper = new();

        public CreateJobUseCase(CreateJobCommandValidator validator, IJobRepository repository, JobMapper mapper)
        {
            _validator = validator;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UseCaseResponse<bool>> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            if (request == null) 
            {
                return UseCaseResponse<bool>.BadRequest("Pedido inválido");
            }

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return UseCaseResponse<bool>.BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }

            try
            {
                await _repository.Add(_mapper.ViewModelToDomain(request.Job));

                return UseCaseResponse<bool>.Success(true);
            }
            catch (Exception ex) 
            {
                return UseCaseResponse<bool>.InternalServerError("Erro interno o inserir vaga. Contate o administrador." + ex);
            }
        }
    }
}
