using TestGraph.Enums.Appointment;
using TestGraph.Models;

namespace TestGraph.UseCases.Appointment.Queries.GetAllByPersonId
{
    public class GetAllAppointmentByPersonIdResponse : BaseResponseModel
    {
        public int TotalCount { get; set; }
        public List<GetAllAppointmentByPersonIdItemsResponse> Items { get; set; } = new();
    }
    public class GetAllAppointmentByPersonIdItemsResponse
    {
        public int? Id { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public AppointmentStatus? Status { get; set; }
        public int? PersonId { get; set; }
        public int? DoctorId { get; set; }
    }
}
