using TestGraph.Data;

namespace TestGraph.UseCases.Doctor.Commands.Delete
{
    public class DeleteDoctorHandler
    {
        readonly ApplicationDbContext _db;
        public DeleteDoctorHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<DeleteDoctorResponse> Handle(DeleteDoctorCommand command)
        {
            if(command.Id <= 0)
                return new DeleteDoctorResponse { Success = false, StatusCode = 400, UserMessage = "Id is required."  };

            var doctor = await _db.Doctors.FindAsync(command.Id);

            if(doctor == null)
                return new DeleteDoctorResponse { Success = false, StatusCode = 404, UserMessage = "Doctor not found."  };

            _db.Doctors.Remove(doctor);
            await _db.SaveChangesAsync();
            return new DeleteDoctorResponse { Success = true, StatusCode = 200, UserMessage = "Doctor deleted successfully." };
        }
    }
}
