using TestGraph.Data;

namespace TestGraph.UseCases.Doctor.Queries.Get
{
    public class GetDoctorByIdHandler
    {
        readonly ApplicationDbContext _db;
        public GetDoctorByIdHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<GetDoctorByIdResponse> Handle(GetDoctorByIdQuery query)
        {
            var doctor = await _db.Doctors.FindAsync(query.Id);
            if (doctor == null)
            {
                return new GetDoctorByIdResponse
                {
                    Success = false,
                    UserMessage = "Doctor not found."
                };
            }
            return new GetDoctorByIdResponse
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName, 
                StatusCode = 200,
                Success = true,
                UserMessage = "Doctor found."
            };
        }
    }
}
