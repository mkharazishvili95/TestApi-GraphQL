using TestGraph.Models;

namespace TestGraph.UseCases.Person.Commands.Create
{
    public class CreatePersonResponse : BaseResponseModel
    {
        public int? Id { get; set; }
    }
}
