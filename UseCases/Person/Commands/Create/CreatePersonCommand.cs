namespace TestGraph.UseCases.Person.Commands.Create
{
    public record CreatePersonCommand(string FirstName, string LastName, DateTime DateOfBirth);
}
