using Microsoft.EntityFrameworkCore;
using TestGraph.Data;
using TestGraph.Models;
using TestGraph.UseCases.Person.Queries.GetAll;

namespace TestGraph.UseCases.Appointment.Queries.GetAllByDoctorId
{
    public class GetAllAppointmentByDoctorIdHandler
    {
        readonly ApplicationDbContext _db;
        public GetAllAppointmentByDoctorIdHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<GetAllAppointmentByDoctorIdResponse> Handle(GetAllAppointmentByDoctorIdQuery request)
        {
            if(request.DoctorId <= 0)
                return new GetAllAppointmentByDoctorIdResponse
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
                           .Where(a => a.DoctorId == request.DoctorId)
                           .AsQueryable();

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(a => a.AppointmentDate)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .Select(p => new GetAllAppointmentByDoctorIdItemsResponse
                {
                    Id = p.Id,
                    AppointmentDate = p.AppointmentDate,
                    DoctorId = p.DoctorId,
                    PersonId = p.PersonId,
                    Status = p.Status
                })
                .ToListAsync();

            return new GetAllAppointmentByDoctorIdResponse
            {
                TotalCount = totalCount,
                Items = items,
                Success = true,
                StatusCode = 200
            };
        }
    }
}
