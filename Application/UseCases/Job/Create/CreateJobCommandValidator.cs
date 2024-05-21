using FluentValidation;

namespace Application.UseCases.Job.Create
{
    public class CreateJobCommandValidator : AbstractValidator<CreateJobCommand>
    {
        public CreateJobCommandValidator() 
        {
            RuleFor(x => x.Job.Title)
                .NotEmpty().WithMessage("O campo título não pode ser nulo.");
        }
    }
}
