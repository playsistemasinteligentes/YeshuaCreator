using RepositoryInterfaces.Patterns.Command;
namespace Command.Write
{
    public struct YpserPermitionsCrudCommand : ICommand
    {
        public int? UserId { get; set; }
        public string PermitionsId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration