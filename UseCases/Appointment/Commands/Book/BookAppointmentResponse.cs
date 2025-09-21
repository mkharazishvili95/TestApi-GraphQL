using TestGraph.Enums.Appointment;
using TestGraph.Models;

namespace TestGraph.UseCases.Appointment.Commands.Book
{
    public class BookAppointmentResponse : BaseResponseModel
    {
        public int? AppointmentId { get; set; }
        public int? PersonId { get; set; }
        public int? DoctorId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public AppointmentStatus? Status { get; set; }
    }
}
