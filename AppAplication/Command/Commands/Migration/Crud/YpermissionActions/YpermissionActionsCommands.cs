using RepositoryInterfaces.Patterns.Command;
namespace Command.Write
{
    public struct YpermissionActionsCrudCommand : ICommand
    {
        public string Id { get; set; }
        public string Description { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration