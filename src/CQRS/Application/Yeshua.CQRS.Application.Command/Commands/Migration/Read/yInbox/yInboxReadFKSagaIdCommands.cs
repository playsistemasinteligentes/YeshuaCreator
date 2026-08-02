using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct yInboxReadFKSagaIdCommand : ICommand
    {
        public int? Id { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration