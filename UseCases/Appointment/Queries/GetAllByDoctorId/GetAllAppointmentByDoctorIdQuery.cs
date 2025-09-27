using TestGraph.Models;

namespace TestGraph.UseCases.Appointment.Queries.GetAllByDoctorId
{
    public class GetAllAppointmentByDoctorIdQuery
    {
        public int DoctorId { get; set; }
        public PaginationModel? Pagination { get; set; }
    }
}
