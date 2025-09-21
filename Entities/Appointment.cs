using TestGraph.Enums.Appointment;

namespace TestGraph.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public AppointmentStatus Status { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
