using TestGraph.Enums.Appointment;
using TestGraph.Models;

namespace TestGraph.UseCases.Appointment.Queries.GetAllByDoctorId
{
    public class GetAllAppointmentByDoctorIdResponse : BaseResponseModel
    {
        public int TotalCount { get; set; }
        public List<GetAllAppointmentByDoctorIdItemsResponse> Items { get; set; } = new();
    }
    public class GetAllAppointmentByDoctorIdItemsResponse
    {
        public int? Id { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public AppointmentStatus? Status { get; set; }
        public int? PersonId { get; set; }
        public int? DoctorId { get; set; }
    }
}
