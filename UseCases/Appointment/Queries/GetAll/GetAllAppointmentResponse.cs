using TestGraph.Enums.Appointment;
using TestGraph.Models;

namespace TestGraph.UseCases.Appointment.Queries.GetAll
{
    public class GetAllAppointmentResponse : BaseResponseModel
    {
        public int TotalCount { get; set; }
        public List <GetAllAppointmentItemsResponse> Items { get; set; } = new();
    }
    public class GetAllAppointmentItemsResponse
    {
        public int? Id { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public AppointmentStatus? Status { get; set; }
        public int? PersonId { get; set; }
        public int? DoctorId { get; set; }
    }
}
