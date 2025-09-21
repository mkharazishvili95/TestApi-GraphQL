namespace TestGraph.UseCases.Appointment.Commands.Book
{
    public record BookAppointmentCommand(int PersonId, int DoctorId, DateTime AppointmentDate);
}
