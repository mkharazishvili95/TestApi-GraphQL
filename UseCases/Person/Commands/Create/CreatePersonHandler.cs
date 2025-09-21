using TestGraph.Data;
using TestGraph.Validation;

namespace TestGraph.UseCases.Person.Commands.Create
{
    public class CreatePersonHandler
    {
        readonly ApplicationDbContext _db;
        public CreatePersonHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<CreatePersonResponse> Handle(CreatePersonCommand command)
        {
            var validator = new PersonValidator();
            var validatorResults = await validator.ValidateAsync(command);
            if (!validatorResults.IsValid)
                return new CreatePersonResponse {  Success = false,  StatusCode = 400,  UserMessage = string.Join(", ", validatorResults.Errors.Select(e => e.ErrorMessage)) };
            else
            {
                var person = new Entities.Person
                {
                    FirstName = command.FirstName,
                    LastName = command.LastName,
                    DateOfBirth = command.DateOfBirth
                };
                _db.Persons.Add(person);
                await _db.SaveChangesAsync();
                return new CreatePersonResponse
                {
                    Id = person.Id,
                    Success = true,
                    StatusCode = 200,
                    UserMessage = "Person created successfully."
                };
            }
        }
    }
}
