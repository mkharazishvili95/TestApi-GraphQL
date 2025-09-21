using TestGraph.UseCases.Doctor.Commands.Create;
using TestGraph.UseCases.Doctor.Commands.Delete;

namespace TestGraph.GraphQL.Mutations
{
    public class DoctorMutation
    {
        readonly CreateDoctorHandler _createDoctorHandler;
        readonly DeleteDoctorHandler _deleteDoctorHandler;
        public DoctorMutation(CreateDoctorHandler createDoctorHandler, DeleteDoctorHandler deleteDoctorHandler)
        {
            _createDoctorHandler = createDoctorHandler;
            _deleteDoctorHandler = deleteDoctorHandler;
        }
        public async Task<CreateDoctorResponse> CreateDoctor(CreateDoctorCommand command) => await _createDoctorHandler.Handle(command);
        public async Task<DeleteDoctorResponse> DeleteDoctor(DeleteDoctorCommand command) => await _deleteDoctorHandler.Handle(command);
    }
}
