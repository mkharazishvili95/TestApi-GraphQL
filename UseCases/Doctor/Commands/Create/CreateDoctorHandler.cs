using TestGraph.Data;
using TestGraph.Entities;
using TestGraph.Validation;

namespace TestGraph.UseCases.Doctor.Commands.Create
{
    public class CreateDoctorHandler
    {
        readonly ApplicationDbContext _db;
        public CreateDoctorHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<CreateDoctorResponse> Handle(CreateDoctorCommand command)
        {
            var validator = new DoctorValidator();
            var validatorResults = await validator.ValidateAsync(command);
            if (!validatorResults.IsValid)
            {
                return new CreateDoctorResponse { Success = false, StatusCode = 400, UserMessage = string.Join(", ", validatorResults.Errors.Select(e => e.ErrorMessage)) };
            }
            else
            {
                    var doctor = new Entities.Doctor
                    {
                        FirstName = command.FirstName,
                        LastName = command.LastName
                    };
                _db.Doctors.Add(doctor);
                await _db.SaveChangesAsync();
                return new CreateDoctorResponse
                {
                    Id = doctor.Id,
                    Success = true,
                    StatusCode = 200,
                    UserMessage = "Doctor created successfully."
                };
            }
        }
    }
}
