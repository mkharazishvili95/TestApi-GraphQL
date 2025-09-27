using Microsoft.EntityFrameworkCore;
using TestGraph.Data;
using TestGraph.Models;

namespace TestGraph.UseCases.Appointment.Queries.GetAllByPersonId
{
    public class GetAllAppointmentByPersonIdHandler
    {
        readonly ApplicationDbContext _db;
        public GetAllAppointmentByPersonIdHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<GetAllAppointmentByPersonIdResponse> Handle(GetAllAppointmentByPersonIdQuery request)
        {
            if (request.PersonId <= 0)
                return new GetAllAppointmentByPersonIdResponse
                {
                    Success = false,
                    StatusCode = 400,
                    UserMessage = "Request is required."
                };

            var pagination = request.Pagination ?? new PaginationModel
            {
                PageNumber = 1,
                PageSize = 10
            };

            var query = _db.Appointments
                           .Where(a => a.PersonId == request.PersonId)
                           .AsQueryable();

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(a => a.AppointmentDate)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .Select(p => new GetAllAppointmentByPersonIdItemsResponse
                {
                    Id = p.Id,
                    AppointmentDate = p.AppointmentDate,
                    DoctorId = p.DoctorId,
                    PersonId = p.PersonId,
                    Status = p.Status
                })
                .ToListAsync();

            return new GetAllAppointmentByPersonIdResponse
            {
                TotalCount = totalCount,
                Items = items,
                Success = true,
                StatusCode = 200
            };
        }
    }
}
