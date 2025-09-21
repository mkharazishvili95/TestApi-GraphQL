using TestGraph.Data;

namespace TestGraph.UseCases.Person.Commands.Delete
{
    public class DeletePersonHandler
    {
        readonly ApplicationDbContext _db;
        public DeletePersonHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<DeletePersonResponse> Handle(DeletePersonCommand request)
        {
            if(request.Id <= 0)
                return new DeletePersonResponse { Success = false, StatusCode = 400, UserMessage = "Id is required."  };

            var person = await _db.Persons.FindAsync(request.Id);
            if (person == null)
                return new DeletePersonResponse { Success = false, StatusCode = 404, UserMessage = "Person not found."  };
            
            _db.Persons.Remove(person);
            await _db.SaveChangesAsync();
            return new DeletePersonResponse
            {
                Success = true,
                StatusCode = 200,
                UserMessage = "Person deleted successfully."
            };
        }
    }
}
