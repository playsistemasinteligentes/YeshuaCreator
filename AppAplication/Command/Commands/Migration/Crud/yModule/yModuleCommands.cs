using RepositoryInterfaces.Patterns.Command;
namespace Command.Write
{
    public struct yModuleCrudCommand : ICommand
    {
        public string Id { get; set; }
        public string Description { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration