using FluentValidation;
using TestGraph.UseCases.Person.Commands.Create;

namespace TestGraph.Validation
{
    public class PersonValidator : AbstractValidator<CreatePersonCommand>
    {
        public PersonValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");
        }
    }
}
