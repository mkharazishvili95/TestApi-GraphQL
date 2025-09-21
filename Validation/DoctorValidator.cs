using FluentValidation;
using TestGraph.UseCases.Doctor.Commands.Create;

namespace TestGraph.Validation
{
    public class DoctorValidator : AbstractValidator<CreateDoctorCommand>
    {
        public DoctorValidator() 
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");
        }
    }
}
