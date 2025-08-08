using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct yUserModuleReadFKModuleIdCommand : ICommand
    {
        public string Id { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration