using TestGraph.UseCases.Person.Commands.Create;
using TestGraph.UseCases.Person.Commands.Delete;

namespace TestGraph.GraphQL.Mutations
{
    public class PersonMutation
    {
        readonly CreatePersonHandler _createPersonHandler;
        readonly DeletePersonHandler _deletePersonHandler;
        public PersonMutation(CreatePersonHandler createPersonHandler, DeletePersonHandler deletePersonHandler)
        {
            _createPersonHandler = createPersonHandler;
            _deletePersonHandler = deletePersonHandler;
        }
        public async Task<CreatePersonResponse> CreatePerson(CreatePersonCommand command) => await _createPersonHandler.Handle(command);
        public async Task<DeletePersonResponse> DeletePerson(DeletePersonCommand command) => await _deletePersonHandler.Handle(command);
    }
}
