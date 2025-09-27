using Microsoft.EntityFrameworkCore;
using TestGraph.Data;
using TestGraph.Models;

namespace TestGraph.UseCases.Doctor.Queries.GetAll
{
    public class GetAllDoctorHandler
    {
        readonly ApplicationDbContext _db;
        public GetAllDoctorHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<GetAllDoctorResponse> Handle(GetAllDoctorQuery query)
        {
            var pagination = query.Pagination ?? new PaginationModel
            {
                PageNumber = 1,
                PageSize = 10
            };

                var doctorQuery = _db.Doctors.AsQueryable();

                var totalCount = await doctorQuery.CountAsync();

                var doctors = await doctorQuery
                    .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                    .Take(pagination.PageSize)
                    .Select(p => new GetAllDoctorsItemsResponse
                    {
                        Id = p.Id,
                        FirstName = p.FirstName,
                        LastName = p.LastName
                    })
                    .ToListAsync();

                return new GetAllDoctorResponse
                {
                    TotalCount = totalCount,
                    Items = doctors,
                    Success = true,
                    StatusCode = 200
                };
            }
        }
    }
