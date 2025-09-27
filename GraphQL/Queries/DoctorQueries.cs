using TestGraph.UseCases.Doctor.Queries.Get;
using TestGraph.UseCases.Doctor.Queries.GetAll;

namespace TestGraph.GraphQL.Queries
{
    public class DoctorQueries
    {
        readonly GetDoctorByIdHandler _getDoctorByIdHandler;
        readonly GetAllDoctorHandler _getAllDoctorsHandler;
        public DoctorQueries(GetDoctorByIdHandler getDoctorByIdHandler, GetAllDoctorHandler getAllDoctorsHandler)
        {
           _getDoctorByIdHandler = getDoctorByIdHandler;
           _getAllDoctorsHandler = getAllDoctorsHandler;
        }
        public async Task<GetDoctorByIdResponse> GetDoctorById(GetDoctorByIdQuery query) => await _getDoctorByIdHandler.Handle(query); 

        public async Task<GetAllDoctorResponse> GetAllDoctors(GetAllDoctorQuery query) => await _getAllDoctorsHandler.Handle(query);
    }
}
