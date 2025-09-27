using TestGraph.Models;

namespace TestGraph.UseCases.Appointment.Queries.GetAllByPersonId
{
    public class GetAllAppointmentByPersonIdQuery
    {
        public int PersonId { get; set; }
        public PaginationModel? Pagination { get; set; }
    }
}
