using TestGraph.Models;

namespace TestGraph.UseCases.Doctor.Queries.Get
{
    public class GetDoctorByIdResponse : BaseResponseModel
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
