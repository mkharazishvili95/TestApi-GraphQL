using TestGraph.Data;
using TestGraph.UseCases.Person.Queries.Get;

public class GetPersonByIdHandler
{
    readonly ApplicationDbContext _db;

    public GetPersonByIdHandler(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<GetPersonByIdResponse> Handle(GetPersonByIdQuery query)
    {
        var person = await _db.Persons.FindAsync(query.Id);
        if (person == null)
        {
            return new GetPersonByIdResponse
            {
                Success = false,
                UserMessage = "Person not found."
            };
        }

        return new GetPersonByIdResponse
        {
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName,
            DateOfBirth = person.DateOfBirth,
            Success = true,
            UserMessage = "Person found."
        };
    }
}
