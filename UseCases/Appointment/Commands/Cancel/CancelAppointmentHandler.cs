using TestGraph.Data;

namespace TestGraph.UseCases.Appointment.Commands.Cancel
{
    public class CancelAppointmentHandler
    {
        readonly ApplicationDbContext _db;
        public CancelAppointmentHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<CancelAppointmentResponse> Handle(CancelAppointmentCommand command)
        {
            if (command.Id <= 0)
                return new CancelAppointmentResponse { Success = false, StatusCode = 400, UserMessage = "Id is required." };
            var appointment = await _db.Appointments.FindAsync(command.Id);
            if (appointment == null)
                return new CancelAppointmentResponse { Success = false, StatusCode = 404, UserMessage = "Appointment not found." };
            if ((int)appointment.Status == (int)Enums.Appointment.AppointmentStatus.Canceled)
                return new CancelAppointmentResponse { Success = false, StatusCode = 400, UserMessage = "Appointment is already cancelled." };
            appointment.Status = Enums.Appointment.AppointmentStatus.Canceled;
            await _db.SaveChangesAsync();
            return new CancelAppointmentResponse
            {
                Success = true,
                StatusCode = 200,
                UserMessage = "Appointment cancelled successfully."
            };
        }
    }
}
