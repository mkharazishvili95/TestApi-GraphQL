using TestGraph.Models;

namespace TestGraph.UseCases.Person.Queries.Get
{
    public class GetPersonByIdResponse : BaseResponseModel
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
