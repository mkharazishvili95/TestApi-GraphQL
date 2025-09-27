using TestGraph.Models;
using TestGraph.UseCases.Appointment.Queries.GetAll;
using TestGraph.UseCases.Appointment.Queries.GetAllByDoctorId;
using TestGraph.UseCases.Appointment.Queries.GetAllByPersonId;
using TestGraph.UseCases.Appointment.Queries.GetById;
using TestGraph.UseCases.Doctor.Queries.Get;
using TestGraph.UseCases.Doctor.Queries.GetAll;
using TestGraph.UseCases.Person.Queries.Get;
using TestGraph.UseCases.Person.Queries.GetAll;

namespace TestGraph.GraphQL.Queries
{
    public class GraphQLRootQuery
    {
        public GraphQLRootQuery() { }
        public string Info() => "GraphQL schema is active.";

        [GraphQLName("getPersonById")]
        public Task<GetPersonByIdResponse> GetPersonById(
            [GraphQLName("query")] GetPersonByIdQuery query,
            [Service] PersonQueries personQuery)
        {
            return personQuery.GetPersonById(query);
        }

        [GraphQLName("getAllPersons")]
        public async Task<GetAllPersonResponse> GetAllPersons(
            [Service] GetAllPersonHandler handler,
            [GraphQLName("pagination")] PaginationModel pagination)
        {
            var query = new GetAllPersonQuery { Pagination = pagination };
            return await handler.Handle(query);
        }

        [GraphQLName("getAllAppointmentsByPersonId")]
        public async Task<GetAllAppointmentByPersonIdResponse> GetAllAppointmentsByPersonId(
        [GraphQLName("personId")] int personId,
        [GraphQLName("pagination")] PaginationModel? pagination,
        [Service] GetAllAppointmentByPersonIdHandler handler)
        {
            var query = new GetAllAppointmentByPersonIdQuery
            {
                PersonId = personId,
                Pagination = pagination
            };

            return await handler.Handle(query);
        }

        [GraphQLName("getDoctorById")]
        public Task<GetDoctorByIdResponse> GetDoctorById(
           [GraphQLName("query")] GetDoctorByIdQuery query,
           [Service] DoctorQueries doctorQuery)
        {
            return doctorQuery.GetDoctorById(query);
        }

        [GraphQLName("getAllDoctors")]
        public async Task<GetAllDoctorResponse> GetAllDoctors(
            [Service] GetAllDoctorHandler handler,
            [GraphQLName("pagination")] PaginationModel pagination)
        {
            var query = new GetAllDoctorQuery { Pagination = pagination };
            return await handler.Handle(query);
        }

        [GraphQLName("getAppointmentById")]
        public Task<GetAppointmentByIdResponse> GetAppointmentById(
           [GraphQLName("query")] GetAppointmentByIdQuery query,
           [Service] AppointmentQueries appointmentQuery)
        {
            return appointmentQuery.GetAppointmentById(query);
        }

        [GraphQLName("getAllAppointments")]
        public async Task<GetAllAppointmentResponse> GetAllAppointment(
            [Service] GetAllAppointmentHandler handler,
            [GraphQLName("pagination")] PaginationModel pagination)
        {
            var query = new GetAllAppointmentQuery { Pagination = pagination };
            return await handler.Handle(query);
        }

        [GraphQLName("getAllAppointmentsByDoctorId")]
        public async Task<GetAllAppointmentByDoctorIdResponse> GetAllAppointmentsByDoctorId(
        [GraphQLName("doctorId")] int doctorId,
        [GraphQLName("pagination")] PaginationModel? pagination,
        [Service] GetAllAppointmentByDoctorIdHandler handler)
        {
            var query = new GetAllAppointmentByDoctorIdQuery
            {
                DoctorId = doctorId,
                Pagination = pagination
            };

            return await handler.Handle(query);
        }
    }

}
