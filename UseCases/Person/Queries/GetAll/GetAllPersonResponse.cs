using TestGraph.Models;

namespace TestGraph.UseCases.Person.Queries.GetAll
{
    public class GetAllPersonResponse : BaseResponseModel
    {
        public int TotalCount { get; set; }
        public List<GetAllPersonsItemsResponse> Items { get; set; } = new();
    }
    public class GetAllPersonsItemsResponse
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
