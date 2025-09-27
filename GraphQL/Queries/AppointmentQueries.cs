using TestGraph.UseCases.Appointment.Queries.GetAll;
using TestGraph.UseCases.Appointment.Queries.GetAllByDoctorId;
using TestGraph.UseCases.Appointment.Queries.GetAllByPersonId;
using TestGraph.UseCases.Appointment.Queries.GetById;

namespace TestGraph.GraphQL.Queries
{
    public class AppointmentQueries
    {
        readonly GetAppointmentByIdHandler _getAppointmentByIdHandler;
        readonly GetAllAppointmentHandler _getAllAppointmentHandler;
        readonly GetAllAppointmentByDoctorIdHandler _getAllAppointmentsByDoctorIdHandler;
        readonly GetAllAppointmentByPersonIdHandler _getAllAppointmentsByPersonIdHandler;
        public AppointmentQueries(GetAppointmentByIdHandler getAppointmentByIdHandler, GetAllAppointmentHandler getAllAppointment, 
            GetAllAppointmentByDoctorIdHandler getAllAppointmentsByDoctorIdHandler, GetAllAppointmentByPersonIdHandler getAllAppointmentByPersonIdHandler)
        {
           _getAppointmentByIdHandler = getAppointmentByIdHandler;
           _getAllAppointmentHandler = getAllAppointment;
           _getAllAppointmentsByDoctorIdHandler = getAllAppointmentsByDoctorIdHandler;
           _getAllAppointmentsByPersonIdHandler = getAllAppointmentByPersonIdHandler;
        }
        public async Task<GetAppointmentByIdResponse> GetAppointmentById(GetAppointmentByIdQuery query) => await _getAppointmentByIdHandler.Handle(query);

        public async Task<GetAllAppointmentResponse> GetAllAppointments(GetAllAppointmentQuery query) => await _getAllAppointmentHandler.Handle(query);

        public async Task<GetAllAppointmentByDoctorIdResponse> GetAllAppointmentsByDoctorId(GetAllAppointmentByDoctorIdQuery query) => await _getAllAppointmentsByDoctorIdHandler.Handle(query);

        public async Task<GetAllAppointmentByPersonIdResponse> GetAllAppointmentsByPersonId(GetAllAppointmentByPersonIdQuery query) => await _getAllAppointmentsByPersonIdHandler.Handle(query);
    }
}
