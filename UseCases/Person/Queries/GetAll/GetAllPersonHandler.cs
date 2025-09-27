using Microsoft.EntityFrameworkCore;
using TestGraph.Data;
using TestGraph.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TestGraph.UseCases.Person.Queries.GetAll
{
    public class GetAllPersonHandler
    {
        private readonly ApplicationDbContext _db;

        public GetAllPersonHandler(ApplicationDbContext db)
        {
            _db = db;
        }
            public async Task<GetAllPersonResponse> Handle(GetAllPersonQuery request)
            {
                var pagination = request.Pagination ?? new PaginationModel
                {
                    PageNumber = 1,
                    PageSize = 10
                };

                var query = _db.Persons.AsQueryable(); 

                var totalCount = await query.CountAsync();

                var persons = await query
                    .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                    .Take(pagination.PageSize)
                    .Select(p => new GetAllPersonsItemsResponse
                    {
                        Id = p.Id,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        DateOfBirth = p.DateOfBirth
                    })
                    .ToListAsync();

                return new GetAllPersonResponse
                {
                    TotalCount = totalCount,
                    Items = persons,
                    Success = true,
                    StatusCode = 200
                };
            }
        }
    }

