using TestGraph.UseCases.Person.Queries.Get;
using TestGraph.UseCases.Person.Queries.GetAll;

namespace TestGraph.GraphQL.Queries
{
    public class PersonQueries
    {
        readonly GetPersonByIdHandler _getPersonByIdHandler;
        readonly GetAllPersonHandler _getAllPersonsHandler;
        public PersonQueries(GetPersonByIdHandler getPersonByIdHandler, GetAllPersonHandler getAllPersons)
        {
            _getPersonByIdHandler = getPersonByIdHandler;
            _getAllPersonsHandler = getAllPersons;
        }
        public async Task<GetPersonByIdResponse> GetPersonById(GetPersonByIdQuery query)  => await _getPersonByIdHandler.Handle(query);

        public async Task<GetAllPersonResponse> GetAllPersons(GetAllPersonQuery query) => await _getAllPersonsHandler.Handle(query);
    }
}
