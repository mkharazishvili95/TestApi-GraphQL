using Microsoft.EntityFrameworkCore;
using TestGraph.Data;
using TestGraph.Models;

namespace TestGraph.UseCases.Appointment.Queries.GetAll
{
    public class GetAllAppointmentHandler
    {
        readonly ApplicationDbContext _db;
        public GetAllAppointmentHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<GetAllAppointmentResponse> Handle(GetAllAppointmentQuery query)
        {
            var pagination = query.Pagination ?? new PaginationModel
            {
                PageNumber = 1,
                PageSize = 10
            };

            var appointmentQuery = _db.Appointments.AsQueryable();

            var totalCount = await appointmentQuery.CountAsync();

            var doctors = await appointmentQuery
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .Select(p => new GetAllAppointmentItemsResponse
                {
                    Id = p.Id,
                    DoctorId = p.DoctorId,
                    PersonId = p.PersonId,
                    Status = p.Status,
                    AppointmentDate = p.AppointmentDate,
                })
                .ToListAsync();

            return new GetAllAppointmentResponse
            {
                TotalCount = totalCount,
                Items = doctors,
                Success = true,
                StatusCode = 200
            };
        }
    }
}
