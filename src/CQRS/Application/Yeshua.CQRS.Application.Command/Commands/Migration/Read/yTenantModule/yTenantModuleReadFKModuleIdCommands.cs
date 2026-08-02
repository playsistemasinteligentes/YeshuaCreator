using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct yTenantModuleReadFKModuleIdCommand : ICommand
    {
        public string Id { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration