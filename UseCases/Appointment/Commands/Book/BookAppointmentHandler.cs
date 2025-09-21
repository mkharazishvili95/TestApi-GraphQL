using Microsoft.EntityFrameworkCore;
using TestGraph.Data;
using TestGraph.Enums.Appointment;

namespace TestGraph.UseCases.Appointment.Commands.Book
{
    public class BookAppointmentHandler
    {
        readonly ApplicationDbContext _db;
        public BookAppointmentHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<BookAppointmentResponse> Handle(BookAppointmentCommand command)
        {
            if (command.AppointmentDate < DateTime.Now)
                return new BookAppointmentResponse { Success = false, StatusCode = 400, UserMessage = "Appointment date must be in the future." };

            if (command.PersonId <= 0 || command.DoctorId <= 0 || command.AppointmentDate == default)
                return new BookAppointmentResponse { Success = false, StatusCode = 400, UserMessage = "PersonId, DoctorId and AppointmentDate are required." };

            var person = await _db.Persons.FindAsync(command.PersonId);
            if (person == null)
                return new BookAppointmentResponse { Success = false, StatusCode = 404, UserMessage = "Person not found." };

            var doctor = await _db.Doctors.FindAsync(command.DoctorId);
            if (doctor == null)
                return new BookAppointmentResponse { Success = false, StatusCode = 404, UserMessage = "Doctor not found." };

            var appointmentStart = command.AppointmentDate;
            var appointmentEnd = command.AppointmentDate.AddHours(1);

            var conflictExists = await _db.Appointments.AnyAsync(a =>
                a.DoctorId == command.DoctorId &&
                a.Status == AppointmentStatus.Scheduled &&
                a.AppointmentDate < appointmentEnd &&
                a.AppointmentDate.AddHours(1) > appointmentStart);

            if (conflictExists)
                return new BookAppointmentResponse { Success = false, StatusCode = 409, UserMessage = "This appointment time is already booked." };

            var appointment = new Entities.Appointment
            {
                PersonId = command.PersonId,
                DoctorId = command.DoctorId,
                AppointmentDate = command.AppointmentDate,
                Status = AppointmentStatus.Scheduled
            };

            _db.Appointments.Add(appointment);
            await _db.SaveChangesAsync();

            return new BookAppointmentResponse
            {
                AppointmentId = appointment.Id,
                AppointmentDate = appointment.AppointmentDate,
                Status = appointment.Status,
                DoctorId = appointment.DoctorId,
                PersonId = appointment.PersonId,
                Success = true,
                StatusCode = 201,
                UserMessage = "Appointment booked successfully."
            };
        }
    }
}
