using TestGraph.Models;

namespace TestGraph.UseCases.Doctor.Queries.GetAll
{
    public class GetAllDoctorResponse : BaseResponseModel
    {
        public int TotalCount { get; set; }
        public List<GetAllDoctorsItemsResponse> Items { get; set; } = new();
    }
    public class GetAllDoctorsItemsResponse
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
