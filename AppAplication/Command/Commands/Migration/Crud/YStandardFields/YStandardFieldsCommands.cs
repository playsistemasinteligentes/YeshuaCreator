using RepositoryInterfaces.Patterns.Command;
namespace Command.Write
{
    public struct YStandardFieldsCrudCommand : ICommand
    {
        public bool? Deleted { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration