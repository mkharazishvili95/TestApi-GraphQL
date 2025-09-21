using TestGraph.UseCases.Appointment.Commands.Book;
using TestGraph.UseCases.Appointment.Commands.Cancel;

namespace TestGraph.GraphQL.Mutations
{
    public class AppointmentMutation
    {
        readonly BookAppointmentHandler _bookAppointmentHandler;
        readonly CancelAppointmentHandler _cancelAppointmentHandler;
        public AppointmentMutation(BookAppointmentHandler bookAppointmentHandler, CancelAppointmentHandler cancelAppointmentHandler)
        {
            _bookAppointmentHandler = bookAppointmentHandler;
            _cancelAppointmentHandler = cancelAppointmentHandler;
        }

        public async Task<BookAppointmentResponse> BookAppointment(BookAppointmentCommand command)
            => await _bookAppointmentHandler.Handle(command);

        public async Task<CancelAppointmentResponse> CancelAppointment(CancelAppointmentCommand command)=>
            await _cancelAppointmentHandler.Handle(command);
    }
}
