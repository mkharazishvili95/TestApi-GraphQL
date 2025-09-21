//using TestGraph.UseCases.Person.Queries.Get;

//namespace TestGraph.UseCases.Person.Queries
//{
//    public class Query
//    {
//        private readonly GetByIdHandler _getByIdHandler;

//        public Query(GetByIdHandler getByIdHandler)
//        {
//            _getByIdHandler = getByIdHandler;
//        }

//        public async Task<GetByIdResponse> GetPersonById(int id)  => await _getByIdHandler.Handle(new GetByIdQuery(id));

//        public string Info() => "This is the Query.";
//    }
//}
