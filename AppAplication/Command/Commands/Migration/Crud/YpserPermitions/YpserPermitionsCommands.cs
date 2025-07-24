using RepositoryInterfaces.Patterns.Command;
namespace Command.Write
{
    public struct YpserPermitionsCrudCommand : ICommand
    {
        public string PermitionsId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration