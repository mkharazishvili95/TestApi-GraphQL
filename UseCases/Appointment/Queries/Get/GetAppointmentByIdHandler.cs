using TestGraph.Data;

namespace TestGraph.UseCases.Appointment.Queries.GetById
{
    public class GetAppointmentByIdHandler
    {
        readonly ApplicationDbContext _db;
        public GetAppointmentByIdHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<GetAppointmentByIdResponse> Handle(GetAppointmentByIdQuery query)
        {
            var appointment = await _db.Appointments.FindAsync(query.Id);
            if (appointment == null)
            {
                return new GetAppointmentByIdResponse
                {
                    Success = false,
                    UserMessage = "Appointment not found."
                };
            }
            return new GetAppointmentByIdResponse
            {
                Id = appointment.Id,
                AppointmentDate = appointment.AppointmentDate,
                DoctorId = appointment.DoctorId, 
                Status = appointment.Status, 
                PersonId = appointment.PersonId,
                StatusCode = 200,
                Success = true,
                UserMessage = "Appointment found."
            };
        }
    }
}
