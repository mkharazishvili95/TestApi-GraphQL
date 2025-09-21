using TestGraph.UseCases.Appointment.Commands.Book;
using TestGraph.UseCases.Appointment.Commands.Cancel;
using TestGraph.UseCases.Doctor.Commands.Create;
using TestGraph.UseCases.Doctor.Commands.Delete;
using TestGraph.UseCases.Person.Commands.Create;
using TestGraph.UseCases.Person.Commands.Delete;

namespace TestGraph.GraphQL.Mutations
{
    public class GraphQLRootMutation
    {
        public Task<CreatePersonResponse> CreatePerson(
            CreatePersonCommand command,
            [Service] PersonMutation personMutation)
        {
            return personMutation.CreatePerson(command);
        }

        public Task<DeletePersonResponse> DeletePerson(
            DeletePersonCommand command,
            [Service] PersonMutation personMutation)
        {
            return personMutation.DeletePerson(command);
        }

        public Task<CreateDoctorResponse> CreateDoctor(
            CreateDoctorCommand command,
            [Service] DoctorMutation doctorMutation)
        {
            return doctorMutation.CreateDoctor(command);
        }

        public Task<DeleteDoctorResponse> DeleteDoctor(
            DeleteDoctorCommand command,
            [Service] DoctorMutation doctorMutation)
        {
            return doctorMutation.DeleteDoctor(command);
        }

        public Task<BookAppointmentResponse> BookAppointment(
            BookAppointmentCommand command,
            [Service] AppointmentMutation appointmentMutation)
        {
            return appointmentMutation.BookAppointment(command);
        }

        public Task<CancelAppointmentResponse> CancelAppointment(
            CancelAppointmentCommand command,
            [Service] AppointmentMutation appointmentMutation)
        {
            return appointmentMutation.CancelAppointment(command);
        }
    }
}
