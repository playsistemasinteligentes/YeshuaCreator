using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct yOutboxReadFKSagaStepIdCommand : ICommand
    {
        public int? Id { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration