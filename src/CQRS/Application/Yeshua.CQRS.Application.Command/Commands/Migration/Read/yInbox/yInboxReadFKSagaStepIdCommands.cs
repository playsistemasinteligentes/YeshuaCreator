using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct yInboxReadFKSagaStepIdCommand : ICommand
    {
        public int? Id { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration