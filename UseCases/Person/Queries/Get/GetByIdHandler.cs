//using TestGraph.Data;
//using TestGraph.UseCases.Person.Queries.Get;

//public class GetByIdHandler
//{
//    readonly ApplicationDbContext _db;

//    public GetByIdHandler(ApplicationDbContext db)
//    {
//        _db = db;
//    }

//    public async Task<GetByIdResponse> Handle(GetByIdQuery query)
//    {
//        var person = await _db.Persons.FindAsync(query.Id);
//        if (person == null)
//        {
//            return new GetByIdResponse
//            {
//                Success = false,
//                UserMessage = "Person not found."
//            };
//        }

//        return new GetByIdResponse
//        {
//            Id = person.Id,
//            FirstName = person.FirstName,
//            LastName = person.LastName,
//            DateOfBirth = person.DateOfBirth,
//            Success = true,
//            UserMessage = "Person found."
//        };
//    }
//}
